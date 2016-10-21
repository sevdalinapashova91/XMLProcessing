namespace XMLDomParser.Models
{
    using System.Collections.Generic;
    using System.Xml;

    public class XmlReaderSongExtractor : SongExtractor
    {
        
        public override IEnumerable<string> ExtractAllSongTitles()
        {
            IList<string> songTitlesInCatalogue = new List<string>();
            using (XmlReader reader = XmlReader.Create(this.FullPathToCatalogueXML))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == TitleTagName))
                    {
                       songTitlesInCatalogue.Add(reader.ReadElementString());
                    }
                }
            }
            return songTitlesInCatalogue;
        }
    }
}
