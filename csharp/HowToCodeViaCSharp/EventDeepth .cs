//事件的编译器实现

//定义事件成员本身
public event EventHandler<NewMailEventArgs> NewMail;
//1.一个初始化为NULL的私有委托字段
private EventHandler<NewMailEventArgs> NewMail = null;

//2.一个公共Add_Xxx方法，允许方法登记对事件的关注
public void add_NewMail(EventHandler<NewMailEventArgs> value)
{
	//通过循环和对CompareExchange的调用，可以以一种线程安全的方式向事件添加一个委托
	EventHandler<NewMailEventArgs> preHandler;
	EventHandler<NewMailEventArgs> newMail = this.NewMail;
	do
	{
		preHandler = newMail;
		EventHandler<NewMailEventArgs> newHandler = 
		(EventHandelr<NewMailEventArgs>) Delegate.Combine(preHandler,value);
		newMail = InterLocked.CompareExchange<EventHandler<NewMailEventArgs>>(ref this.NewMail,newHandler,preHandler);
		
	}while(newMail != preHandler)
}
//3.一个公共remove_Xxx方法，允许方法注销对事件的关注
public void remove_NewMail(EventHandler<NewMailEventArgs> value) 
{
	//通过循环和对CompareExchange的调用，可以以一种线程安全的方式从事件移除一个委托
	EventHandler<NewMailEventArgs> preHandler;
	EventHandler<NewMailEventArgs> newMail = this.NewMail;
	do
	{
		preHandler = newMail;
		EventHandelr<NewMailEventArgs> newHandler = 
		    (EventHandler<NewMailEventArgs>) Delegate.Remove(preHandler,value);
		newMail = InterLocked.CompareExchange<EventHandler<NewMailEventArgs>> (ref this.NewMail,newHandler,preHandler);
	}while(newMail!= preHandler)
}