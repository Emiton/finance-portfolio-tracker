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

        public void ScrapePortfolio()
        {
            WebDriverWait defaultWait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            driver.Navigate().GoToUrl("https://finance.yahoo.com");

            // Sign in
            defaultWait.Until<IWebElement>(d => d.FindElement(By.Id("uh-signedin")));
            driver.FindElement(By.Id("uh-signedin")).Click();

            // TODO: Use environment variables for login
            defaultWait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id=\"login-username\"]")));
            IWebElement emailLogin = driver.FindElement(By.XPath("//*[@id=\"login-username\"]"));
            emailLogin.SendKeys("financetester321@gmail.com");
            driver.FindElement(By.Id("login-signin")).Click();

            HandleNewTab();

            // TODO: Deal with new tabs and pop ups
            // TODO: Use Xpath instead of ID
            defaultWait.Until<IWebElement>(d => 
                d.FindElement(
                    By.XPath("/html/body/div[2]/div[2]/div[1]/div[2]/div/form/input[7]")
                )
            );
            IWebElement passwordLogin = driver.FindElement(By.XPath("//*[@id=\"login-passwd\"]"));
            passwordLogin.SendKeys("thisisnew1234");
            driver.FindElement(By.Id("login-signin")).Click();

            HandleNewTab();





            Console.WriteLine("About to wait...");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Console.WriteLine("Finished waiting.");
        }

        private void HandleNewTab()
        {
            List<String> handles = new List<String>(driver.WindowHandles);
            if (handles.Count > 1)
            {
                for (int i = handles.Count - 1; i < 0; i--)
                {
                    driver.SwitchTo().Window(handles[i]);
                    driver.Close();
                }
            }
        }

        private void HandlePopup()
        {
            // TODO: Popup logic
        }
    }
}
