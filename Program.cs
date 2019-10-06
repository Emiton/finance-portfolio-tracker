using System;

namespace financial_scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new StockContext();
            Console.WriteLine("Hello World!");
            WebScraper scraper = new WebScraper();
            var stockList = scraper.ScrapeStockPortfolio();
            var stockObjectList = StockProcessor.CreateStockObjectList(stockList);

            foreach (var stock in stockObjectList)
            {
                db.StockObjects.Add(stock);
                db.SaveChanges();
            }

            // Add Query to check DB

            // TODOs
                // Create list of stocks
                // Add to DB
                // Query DB
                // Print all stocks out
                // Think about DateTime for DB, what about making certain queries to DB?
        }
    }
}
