//�¼��ı�����ʵ��

//�����¼���Ա����
public event EventHandler<NewMailEventArgs> NewMail;
//1.һ����ʼ��ΪNULL��˽��ί���ֶ�
private EventHandler<NewMailEventArgs> NewMail = null;

//2.һ������Add_Xxx�������������ǼǶ��¼��Ĺ�ע
public void add_NewMail(EventHandler<NewMailEventArgs> value)
{
	//ͨ��ѭ���Ͷ�CompareExchange�ĵ��ã�������һ���̰߳�ȫ�ķ�ʽ���¼����һ��ί��
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
//3.һ������remove_Xxx������������ע�����¼��Ĺ�ע
public void remove_NewMail(EventHandler<NewMailEventArgs> value) 
{
	//ͨ��ѭ���Ͷ�CompareExchange�ĵ��ã�������һ���̰߳�ȫ�ķ�ʽ���¼��Ƴ�һ��ί��
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