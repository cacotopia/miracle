//UDPServer.cs
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
namespace cacotopia.miracle.network
{
	public class UdpServer 
	{
		static UdpClient m_server;
		static ArrayList m_list = new ArrayList();
		static void AddMember(IPEndPoint rep)
		{
			m_list.Add(rep);
			byte[] data = UDPCommon.EncodingASCII("OK");
			m_server.Send(data,data.Length,rep);
		}
		static void DelMember(IPEndPoint rep)
		{
			m_list.Remove(rep);
			byte[] data = UDPCommon.EncodingASCII("OK");
			m_server.Send(data,data.Length,rep);
		}

		static void SendToMember(string buf)
		{
			foreach(IPEndPoint point in m_list)
			{
				byte[] data = UDPCommon.EncodingASCII(buf);
				m_server.Send(data,data.Length,point);
			}
		}
		static void Main(string[] args)
		{
			string m_hostIP = "127.0.0.1";
			int m_port = 6666;
			IPEndPoint m_EndPoint;
			ArrayList member_list = new ArrayList();
			bool rt = false;
			byte[] data= null;
			string m_returndata;
			if(args.Length<2)
			{
				Console.WriteLine("Usage: UDPServer hostIP port");
			}
			else 
			{
				m_hostIP = args[0].ToString();
				m_port = int.Parse(args[1].ToString());
				rt = true;
			}

			if(rt)
			{
				member_list = new ArrayList();

				IPAddress m_ipA = IPAddress.Parse(m_hostIP);
				m_EndPoint = new IPEndPoint(m_ipA,m_port);
				m_server = new UdpClient(m_EndPoint);

				Console.WriteLine("Ready to coonnect....");

				while(true)
				{
					data = m_server.Receive(ref m_EndPoint);
					m_returndata = UDPCommon.DecodingASCII(data);

					if(m_returndata.IndexOf("ADD")>-1)
					{
						AddMember(m_EndPoint);
						Console.WriteLine(m_EndPoint.ToString() +"has added to the group.");
					}else if(m_returndata.IndexOf("DEL")>-1)
					{
						DelMember(m_EndPoint);
						Console.WriteLine(m_EndPoint.ToString() + "has deleted from group.");
					}else if(m_returndata.IndexOf("QUIT")>-1)
					{
						m_server.Close();
						break;

					}else 
					{
						if(m_list.Contains(m_EndPoint))
						{
							SendToMember(m_returndata + "[" + m_EndPoint.ToString()+ "]");
							Console.WriteLine(m_returndata +"["+m_EndPoint.ToString() + "]" +"has resent to members.");
						}
					}

				}
				
			}
		}
	}
}
