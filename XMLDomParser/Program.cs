namespace XMLDomParser
{
    using XMLDomParser.Models;

    class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer();
            //Test DomParser
            var domParser = new DomParserCatalogueProcessor();
            domParser.DeleteFromCatalogAllAlbumsWithPriceGreaterThanTwenty();
            var albumsPerArtist = domParser.GetAlbumNumbersForEachAuthor();   
                     
            printer.Print(albumsPerArtist);

            //Test XPath
            var xPathParser = new XPathCatalogueProcessor();
            xPathParser.DeleteFromCatalogAllAlbumsWithPriceGreaterThanTwenty();
            var albumsPerArtistXPath = xPathParser.GetAlbumNumbersForEachAuthor();
            printer.Print(albumsPerArtistXPath);

            //Test SongExtractor
            //Song extractor xml reader
            var xmlReaderSongExctrator = new XmlReaderSongExtractor();
            var songTitles = xmlReaderSongExctrator.ExtractAllSongTitles();
            printer.Print(songTitles);

            //Song exctractot xdocument
            var xDocumentSongExctractor = new XDocumentSongExtractor();
            printer.Print(xDocumentSongExctractor.ExtractAllSongTitles());

            //AlbumGeneratorTest
            var albumGenerator = new AlbumGenerator();
            albumGenerator.GenerateAlbumXml();

            //PriceExtractor try
            var xPathPriceExtractor = new XPathPriceExtractor();
            xPathPriceExtractor.ExtractPricesForAlbumsEqualOrOlderThanFiveYears();
            var linqPathPriceExtractor = new LinqPriceExtractor();
            linqPathPriceExtractor.ExtractPricesForAlbumsEqualOrOlderThanFiveYears();
        }
    }
}
