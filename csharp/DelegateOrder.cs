//���ί�з����ĵ���˳��
using System;
namespace ί�к��¼�
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
            Delegate[] delegates = action.GetInvocationList(); //����ί�йҽӵķ�����ͨ�������Կ���ί�з���ִ��˳��
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
            Console.WriteLine("���ã�����һ");
            throw new Exception("Err in one");
        }
        private static void Two()
        {
            Console.WriteLine("���ã�������");
        }
        private static void Three()
        {
            Console.WriteLine("���ã�������");
        }
    }
}