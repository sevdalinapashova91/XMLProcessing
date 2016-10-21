namespace DirectoryXMLGenerator
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            //Test xDocumentXMLGenerator
            Console.WriteLine("Enter directory path");
            string directoryPathForTest = Console.ReadLine();
            Console.WriteLine("Enter path to xml file");
            string xmlPath = Console.ReadLine();

            XmlWriterDirectoryXmlGenerator xmlGenerator = new XmlWriterDirectoryXmlGenerator(directoryPathForTest, xmlPath);
            xmlGenerator.GenerateXML();
            XDocumentXMLGenerator xDocumentGenerator = new XDocumentXMLGenerator(directoryPathForTest, xmlPath);
            xDocumentGenerator.GenerateXML();
            
          }    
    }
}
