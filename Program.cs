using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using static Less_5.ToDo;
namespace Less_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string fName = "Tasks.xml";
            if (File.Exists(fName)) 
            {
       
                 var serializer = new XmlSerializer(typeof(Task));
                 Task result;

                               using (TextReader reader = new StringReader(fName))
                             {
                               result = (Task)serializer.Deserialize(reader);
                             }
              
                Console.WriteLine(result);
                Console.ReadKey();
        
            }
            else
            {

                var company = new ToDo();
                company.duty = new List<Task>() { new Task() { Title = "Бегать по утрам.", Count = 1 ,isDone=false } };
                SerializeToXml(company, fName);

            }
        }

        public T DeserializeToObject<T>(string filepath) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StreamReader sr = new StreamReader(filepath))
            {
                return (T)ser.Deserialize(sr);
            }
        }
 
        public static void SerializeToXml<T>(T anyobject, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());
            using (StreamWriter writer = new StreamWriter(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, anyobject);
            }
        }

    }
}
