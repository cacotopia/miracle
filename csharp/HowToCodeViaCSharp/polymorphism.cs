//polymorphism.cs
//C#中的多态 2013.09.30
//区分编译时类型和运行时类型
//属性多态和索引器多态
using System;
namespace Cacotopia
{
	public class Contact
	{ private string  _ContactId = "0102";
		private string _ContactName = "cacotopia";
		private string _Address = String.Empty;
		public Contact()
		{ 
			this._ContactId = "0000";
			this._ContactName = "JYP";
			this._Address= "EastCome";
		}
		public String ContactId
		{
			get {return _ContactId;}
			set {_ContactId = value;}
		}
		public String ContactName
		{
			get {return _ContactName;}
			set {_ContactName = value;}
		}
		public String Address
		{
			get {return _Address;}
			set {_Address = value;}
		}
		public override string ToString()
		{
			return string.Format("ContactId:{0},ContactName:{1},Address:{2}.",ContactId,ContactName,Address);
		}
		public void SendAlert()
		{
			Console.WriteLine("Generic Contact Alert.");
		}
		public virtual void PostMessage()
		{
			Console.WriteLine("Generic Contact post message.");
		}
		public virtual string Email
		{
			get;set;
		}
		protected string[] sites = new string[5];
		public virtual string this[int index]
		{
			get 
			{
				return sites[index];
			}
			set 
			{
				sites[index] = value;
			}
		}
		
	}
	public class Customer:Contact 
	{
		public new void SendAlert()
		{
			Console.WriteLine("Alert for  Customer.");
		}
		public override void PostMessage()
		{
			Console.WriteLine("Customer post message.");
		}
		public override string Email
		{
			get 
			{
				return base.Email;
			}
			set 
			{
				base.Email = value;
			}
		}
		public override string this[int index]
		{
			get 
			{
				if (index>sites.Length)
				  return (string)null;
				  return base[index];
			}
			set 
			{
				base[index]= value;
			}
		}
	}
	public class SiteOwner:Contact
	{
		public new void SendAlert()
		{
			Console.WriteLine("Alert for SiteOwner.");
		}
		public override void PostMessage()
		{
			Console.WriteLine("SiteOwner post message.");
		}
	}
	public class Program 
	{
		static void Main(string[] args)
		{
			Contact con1  = new Contact();
			Contact con2 = new Customer();
			Contact con3 = new SiteOwner();
			con1.SendAlert(); //Geneirc Contact Alert.
			con2.SendAlert(); //Geneirc Contact Alert.
			con3.SendAlert(); //Geneirc Contact Alert.
			Console.WriteLine(con1.ToString());
			con1.PostMessage();//Generic contact post message
			con2.PostMessage();//Customer post message
			con3.PostMessage();//siteowner post message.
			Customer cust1 = new Customer();
			SiteOwner site1 = new SiteOwner();
			cust1.SendAlert(); //alert for Customer
			site1.SendAlert(); //alert for SiteOwner
			cust1.PostMessage();
			site1.PostMessage();
			Console.WriteLine("press any key to exit...");
			Console.ReadKey();
		}
	}
}