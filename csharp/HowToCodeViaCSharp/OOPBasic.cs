//���ͺͳ�Ա����
//yuhuanlong 2013.09.20
//
using System;
public sealed class SomeType
{
	//Ƕ����
	private class SomeNestedType{}
	//������ֻ���ֶκ;�̬�ɶ���д�ֶ�
	private const Int32 SomeConstant =1;
	private readonly Int32 SomeReadOnlyField =2;
	private static Int32 SomeReadWriteField =3;
	//���͹�����
	static SomeType()
	{}
	//ʵ��������
	public SomeType(Int32 x){}
	public SomeType(){}
	//ʵ�������;�̬����
	private String InstanceMethod(){return null;}
	public static void Main(){}
	//ʵ������
	public Int32 SomeProperty
	{
		get {return 0;}
		set {}
	}
	//������
public Int32 this[String s]
	{
		get {return 0;}
		set {}
	}
	//ʵ���¼�
	public event EventHandler SomeEvent;
}