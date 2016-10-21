using System;
using System.Collections.Generic;
using System.IO;
namespace DirectoryXMLGenerator
{
    using System.Linq;
    using System.Text;
    using System.Xml;

    public class XmlWriterDirectoryXmlGenerator : DirectoryXmlGenerator
    {
      
        public XmlWriterDirectoryXmlGenerator(string directoryPath, string xmlPath) : base(directoryPath, xmlPath)
        {
        }
                
        public override void GenerateXML()
        {          

            if (!File.Exists(this.XmlPath))
            {
                File.Delete(this.XmlPath);
            }
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(this.XmlPath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                WriteDirectory(writer, this.DirectoryPath);
                writer.WriteEndDocument();
            }
        }

        private void WriteDirectory(XmlTextWriter writer, string rootDirectoryPath)
        {
            string[] subDirs = Directory.GetDirectories(rootDirectoryPath);
            DirectoryInfo currentDirInfo = new DirectoryInfo(rootDirectoryPath);
            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", currentDirInfo.Name);
            writer.WriteAttributeString("creationDate", currentDirInfo.CreationTime.ToString());
            foreach (var dir in subDirs)
            {                      
                WriteDirectory(writer, dir);
            }
            string[] files = Directory.GetFiles(rootDirectoryPath);
            files
                 .ToList()
                 .ForEach(file => WriteFile(writer, file));
            writer.WriteEndElement();           
        }

        private void WriteFile(XmlTextWriter writer, string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            writer.WriteStartElement("file");
            writer.WriteAttributeString("name", fileInfo.Name);
            writer.WriteAttributeString("length", fileInfo.Length.ToString());
            writer.WriteAttributeString("creationDate", fileInfo.CreationTime.ToString());
            writer.WriteEndElement();
        }

    }
}
