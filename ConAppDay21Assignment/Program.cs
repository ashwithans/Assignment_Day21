using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConAppDay21Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            Console.WriteLine("Enter Employee ID:");
            emp.Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employee First Name:");
            emp.FirstName = Console.ReadLine();

            Console.WriteLine("Enter Employee Last Name:");
            emp.LastName = Console.ReadLine();

            Console.WriteLine("Enter Employee Salary:");
            emp.Salary = Convert.ToDouble(Console.ReadLine());



            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("employee.bin", FileMode.Create))
            {
                binaryFormatter.Serialize(fileStream, emp);
            }



            using (FileStream fileStream = new FileStream("employee.bin", FileMode.Open))
            {
                Employee deserializedEmp = (Employee)binaryFormatter.Deserialize(fileStream);

                // Display properties of the deserialized Employee object
                Console.WriteLine("\nDeserialized Employee:");
                Console.WriteLine($"ID: {deserializedEmp.Id}");
                Console.WriteLine($"First Name: {deserializedEmp.FirstName}");
                Console.WriteLine($"Last Name: {deserializedEmp.LastName}");
                Console.WriteLine($"Salary: {deserializedEmp.Salary}");
            }



            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter("employee.xml"))
            {
                xmlSerializer.Serialize(writer, emp);
            }


            using (TextReader reader = new StreamReader("employee.xml"))
            {
                Employee deserializedEmpXml = (Employee)xmlSerializer.Deserialize(reader);

                Console.WriteLine("\nDeserialized Employee from XML:");
                Console.WriteLine($"ID: {deserializedEmpXml.Id}");
                Console.WriteLine($"First Name: {deserializedEmpXml.FirstName}");
                Console.WriteLine($"Last Name: {deserializedEmpXml.LastName}");
                Console.WriteLine($"Salary: {deserializedEmpXml.Salary}");
            }
        }
    }
}
