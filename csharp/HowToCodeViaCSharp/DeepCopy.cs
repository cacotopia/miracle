//DeepCopy.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Cacotopia 
{
	[Serializable]
	public class Department
	{
		private Int32 _DepartmentID;
		private String _DepartmentName;
		public Int32 DepartmentID 
		{
			get {return _DepartmentID;}
			set { _DepartmentID = value;}
		}
		public String DepartmentName
		{
			get {return _DepartmentName;}
			set {_DepartmentName = value;}
		}
	}
	 [Serializable]
    public class Employee : ICloneable
    {
    	  private Int32 _EmployeeID;
    	  private String _EmployeeName;
    	  private Department _Dempartment;
        public Int32 EmployeeID 
        { 
        	get {return _EmployeeID;} 
        	set {_EmployeeID = value; }
        }
        public String EmployeeName 
        { 
        	get { return _EmployeeName; }
        	set { _EmployeeName = value;} 
        }
        public Department Department 
        { 
        	get{ return _Dempartment; } 
        	set{ _Dempartment= value;} 
        }

        public object Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return null;
            }
        }
    }
     public class Utility
    {
        public static object CloneObject(object objSource)
        {
            //Get the type of source object and create a new instance of that type
            Type typeSource = objSource.GetType();
            object objTarget = Activator.CreateInstance(typeSource);

            //Get all the properties of source object type
            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            //Assign all source property to taget object 's properties
            foreach (PropertyInfo property in propertyInfo)
            {
                //Check whether property can be written to 
                if (property.CanWrite)
                {
                    //check whether property type is value type, enum or string type
                    if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(System.String)))
                    {
                        property.SetValue(objTarget, property.GetValue(objSource, null), null);
                    }
                    //else property type is object/complex types, so need to recursively call this method until the end of the tree is reached
                    else
                    {
                        object objPropertyValue = property.GetValue(objSource, null);
                        if (objPropertyValue == null)
                        {
                            property.SetValue(objTarget, null, null);
                        }
                        else
                        {
                            property.SetValue(objTarget, CloneObject(objPropertyValue), null);
                        }
                    }
                }
            }
            return objTarget;
        }
    }
    public static class ObjectExtension
    {
        public static T CopyObject<T>(this object objSource)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, objSource);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
        public static object CloneObject(this object objSource)
        {
            //Get the type of source object and create a new instance of that type
            Type typeSource = objSource.GetType();
            object objTarget = Activator.CreateInstance(typeSource);

            //Get all the properties of source object type
            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            //Assign all source property to taget object 's properties
            foreach (PropertyInfo property in propertyInfo)
            {
                //Check whether property can be written to 
                if (property.CanWrite)
                {
                    //check whether property type is value type, enum or string type
                    if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(System.String)))
                    {
                        property.SetValue(objTarget, property.GetValue(objSource, null), null);
                    }
                    //else property type is object/complex types, so need to recursively call this method until the end of the tree is reached
                    else
                    {
                        object objPropertyValue = property.GetValue(objSource, null);
                        if (objPropertyValue == null)
                        {
                            property.SetValue(objTarget, null, null);
                        }
                        else
                        {
                            property.SetValue(objTarget, objPropertyValue.CloneObject(), null);
                        }
                    }
                }
            }
            return objTarget;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.EmployeeID = 1000;
            emp.EmployeeName = "Cacotopia";
            emp.Department = new Department { DepartmentID = 1, DepartmentName = "development center" };

            Employee empClone = emp.Clone() as Employee;

            Employee empClone1 = Utility.CloneObject(emp) as Employee;
            Employee empClone2 = emp.CloneObject() as Employee;

            Employee empClone3 = emp.CopyObject<Employee>();
            //now Change Original Object Value
            emp.EmployeeName = "24/7";
            emp.Department.DepartmentName = "Admin";

            //Print origianl as well as clone object properties value.

            Console.WriteLine("Original Employee Name : " + emp.EmployeeName);
            Console.WriteLine("Original Department Name : " + emp.Department.DepartmentName);

            Console.WriteLine("");

            Console.WriteLine("Clone Object Employee Name (Clone Method) : " + empClone.EmployeeName);
            Console.WriteLine("Clone Object Department Name (Clone Method) : " + empClone.Department.DepartmentName);

            Console.WriteLine("");

            Console.WriteLine("Clone Object Employee Name (Static Method) : " + empClone1.EmployeeName);
            Console.WriteLine("Clone Object Department Name (Static Method) : " + empClone1.Department.DepartmentName);

            Console.WriteLine("");

            Console.WriteLine("Clone Object Employee Name (Extension Method) : " + empClone2.EmployeeName);
            Console.WriteLine("Clone Object Department Name (Extension Method) : " + empClone2.Department.DepartmentName);
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
    
}
 