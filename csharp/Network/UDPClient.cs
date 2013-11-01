using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
namespace cacotopia.miracle.network
{
	public class UDPClient
	{
		static void Main(string[] args)
		{
			string m_hostIP = "127.0.0.1";
			int m_port = 6666;
			UdpClient m_client;
			bool rt = false;
			byte[] data= null;
			string m_senddata;
			string m_returndata;
			IPEndPoint m_EndPoint;

			
			if(args.Length<2)
			{
				Console.WriteLine("Usage:UDPClient hostIP port");
			}
			else 
			{
				m_hostIP= args[0].ToString();
				m_port = int.Parse(args[1].ToString());
				rt = true;
			}
			if(rt)
			{
				IPAddress m_ip = IPAddress.Parse(m_hostIP);
				m_EndPoint = new IPEndPoint(m_ip,m_port);
				m_client = new UdpClient();
				m_client.Connect(m_EndPoint);
				while(true)
				{
					Console.WriteLine("Input [ADD|DEL|REF|QUIT|Message]:");
					m_senddata= Console.ReadLine();
					if(m_senddata.IndexOf("ADD")>-1)
					{
						//m_senddata= "QUIT";
						data = UDPCommon.EncodingASCII(m_senddata);
						m_client.Send(data,data.Length);
					}
					if(m_senddata.IndexOf("REF")<=-1)
					{
						data = UDPCommon.EncodingASCII(m_senddata);
						m_client.Send(data,data.Length);

					}
					if(m_senddata.IndexOf("QUIT")>-1)
					{
						break;
					}
					data = m_client.Receive(ref m_EndPoint);
					m_returndata= UDPCommon.DecodingASCII(data);

				}
				Console.WriteLine("ByeBye");
				m_client.Close();			
			}
		}
	}
}
