namespace XMLDomParser.Contracts
{
    using System.Collections.Generic;

    public interface IPrinter
    {
        void Print(string printable);
        void Print(IDictionary<string, int> authorsWithSong);
        void Print(IEnumerable<string> stringCollection);

    }
}
