using System;
using System.Linq;

namespace financial_scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new StockContext();
            WebScraper scraper = new WebScraper();
            var stockList = scraper.ScrapeStockPortfolio();
            var stockObjectList = StockProcessor.CreateStockObjectList(stockList);

            foreach (var stock in stockObjectList)
            {
                db.StockObjects.Add(stock);
                db.SaveChanges();
                Console.WriteLine($"Added {stock.Symbol}");
            }
        }
    }
}
