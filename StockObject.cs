using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace financial_scraper
{
    class StockObject
    {
        [Key]
        [Column(Order=1)]
        public String Symbol { get; set; }
        public String LastPrice { get; set; }
        public String ValueChange { get; set; }
        public String PercentChange { get; set; }
        public String Currency { get; set; }
        public String MarketTime { get; set; }
        public String Volume { get; set; }
        public String AverageVolume3M { get; set; }
        public String MarketCap { get; set; }
        [Key]
        [Column(Order = 2, TypeName = "datetime2")]
        public DateTime ScrapeTime { get; set; }
    }
}
