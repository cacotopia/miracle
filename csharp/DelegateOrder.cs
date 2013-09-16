//多个委托方法的调用顺序
using System;
namespace 委托和事件
{
    internal class Program
    {   
    	  public delegate void MethodDelegate();
        private static void Main(string[] args)
        {
           /*
            Action action = One;
            action += Two;
            action += Three;
            Delegate[] delegates = action.GetInvocationList(); //返回委托挂接的方法，通过他可以控制委托方法执行顺序
            foreach (Action delegateAction in delegates)
            {
                try
                {
                    delegateAction();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            */
            
            MethodDelegate methods = One;
            methods += Two;
            methods += Three;
            methods.Invoke();
            Console.Read();
        }
        private static void One()
        {
            Console.WriteLine("调用：方法一");
            throw new Exception("Err in one");
        }
        private static void Two()
        {
            Console.WriteLine("调用：方法二");
        }
        private static void Three()
        {
            Console.WriteLine("调用：方法三");
        }
    }
}