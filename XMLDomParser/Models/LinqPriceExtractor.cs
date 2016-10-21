namespace XMLDomParser.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class LinqPriceExtractor : PriceExtractor
    {
        private const string YearElementName = "year";

        public override IEnumerable<decimal> ExtractPricesForAlbumsEqualOrOlderThanFiveYears()
        {
            XDocument document = XDocument.Load(this.FullPathToCatalogueXML);
            IList<decimal> prices = new List<decimal>();
            var yearNodes = document.Descendants(YearElementName);
            foreach (var yearNode in yearNodes)
            {
                int year = int.Parse(yearNode.Value);
                if ((DateTime.Now.Year - year) >= MinYearsToExtract)
                {
                    var priceNode = (XElement)yearNode.NextNode.NextNode;
                    decimal price = decimal.Parse(priceNode.Value);
                    prices.Add(price);
                }
            }
            return prices;
               
        }
    }
}
