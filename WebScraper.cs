using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace financial_scraper
{
    class WebScraper
    {
        private IWebDriver driver = new ChromeDriver();

        public void ScrapeData()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
        }
    }
}
