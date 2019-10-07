using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace financial_scraper
{
    static class StockProcessor
    {
        public static List<StockObject> CreateStockObjectList(IList<IWebElement> StockList)
        {
            var StockObjectList = new List<StockObject>();
            int rows = StockList.Count;
            int columns = StockList[0].FindElements(By.TagName("td")).Count;
            var scrapeTime = DateTime.Now;
            
            // XPath elements start at 1 index
            for (int i = 1; i < rows; i++)
            {
                var tempStock = new StockObject();
                tempStock.ScrapeTime = scrapeTime;

                // Last 2 columns are not needed, subtract by 1
                for (int j = 1; j < columns - 1; j++)
                {
                    string currentText = StockList[i].FindElement(By.XPath($"td[{j}]")).Text;
                    AddColumnInfo(ref tempStock, currentText, j);
                }

                StockObjectList.Add(tempStock);
            }

            return StockObjectList;
        }

        private static void AddColumnInfo(ref StockObject currentStock, string information, int columnId)
        {
            switch (columnId)
            {
                case 1:
                    currentStock.Symbol = information;
                    break;

                case 2:
                    currentStock.LastPrice = information;
                    break;

                case 3:
                    currentStock.ValueChange = information;
                    break;

                case 4:
                    currentStock.PercentChange = information;
                    break;

                case 5:
                    currentStock.Currency = information;
                    break;

                case 6:
                    currentStock.MarketTime = information;
                    break;

                case 7:
                    currentStock.Volume = information;
                    break;

                case 9:
                    currentStock.AverageVolume3M = information;
                    break;

                case 13:
                    currentStock.MarketCap = information;
                    break;

                default:
                    break;
            }
        }
    }
}
