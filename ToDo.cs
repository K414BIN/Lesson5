using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Less_5
{
    [XmlRoot(ElementName = "ToDo")]
   public class ToDo
    {
        public ToDo()
        {
            duty = new List<Task>();
        }
        [XmlElement(ElementName = "Task")]
        public List<Task> duty { get; set; }

        public Task this[string name]
        {
            get { return duty.FirstOrDefault(s => string.Equals(s.Title, name, StringComparison.OrdinalIgnoreCase)); }
        }
}
   public class Task
    {
        [XmlAttribute("count")]
        public byte Count { get; set; }
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlAttribute("isdone")]
        public bool isDone { get; set; }
    }
}
