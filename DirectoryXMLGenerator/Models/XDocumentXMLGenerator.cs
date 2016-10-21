namespace DirectoryXMLGenerator
{
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class XDocumentXMLGenerator : DirectoryXmlGenerator
    {
       public override void GenerateXML()
        {
            XDocument document = new XDocument();
            document.Add(WriteDirectory( this.DirectoryPath));
            document.Save(this.XmlPath);
        }
        public XDocumentXMLGenerator(string directoryPath, string xmlPath): base(directoryPath, xmlPath)
        {
        }
        private XElement WriteDirectory(string rootDirectoryPath)
        {
            DirectoryInfo currentDirInfo = new DirectoryInfo(rootDirectoryPath);
            string[] subDirs = Directory.GetDirectories(rootDirectoryPath);
            XElement directory = new XElement("dir",
                new XAttribute("name", currentDirInfo.Name),
                new XAttribute("creationDate", currentDirInfo.CreationTime.ToString()));
            
            foreach (var dir in subDirs)
            {
                var newDirectory = WriteDirectory(dir);
                directory.Add(newDirectory);
            }
            string[] files = Directory.GetFiles(rootDirectoryPath);
            files
                 .ToList()
                 .ForEach(file => WriteFile(directory, file));
            return directory;
        }

        private void WriteFile(XElement element, string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            XElement file = new XElement("file",
                new XAttribute("name", fileInfo.Name),
                new XAttribute("length", fileInfo.Length.ToString()),
                new XAttribute("creationDate", fileInfo.CreationTime.ToString()));
            element.Add(file);
        }
    }
}
