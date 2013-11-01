//简单的多线程编程实例
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadSample{

	public class EatAppleSmp
	{
       public EatAppleSmp()
       {
             Thread th_mother,th_father,th_young,th_middle,th_old;
             Dish dish = new Dish(this,30);
             Productor  mother = new Productor("妈妈",dish);
             Productor father = new Productor("爸爸",dish);
             Consumer old = new Consumer("老大",dish,1000);
             Consumer middle = new Consumer("老二",dish,1200);
             Consumer young = new Consumer("老三",dish,1500);

             th_mother = new Thread(new ThreadStart(mother.run));
             th_father  = new Thread(new ThreadStart(father.run));
             th_old    = new Thread(new ThreadStart(old.run));
             th_middle = new Thread(new ThreadStart(middle.run));
             th_young = new Thread(new ThreadStart(young.run));
             //设置优先级
             th_mother.Priority = ThreadPriority.Highest;
             th_father.Priority = ThreadPriority.Normal;
             th_old.Priority = ThreadPriority.Lowest;
             th_middle.Priority = ThreadPriority.Normal;
             th_young.Priority = ThreadPriority.Highest;

             th_mother.Start();
             th_father.Start();
             th_old.Start();
             th_middle.Start();
             th_young.Start();
       }
       static void Main()
       {
       	EatAppleSmp mainstart = new EatAppleSmp();
       }
	}
	public class Dish 
	{
		private  int m_MAX_APPLE_COUNT =5;
		private EatAppleSmp oEAP;
		private int m_EnableNum ;
		private int n=0;

		public Dish(EatAppleSmp oEAP,int EnableNum)
		{
			this.oEAP = oEAP;
			this.m_EnableNum = EnableNum;
		}
		
		///
		///放苹果操作
		///
		public void put(string name)
		{
            lock(this) //同步控制放苹果
            {
            	while(m_MAX_APPLE_COUNT==0)
            	{
            		try 
            		{
            			System.Console.WriteLine("正在等待放入苹果。。。");
            			Monitor.Wait(this);
            		}catch(ThreadInterruptedException)
            		{

            		}
            	}
            	m_MAX_APPLE_COUNT = m_MAX_APPLE_COUNT -1;
            	n=n+1;
            	System.Console.WriteLine(name +"放一个苹果");
            	Monitor.PulseAll(this);
            	if(n>m_EnableNum)
            	{
            		Thread.CurrentThread.Abort();
            	}
            }
		}
		///
		///取苹果操作
		///
		public void get(string name)
		{
			lock(this)//同步控制取苹果
			{
				while(m_MAX_APPLE_COUNT ==5)
				{
					try 
					{
						System.Console.WriteLine(name +"等待取苹果");
						Monitor.Wait(this);
					}catch (ThreadInterruptedException)
					{

					}
				}
				m_MAX_APPLE_COUNT = m_MAX_APPLE_COUNT +1;
				Monitor.PulseAll(this);
			}
		}

	}

	///
	///生产者
	///
	public class Productor
	{
		private Dish dish;
		private string name;
		public Productor(string name,Dish dish)
		{
			this.name = name;
			this.dish = dish;
		}
		public void run()
		{
			while(true)
			{
				dish.put(name);
				try 
				{
					Thread.Sleep(600);
				}catch(ThreadInterruptedException)
				{

				}
			}
		}
	}
	///
	///消费者
	///
	public class Consumer
	{
		private string name;
		private Dish dish;
		private int timelong;
		public Consumer(string name,Dish dish,int timelong)
		{
			this.name = name;
			this.dish = dish;
			this.timelong = timelong;
		}
		public void run()
		{
			while(true)
			{
				dish.get(name);
				try 
				{
					Thread.Sleep(timelong);					
				}catch(ThreadInterruptedException)
				{

				}
			}
		}

	}
}
