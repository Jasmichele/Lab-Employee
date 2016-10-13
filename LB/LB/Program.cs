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
            XmlDocument doc = new XmlDocument();
            //doc.Load("Employes.xml");
           
            Console.WriteLine("1 Create Employee");
            Console.WriteLine("2 Terminate");
            Console.WriteLine("3 Give Raise");
            Console.WriteLine("4 Pay Employee");
            Console.WriteLine("5 Display All Employees");
            Console.WriteLine("6 Exit");
            string employer = Console.ReadLine();
            Console.Clear();
            if (employer == "1")
            {
                Console.WriteLine("Enter Employee Id");
                string a = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Employees First Name");
                string b = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Employee Pay Rate");
                string c = Console.ReadLine();
                Console.Clear();
                Emp p1 = new Emp(a, b, Convert.ToDouble(c));
                myEmp.Add(p1);
            }
            else if (employer == "2")
            {
                Console.WriteLine("Employee Id To Terminate");
                string a = Console.ReadLine();
                foreach (Emp e in myEmp)
                {
                    if (e.Id == "a")
                    {
                        e.Terminate();
                    }
                }


            }


            using (XmlWriter writer = XmlWriter.Create("Employee.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Company");

            }
        }
    }
}
