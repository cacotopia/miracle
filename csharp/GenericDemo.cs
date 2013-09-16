//·ºÐÍÊµÀý
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Cacotopia 
{
	class Program 
	{
		static void Main(string[] args) 
		{
			ArrayList list  = new ArrayList();
			Product tool  = new Product("Hello");
			list.Add(tool);
			Console.WriteLine(list[0].ToString());
			Console.ReadLine();
			
		}
	}
  public class Product
  {
  	//private long _productID;
  	private string _productName;
  	//private string _catotory;
  	//private string _producer;
  	//private decimal _price;
  	//private DateTime _prodeceddate;
  	//private string _location;
  //	public Product()
  	//{
  //	}
  	public Product(string name) 
  	{ _productName= name;
  	}
  	//public Product():this(0,string.Empty,string.Empty,string.Empty,0.0m,DateTime.Now,string.Empty)
  	//{
  		
  //	}
   // public override string ToString()
    //{
    	//return _productName;
   // }
  }
}