using System;

namespace financial_scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WebScraper scraper = new WebScraper();
            // TODO: Scraper should return table of stocks, change method name?
            scraper.ScrapePortfolio();
            // TODOs
                // Create list of stocks
                // Add to DB
                // Query DB
                // Print all stocks out
                // Think about DateTime for DB, what about making certain queries to DB?
        }
    }
}
