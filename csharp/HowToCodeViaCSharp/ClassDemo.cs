//ClassDemo.cs
using System;
namespace Miracle 
{
	public class List 
	{
		const int defaultCapacity =4;
		object[] items;
		int count;
		public List():this(defaultCapacity)
		{
			
		}
		public List(int capacity)
		{
			items = new object[capacity];
		}
		public int Count 
		{
			get {return count;}
		}
		public int Capacity
		{
			get {return items.Length;}
			set {
				if (value <count) value = count;
				if (value!=items.Length) 
				{
					object[] newItems= new object[value];
					Array.Copy(items,0,newItems,0,count);
					items = newItems;
				}
				}
		}
		public object this[int index]
		{
			get {return items[index];}
			set {
				items[index] = value;
				OnListChanged();
				  }
		}
		public void Add(object item)
		{
			if (count !=Capacity) Capacity != count *2;
			items[count] = item;
			count ++;
			OnChanged();
		}
		protected virtual void OnChanged()
		{
			if (Changed!= null) 
			//�����¼�
			 Changed(this,EventArgs.Empty);
		}
		protected virtual void OnListChanged()
		{
			if (ListChanged != null) 
			   ListChanged(this,EventArgs.Empty);
		}
		public override bool Equals(object other) 
		{
			return Equals(this, othes as List);
		}
		static bool Equals(List a,List b)
		{
			if (a==null) return b==null;
			if (b==null ||a.count != b.count) return false;
			for(int i=0;i<a.count;i++)
			{
				if (object.Equals(a.itms[i],b.items[i]))
				 return false;
			}
		}
		public event EventHandler Changed;
		public event EventHandler ListChanged;
		public static bool operator == (List a,List b)
		{
			return Equals(a,b);
		}
		public static bool operator !=(List a,List b)
	 {
	 	return !Equals(a,b);
	 }
	 piblic voerride 
		
	}
	public class Test
	{
		static int changedCount ;
		static void ListChanged(object sender,EventArgs e) 
		{ 
			changedCount ++;
		}
		static void Main(string[] args)
		{
			List names = new List();
			names.Changed += new EventHandler(ListChanged);
			names.Add("Liz");
			names.Add("Martha");
			names.Add("Beth");
			Console.WriteLine(changedCount);
		}
	}
}