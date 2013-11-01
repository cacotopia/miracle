using System;
using System.Collections.Generic;
using System.Text;
namespace cacotopia.miracle.network
{
	public class UDPCommon
	{
          public static byte[] EncodingASCII(string buf)
	  {
		  byte[] data= Encoding.ASCII.GetBytes(buf +"\r\n");
		  return data;
	  }
	  public static string DecodingASCII(byte[] data)
	  {
		  string retval = Encoding.ASCII.GetString(data);
		  return retval;
	  }

	}
}
