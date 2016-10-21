namespace XMLDomParser.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Xml;

    public class DomParserCatalogueProcessor : CatalogProcessor
    {
        public XmlDocument Document { get; private set; }

        public DomParserCatalogueProcessor()
        {
            this.Document = new XmlDocument();
            this.Document.Load(FullPathToCatalogueXML);
        }

        public override void DeleteFromCatalogAllAlbumsWithPriceGreaterThanTwenty()
        {
            XmlNodeList allAlbums = this.Document.DocumentElement.ChildNodes;
            
            for (int i = 0; i < allAlbums.Count; i++)
            {
                if (allAlbums.Item(i).ChildNodes.Count != 6)
                {
                    throw new ArgumentException("Invalid xml content");
                }
                string priceOfAlbum = allAlbums.Item(i).ChildNodes.Item(4).InnerText;
                decimal price = decimal.Parse(priceOfAlbum);
                if(price > MaxPriceToNotDelete)
                {
                    this.Document.DocumentElement.RemoveChild(allAlbums.Item(i));
                    this.Document.Save(this.FullPathToCatalogueXML);
                }
            }
        }

        public override IDictionary<string, int> GetAlbumNumbersForEachAuthor()
        {
            XmlNodeList allAlbums = this.Document.DocumentElement.ChildNodes;
            IDictionary<string, int> artistsWithAlbums = new Dictionary<string, int>();
            for (int i = 0; i < allAlbums.Count; i++)
            {
                if(allAlbums.Item(i).ChildNodes.Count != 6)
                {
                    throw new ArgumentException("Invalid xml content");
                }
                string artist = allAlbums.Item(i).ChildNodes.Item(1).InnerText;
                UpdateAlbumNumberOfArtist(artistsWithAlbums, artist);               
            }

            return artistsWithAlbums;
        }
    }
}
