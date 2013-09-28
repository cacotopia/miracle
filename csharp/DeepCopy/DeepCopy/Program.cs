using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeepCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.EmployeeId = 1000;
            emp.EmployeeName = "Jignesh";
            emp.Department = new Department { DepartmentId = 1, DepartmentName = "Examination" };

            Employee empClone = emp.Clone() as Employee;

            Employee empClone1 = Utility.CloneObject(emp) as Employee;
            Employee empClone2 = emp.CloneObject() as Employee;

            Employee empClone3 = emp.CopyObject<Employee>();
            //now Change Original Object Value
            emp.EmployeeName = "Tejas";
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

            Console.ReadKey();
        }
    }
}
