namespace XMLDomParser.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class XPathPriceExtractor : PriceExtractor
    {
        private const string XPathToYearElement = "/catalogue/album/year";
        public override IEnumerable<decimal> ExtractPricesForAlbumsEqualOrOlderThanFiveYears()
        {
            XmlDocument document = new XmlDocument();
            IList<decimal> priceList = new List<decimal>();
            document.Load(this.FullPathToCatalogueXML);
            XmlNodeList yearNodes = document.SelectNodes(XPathToYearElement);
            foreach (XmlNode yearNode in yearNodes)
            {
                int year = int.Parse(yearNode.InnerText);
                if ((DateTime.Now.Year - year) >= MinYearsToExtract)
                {
                    var priceNode = yearNode.NextSibling.NextSibling;
                    decimal price = decimal.Parse(priceNode.InnerText);
                    priceList.Add(price);    
                }
            }
            return priceList;
        }
    }
}
