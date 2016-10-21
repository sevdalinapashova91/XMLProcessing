using System;
using System.Collections.Generic;
using System.IO;
namespace XMLDomParser.Models
{
    using System.Reflection;

    public abstract class PriceExtractor
    {
        private const string PathToCatalogueXML = @"XML\catalog.xml";
        protected const int MinYearsToExtract = 5;

        public string FullPathToCatalogueXML
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        PathToCatalogueXML);
            }
        }

        public abstract IEnumerable<decimal> ExtractPricesForAlbumsEqualOrOlderThanFiveYears();
    }
}
