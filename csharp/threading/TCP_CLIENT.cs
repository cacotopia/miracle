//TCP基础--客户端程序
using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Text;
namespace cacotopia.miracle.client
{
	public class Client
	{
      static byte[] EncodingASCII(string bul)
      {
      	byte[] data = Encoding.ASCII.GetBytes(bul +"\r\n");
      	return data;
      }
      static void Main(string[] args)
      {
      	string m_servername= "127.0.0.1";
      	string m_username = "NoName";
      	int m_port = 5555;

      	TcpClient m_client = null;
      	bool rt = false;
      	string m_senddata;
      	string m_returndata;
      	byte[] data;
      	StreamReader reader = null;
      	NetworkStream network = null;

      	if(args.Length<3)
      	{
      		Console.WriteLine("Usage:Client Username ServerName Port");
      	}else 
      	{
      		try
      		{
      			m_username = args[0].ToString();
      			m_servername= args[1].ToString();
      			m_port = int.Parse(args[2].ToString());
      			rt = true;
      		}catch(Exception e)
      		{
      			Console.WriteLine("Parameter error."+e.Message);
      		}
      	}

      	if(rt)
      	{
      		try
      		{
      			m_client = new TcpClient();
      			m_client.Connect(m_servername,m_port);

      			reader = new StreamReader(m_client.GetStream());
      			network = m_client.GetStream();

      			m_senddata = m_username;
      			data = EncodingASCII(m_senddata);
      			network.Write(data,0,data.Length);

      			while(true)
      			{
      				m_returndata= reader.ReadLine();
      				Console.WriteLine(m_returndata);

      				Console.WriteLine("Input data[GETDATA|QUIT|other]:");
      				m_senddata = Console.ReadLine();

      				if(m_senddata.IndexOf("QUIT")>-1)
      				{
      					m_senddata ="QUIT";
      				}
      				else if(m_senddata.IndexOf("GETDATA")>-1)
      				{
      					m_senddata = "GETDATA";
      				}
      				data = EncodingASCII(m_senddata);
      				network.Write(data,0,data.Length);

      				if(m_senddata.IndexOf("QUIT")>-1)
      				break;
      			}
      			m_client.Close();
      		}catch(Exception e)
      		{
      			Console.WriteLine("Exception:"+e.Message);
      		}
      	}
      }
	}
}