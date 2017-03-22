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
            IWebDriver webDriver = new ChromeDriver();
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var url = "http://www.alo.bg/searchq/?q=%D0%B8%D0%BC%D0%BE%D1%82%D0%B8+%D0%BF%D0%BE%D0%B4+%D0%BD%D0%B0%D0%B5%D0%BC";
            webDriver.Navigate().GoToUrl(url);

            // Wait until #main_listing is visible or 10 seconds.
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#main_lsting")));
            IWebElement offersContainer = webDriver.FindElement(By.CssSelector("#main_lsting"));

            var aTags = offersContainer.FindElements(By.TagName("a"));

            // Put all the links in a list.
            List<String> linksList = new List<String>();
            foreach (IWebElement aTag in aTags)
            {
                linksList.Add(aTag.GetAttribute("href"));
            }

            var linksCount = linksList.Count;

            // Remove the duplicating links and break when the index is out of range.
            for (int i = 0; i < linksCount; i++)
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
            foreach (String listElement in linksList)
            {
                Console.WriteLine(listElement);
            }
        }
    }
}
