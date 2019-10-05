using System;
using System.Collections.Generic;
using System.Text;

namespace financial_scraper
{
    class StockObject
    {
        public String Symbol { get; set; }
        public String LastPrice { get; set; }
        public String ValueChange { get; set; }
        public String PercentChange { get; set; }
        public String Currency { get; set; }
        public String MarketTime { get; set; }
        public String Volume { get; set; }
        public String AverageVolume3M { get; set; }
        public String MarketCap { get; set; }
        public String ScrapeTime { get; set; }
    }
}
