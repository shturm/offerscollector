using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OffersCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver chromeDriver = new ChromeDriver();
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            var url = "http://www.alo.bg/searchq/?q=%D0%B8%D0%BC%D0%BE%D1%82%D0%B8+%D0%BF%D0%BE%D0%B4+%D0%BD%D0%B0%D0%B5%D0%BC";
            chromeDriver.Navigate().GoToUrl(url);

            // Wait until "#main_listing" is visible or 10 seconds.
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#main_lsting")));
            IWebElement offersContainer = chromeDriver.FindElement(By.CssSelector("#main_lsting"));

            var links = offersContainer.FindElements(By.TagName("a"));

            // Put all the links in a list.
            List<String> linksList = new List<String>();
            foreach (IWebElement link in links)
            {
                linksList.Add(link.GetAttribute("href"));
            }

            // Remove the duplicating links and break when the index is out of range.
            for (int i = 0; i < linksList.Count; i++)
            {
                try
                {
                    if (linksList.ElementAt(i).Equals(linksList.ElementAt(i + 1)))
                    {
                        linksList.RemoveAt(i + 1);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
            }

            // Print the links.
            foreach (String link in linksList)
            {
                Console.WriteLine(link);
            }

            // Clear the list with the links.
            linksList.Clear();

            url = "http://imoti.bg/bg/adv/type:/oblast:sofiq/city:/offer_id:ID/budget:%D0%A6%D0%B5%D0%BD%D0%B0%20%D0%B4%D0%BE/currency:EUR/action:sell";
            chromeDriver.Navigate().GoToUrl(url);

            // Wait until "listAdv" is visible or 10 seconds.
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("listAdv")));
            offersContainer = chromeDriver.FindElement(By.ClassName("listAdv"));
            links = offersContainer.FindElements(By.TagName("a"));

            // Put all the links in a list.
            foreach (IWebElement link in links)
            {
                if (link.GetAttribute("href").Contains("view:"))
                {
                    linksList.Add(link.GetAttribute("href"));
                }
            }

            // Print the links.
            foreach (String link in linksList)
            {
                Console.WriteLine(link);
            }
        }
    }
}
