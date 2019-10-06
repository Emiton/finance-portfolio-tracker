using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace financial_scraper
{
    class StockContext : DbContext
    {
        public StockContext(): base("StockDatabase") 
        {
        }
        public DbSet<StockObject> StockObjects { get; set; }
    }
}
