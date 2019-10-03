using System;

namespace financial_scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WebScraper scraper = new WebScraper();
            scraper.ScrapePortfolio();
        }
    }
}
