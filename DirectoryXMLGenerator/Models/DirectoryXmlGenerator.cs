using System;
using System.Collections.Generic;
using System.IO;
namespace DirectoryXMLGenerator
{
    public abstract class DirectoryXmlGenerator : IDirectoryXmlGenerator
    {
        public string DirectoryPath { get; private set; }
        public string XmlPath { get; private set; }
        public DirectoryXmlGenerator(string directoryPath, string xmlPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new ArgumentException(string.Format("Invalid directory {0}",
                    this.DirectoryPath));
            }
            this.DirectoryPath = directoryPath;
            this.XmlPath = xmlPath;
        }

        public abstract void GenerateXML();
    }
}
