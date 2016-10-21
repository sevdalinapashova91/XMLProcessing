namespace XMLDomParser.Models
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public abstract class CatalogProcessor
    {
        private const string PathToCatalogueXML = @"XML\catalog.xml";
        protected const decimal MaxPriceToNotDelete = 20M;

        public string FullPathToCatalogueXML
        { 
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        PathToCatalogueXML);
            }
        }

        public abstract IDictionary<string, int> GetAlbumNumbersForEachAuthor();
        public abstract void DeleteFromCatalogAllAlbumsWithPriceGreaterThanTwenty();
                           
        protected void UpdateAlbumNumberOfArtist(IDictionary<string, int> artistsAndAlbumns, string artistName)
        {
            if(artistsAndAlbumns == null)
            {
                return;
            }
            if (artistsAndAlbumns.ContainsKey(artistName))
            {
                int albumCount = artistsAndAlbumns[artistName];
                artistsAndAlbumns[artistName] = albumCount + 1;
            }
            else
            {
                artistsAndAlbumns.Add(artistName, 1);
            }
        }
    }

}
