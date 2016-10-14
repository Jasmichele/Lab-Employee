using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LB
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Emp> myEmp = new List<Emp>();
        }
        public static void Menu(string options)
        {

            Console.WriteLine("1 Create Employee");
            Console.WriteLine("2 Terminate");
            Console.WriteLine("3 Give Raise");
            Console.WriteLine("4 Pay Employee");
            Console.WriteLine("5 Display All Employees");
            Console.WriteLine("6 Exit");
            string employer = Console.ReadLine();
        }
        public static string GetInput()
        {
            return Console.ReadLine();
        }
        public static void CreateNewEmployee(List<Emp> p4)
        {
            Console.WriteLine("Enter Employee Id");
            string a = GetInput();
            Console.Clear();
            Console.WriteLine("Employees First Name");
            string b = GetInput();
            Console.Clear();
            Console.WriteLine("Employee Pay Rate");
            string c = GetInput();
            Console.Clear();
            Emp p1 = new Emp(a, b, Convert.ToDouble(c));
            p4.Add(p1);
        }
        public static void TerminateEmployee(List<Emp> fi)
        {
            Console.WriteLine("Employee Id To Terminate");
            string a = GetInput();
            bool itemFound = false;
            
                foreach (Emp e in fi)
                {
                    if (e.Id == "a")
                    {
                        e.Fired();
                        itemFound = true;
                    }
                }
                if (itemFound == false)
                {
                    Console.WriteLine("Employee Not Found");
                }
        }
        public static void RaiseEmp(List<Emp> myE)
        {
            Console.WriteLine("Enter Employee Id To Give Raise");
            string a = GetInput();
            bool itemFound = false;
            
            foreach(Emp e in myE)
            {
                if(e.Id == "a")
                {
                    e.Raise(); 
                    itemFound = true;
                }
            }
            if (itemFound == false)
            {
                Console.WriteLine("Employee Not Found");
            }
        }
        public static void Pay(List<Emp> eli)
        {
            foreach(Emp e in eli)
            {
                Console.WriteLine(string.Format("{0} has been paid", e.FNAme));
            }
        }

    }
}
