///单例模式的实现
public class Singleton 
{
	private static Singleton uniqueInstance;
  private Singleton()
  {
  }
  public static Singleton()
  {
  	if (uniqueInstance==null) 
  	{
  		uniqueinstance = new Singleton();
  	}
  	return uniqueInstance;
  }
	
}