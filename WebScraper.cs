﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace financial_scraper
{
    class WebScraper
    {
        private IWebDriver driver = new FirefoxDriver();

        public IList<IWebElement> ScrapeStockPortfolio()
        {
            WebDriverWait defaultWait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            driver.Navigate().GoToUrl("https://finance.yahoo.com");

            defaultWait.Until<IWebElement>(d => d.FindElement(By.Id("uh-signedin")));
            driver.FindElement(By.Id("uh-signedin")).Click();


            defaultWait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id=\"login-username\"]")));
            IWebElement emailLogin = driver.FindElement(By.XPath("//*[@id=\"login-username\"]"));
            emailLogin.SendKeys("financetester321@gmail.com");
            driver.FindElement(By.XPath("//*[@id=\"login-signin\"]")).Submit();
            HandleNewTab();



            defaultWait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[2]/div/form/input[7]")));
            IWebElement passwordLogin = driver.FindElement(By.XPath("//*[@id=\"login-passwd\"]"));
            passwordLogin.SendKeys("thisisnew1234");
            driver.FindElement(By.Id("login-signin")).Submit();

            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[1]/div[2]/div[1]/div/div/div/div/div/div/div/nav/div/div/div/div[3]/div/nav/ul/li[2]/a")).Click();
            defaultWait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/main/table/tbody/tr[1]/td[1]/div[2]/a")));
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/main/table/tbody/tr[1]/td[1]/div[2]/a")).Click();


            driver.Manage().Window.Maximize();

            IWebElement stockTable = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[2]/div/div/div[4]/main/div/div/div[2]/div/div[1]/table/tbody"));
            IList<IWebElement> stockList = stockTable.FindElements(By.TagName("tr"));
            int stockCount = stockList.Count;
            Console.WriteLine($"NUMBER OF STOCKS = {stockCount}");
            return stockList;
        }

        private void HandleNewTab()
        {
            List<String> handles = new List<String>(driver.WindowHandles);
            if (handles.Count > 1)
            {
                Console.WriteLine($"THERE ARE {handles.Count} HANDLES");
                for (int i = handles.Count - 1; i < 0; i--)
                {
                    Console.WriteLine(handles[i]);
                    driver.SwitchTo().Window(driver.WindowHandles[i]);
                    driver.Close();
                }
                driver.SwitchTo().Window(driver.WindowHandles[0]);
            }
        }
    }
}
