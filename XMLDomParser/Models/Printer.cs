namespace XMLDomParser.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using XMLDomParser.Contracts;

    public class Printer : IPrinter
    {
        public void Print(IEnumerable<string> stringCollection)
        {
            foreach (var item in stringCollection)
            {
                Console.WriteLine(item);
            }
        }

        public void Print(IDictionary<string, int> authorsWithSong)
        {
            authorsWithSong.ToList().ForEach(x => 
                Console.WriteLine(string.Format("The artist {0} has got {1} albums", x.Key, x.Value)));
        }

        public void Print(string printable)
        {
            Console.WriteLine(printable);
        }
    }
}
