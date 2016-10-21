namespace DirectoryXMLGenerator
{
    public interface IDirectoryXmlGenerator
    {
       string DirectoryPath { get; }
       string XmlPath { get; }
       void GenerateXML();  
    }
}
