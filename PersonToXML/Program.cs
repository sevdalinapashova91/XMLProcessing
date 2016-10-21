namespace PersonToXML
{
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            //In a text file we are given the name, address and phone number of given person (each at a single line).
            //Write a program, which creates new XML document, which contains these data in structured XML format.
            var binFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var pathToPersonFile = Path.Combine(binFolderPath, @"Resources\Person.txt");
            var pathToPersonXML = Path.Combine(binFolderPath, @"Resources\Person.xml");
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            string[] lines = System.IO.File.ReadAllLines(pathToPersonFile);
            using (XmlTextWriter writer = new XmlTextWriter(pathToPersonXML, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("People");
                for (var i = 0; i < lines.Length; i++)
                {
                    if (i % 3 == 2)
                    {
                        writer.WriteStartElement("Person");
                        writer.WriteElementString("name", lines[i - 2].Trim());
                        writer.WriteElementString("address", lines[i - 1].Trim());
                        writer.WriteElementString("phone", lines[i].Trim());
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndDocument();
            }
        }
    }
}
