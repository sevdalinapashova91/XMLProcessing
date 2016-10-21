namespace XMLDomParser.Models
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public abstract class SongExtractor
    {
        private const string PathToCatalogueXML = @"XML\catalog.xml";
        protected const string TitleTagName = "title";

        public string FullPathToCatalogueXML
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        PathToCatalogueXML);
            }
        }

        public abstract IEnumerable<string> ExtractAllSongTitles();
    }
}
