namespace XMLDomParser.Models
{
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Xml;

    public class AlbumGenerator
    {
        private const string PathToCatalogueXML = @"XML\catalog.xml";
        private const string PathToAlbumXML = @"XML\album.xml";
        private const string AlbumElementName = "album";
        private const string AlbumRootElementName = "albums";
        private const string AlbumTitleElementName = "title";
        private const string ArtistElementName = "artist";
        private const string CatalogueAlbumElementName = "name";
        private const string EncodingWindows1251 = "windows-1251";

        public string FullPathToCatalogueXML
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        PathToCatalogueXML);
            }
        }

        public string FullPathToAlbumXML
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                       PathToAlbumXML);
            }
        }

        public void GenerateAlbumXml()
        {
            Encoding encoding = Encoding.GetEncoding(EncodingWindows1251);
            if (File.Exists(this.FullPathToAlbumXML))
            {
                File.Delete(this.FullPathToAlbumXML);
            }
            using (XmlTextWriter writer = new XmlTextWriter(this.FullPathToAlbumXML, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement(AlbumRootElementName);
                using (XmlReader reader = XmlReader.Create(this.FullPathToCatalogueXML))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                         (reader.Name == CatalogueAlbumElementName))
                        {
                            var albumName = reader.ReadElementString();
                            reader.Read();
                            var artistName = reader.ReadElementString();
                            WriteAlbum(writer, albumName, artistName);
                        }
                    }

                }
                writer.WriteEndDocument();
            }
        }

        private static void WriteAlbum(XmlWriter writer, string title, string artist)
        {
            writer.WriteStartElement(AlbumElementName);
            writer.WriteElementString(AlbumTitleElementName, title);
            writer.WriteElementString(ArtistElementName, artist);
            writer.WriteEndElement();
        }


    }
}
