using OpenQA.Selenium;
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
            //driver.FindElement(By.Id("login-signin")).Click();
            driver.FindElement(By.XPath("//*[@id=\"login-signin\"]")).Submit();
            HandleNewTab();



            defaultWait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[2]/div/form/input[7]")));
            IWebElement passwordLogin = driver.FindElement(By.XPath("//*[@id=\"login-passwd\"]"));
            passwordLogin.SendKeys("thisisnew1234");
            driver.FindElement(By.Id("login-signin")).Submit();

            HandleNewTab();

            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[1]/div[2]/div[1]/div/div/div/div/div/div/div/nav/div/div/div/div[3]/div/nav/ul/li[2]/a")).Click();
            defaultWait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/main/table/tbody/tr[1]/td[1]/div[2]/a")));
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/main/table/tbody/tr[1]/td[1]/div[2]/a")).Click();






            Console.WriteLine("About to wait...");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Console.WriteLine("Finished waiting.");
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
            else
            {
                Console.WriteLine("ONE OR LESS HANDLES EXIST");
            }
        }
 

        private void HandlePopup()
        {
            // TODO: Popup logic
        }

        public void ScrapePortfolio2()
        {
            using (IWebDriver driver = new ChromeDriver())
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

                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                defaultWait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[2]/div/form/input[7]")));
                IWebElement passwordLogin = driver.FindElement(By.XPath("//*[@id=\"login-passwd\"]"));
                passwordLogin.SendKeys("thisisnew1234");
                driver.FindElement(By.Id("login-signin")).Click();

            }
        }
    }
}
