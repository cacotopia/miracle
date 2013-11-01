//TCP 基础
using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Text;
namespace cacotopia.miracle.server 
{
	//客户端连接处理，用来接收和发送网络数据
	public class ClientHandler
	{
         private string m_username;
         private TcpClient m_clientsocket = null;
         private string m_returnData ;
         private string m_sendData;
         private byte[] m_data=null;

         public TcpClient ClientSocket 
         {
         	get 
         	{
         		return this.m_clientsocket;
         	}
         	set 
         	{
         		this.m_clientsocket = value;
         	}
         }
        public byte[] EncodingASCII(string bul)
         {
         	byte[] data = Encoding.ASCII.GetBytes(bul +"\r\n");
         	return data;
         }
        public void Response()
        {
        	if(this.m_clientsocket!=null)
        	{
        		StreamReader  reader= new StreamReader(m_clientsocket.GetStream());
        		NetworkStream network = m_clientsocket.GetStream();

        		m_returnData = reader.ReadLine();
        		m_username = m_returnData;
        		Console.WriteLine("Welcome "+m_sendData +"to Server." );

        		m_data = EncodingASCII(m_sendData);
        		network.Write(m_data,0,m_data.Length);

        		while(true)
        		{
        			m_returnData = reader.ReadLine();

        			if(m_returnData.IndexOf("QUIT")>-1)
        			{
        				Console.WriteLine(m_username +"has quited.");
        				break;
        			}else if(m_returnData.IndexOf("GETDATA")>-1)
        			{
        				m_sendData = DateTime.Now.ToString();
        			}else 
        			{
        				m_sendData = "-->" +m_returnData;
        			}
        			m_data = EncodingASCII(m_sendData);
        			network.Write(m_data,0,m_data.Length);
        		}
        		m_clientsocket.Close();
        	}
        }
	}
	public class Server 
	{
		static void Main(string[] args)
		{
			string m_serverIP= "127.0.0.1";
			int m_port = 5555;
			bool rt = false;
			TcpListener m_listener = null;
			IPAddress m_host;
			if(args.Length<2)
			{
				Console.WriteLine("Usage: Server ServerIP Port");
			}else 
			{
				try 
				{
					m_serverIP = args[0].ToString();
					m_port = int.Parse(args[1].ToString());
					rt = true;
				}catch(Exception e)
				{
					Console.WriteLine("Parameter Error:"+ e.Message);
				}
			}

			if(rt)
			{
				try
				{
					m_host = IPAddress.Parse(m_serverIP);
					m_listener = new TcpListener(m_host,m_port);
					m_listener.Start();
					Console.WriteLine("Starting to listen......");

					while(true)
					{
						TcpClient m_client = m_listener.AcceptTcpClient();
						ClientHandler m_handler = new ClientHandler();
						m_handler.ClientSocket = m_client;

						Thread m_clientthread = new Thread(new ThreadStart(m_handler.Response));
						m_clientthread.Start();
					}
					
				//	m_listener.Stop();
				}
				catch(Exception e)
				{
					Console.WriteLine("Exception:"+ e.Message);
				}
			}

		}
	}
}