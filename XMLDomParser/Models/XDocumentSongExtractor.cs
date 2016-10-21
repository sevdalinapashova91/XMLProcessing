namespace XMLDomParser.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class XDocumentSongExtractor : SongExtractor
    {
        public override IEnumerable<string> ExtractAllSongTitles()
        {
            XDocument document = XDocument.Load(this.FullPathToCatalogueXML);
            return document
                .Descendants(TitleTagName)
                .Select(x => x.Value);       
        }
    }
}
