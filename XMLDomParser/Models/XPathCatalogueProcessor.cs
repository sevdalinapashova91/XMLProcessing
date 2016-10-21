namespace XMLDomParser.Models
{
    using System.Collections.Generic;
    using System.Xml;

    public class XPathCatalogueProcessor : CatalogProcessor
    {
        private const string XPathToAlbum = "/catalogue/album";
        private const string artistNodeName = "artist";
        private const string priceNodeName = "price";
        public XmlDocument Document { get; private set; }

        public XPathCatalogueProcessor()
        {
            this.Document = new XmlDocument();
            this.Document.Load(FullPathToCatalogueXML);
        }

        public override IDictionary<string, int> GetAlbumNumbersForEachAuthor()
        {                      
            XmlNodeList albums = this.Document.SelectNodes(XPathToAlbum);
            IDictionary<string, int> artistsWithAlbums = new Dictionary<string, int>();
            foreach (XmlNode album in albums)
            {
                string artistName = album.SelectSingleNode(artistNodeName).InnerText;
                UpdateAlbumNumberOfArtist(artistsWithAlbums, artistName);
            }
            return artistsWithAlbums;
        }

        public override void DeleteFromCatalogAllAlbumsWithPriceGreaterThanTwenty()
        {
            XmlNodeList albums = this.Document.SelectNodes(XPathToAlbum);
            foreach (XmlNode album in albums)
            {
                string priceOfAlbum = album.SelectSingleNode(priceNodeName).InnerText;
                decimal price = decimal.Parse(priceOfAlbum);
                if (price > MaxPriceToNotDelete)
                {
                    this.Document.DocumentElement.RemoveChild(album);
                    this.Document.Save(this.FullPathToCatalogueXML);
                }

            }

        }
    }
}
