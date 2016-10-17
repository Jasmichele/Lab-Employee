using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace LB
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\myfiles\\coffee.xml";
            List<Emp> myEmp = new List<Emp>();

            if(File.Exists(fileName))
            {
                ReadFile(fileName, myEmp);
            }
            else
            {
                FileNotFound(fileName);
            }
            bool keepLooping = true;

            while (keepLooping)
            {
                Menu();
                string userInput = GetInput();
                switch (userInput)
                {
                    case "1":
                        {
                            CreateNewEmployee(myEmp);
                            break;
                        }
                    case "2":
                        {
                            TerminateEmployee(myEmp);
                            break;
                        }
                    case "3":
                        {
                            RaiseEmp(myEmp);
                            break;
                        }
                    case "4":
                        {
                            Pay(myEmp);
                            Console.ReadKey();
                            break;
                        }
                    case "5":
                        {
                            Display(myEmp);
                            Console.ReadKey();
                            break;
                        }
                    case "6":
                        {
                            Save(myEmp);
                            keepLooping = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public static void ReadFile(string fileNAme, List<Emp> e)
        {
            if (File.Exists(fileNAme))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileNAme);
                XmlNode comNode = doc.DocumentElement.SelectSingleNode("/company");

                foreach(XmlNode child in comNode.ChildNodes)
                {
                    string empId = "";
                    string empName = "";
                    double empPayRate = 0;

                    foreach (XmlNode granchild in child.ChildNodes)
                    {
                        switch(granchild.Name)
                        {
                            case "Id":
                                {
                                    empId = granchild.InnerText;
                                    break;
                                }
                            case "Name":
                                {
                                    empName = granchild.InnerText;
                                    break;
                                }
                            case "PayRate":
                                {
                                    empPayRate = Convert.ToDouble(granchild.InnerText);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        Emp p1 = new Emp(empId, empName, empPayRate);
                        e.Add(p1);
                    }
                }
            }
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1 Create Employee");
            Console.WriteLine("2 Terminate");
            Console.WriteLine("3 Give Raise");
            Console.WriteLine("4 Pay Employee");
            Console.WriteLine("5 Display All Employees");
            Console.WriteLine("6 Exit");
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

            foreach (Emp e in myE)
            {
                if (e.Id == "a")
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
            foreach (Emp e in eli)
            {
                DateTime date = new DateTime(0001, 1, 01);
                if (e.Terminate < date && e.Terminate < DateTime.MinValue)
                {
                    Console.WriteLine(string.Format("{0} has been paid", e.FNAme));
                }
            }
        }
        public static void Display(List<Emp> eli)
        {
            foreach (Emp e in eli)
            {

                Console.WriteLine(string.Format("{0}", e.FNAme));

            }
        }
        public static void Save(List<Emp> e1)
        {
            using (XmlWriter writer = XmlWriter.Create("C:\\myfiles\\coffee.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Company");

                foreach (Emp e in e1)
                {
                    writer.WriteStartElement("Employee");

                    writer.WriteElementString("Id", e.Id.ToString());
                    writer.WriteElementString("Name", e.FNAme);
                    writer.WriteElementString("PayRate", e.PayRate.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        public static void FileNotFound(string fileName)
        {
            Console.WriteLine("File doesn't exist, New file created");
            Console.ReadKey();

            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("company");

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }


        }
    }
}
