using System;
using System.Text;
public class StringDemo{
  static void Main(){
  // int readValue;
  // char character;
  // readValue=System.Console.Read();
  // character =(char) readValue;
  // System.Console.WriteLine(character);
   StringBuilder sb1= new StringBuilder();
   StringBuilder sb2 =new StringBuilder(10);
   StringBuilder sb3 =new StringBuilder("hello.");
   Console.WriteLine("sb1=" + sb1);
   Console.WriteLine("sb2=" + sb2);
   Console.WriteLine("sb3=" +sb3);

   StringBuilder buffer= new StringBuilder("hello,how are you?");
   Console.WriteLine("buffer=" +buffer +
		   "\nLength="+ buffer.Length+"\n"
		   +"Capacity="+buffer.Capacity);
   buffer.EnsureCapacity(75);
   Console.WriteLine("\nNew capacity="+buffer.Capacity);

   buffer.Length=10;
   Console.WriteLine("\nNew Length= " +buffer.Length+ "\nbuffer=" +buffer);
   for(int i=0;i<buffer.Length;i++){
   Console.WriteLine(buffer[i]);
   }
   

  }
}
