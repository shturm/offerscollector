using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffersCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var url = "http://www.alo.bg/searchq/?q=%D0%B8%D0%BC%D0%BE%D1%82%D0%B8+%D0%BF%D0%BE%D0%B4+%D0%BD%D0%B0%D0%B5%D0%BC";
            driver.Navigate().GoToUrl(url);

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#main_lsting"))); // wait until #main_listing is visible or 10 seconds have passed
            IWebElement offersContainer = driver.FindElement(By.CssSelector("#main_lsting"));

            var aTags = offersContainer.FindElements(By.TagName("a"));

            foreach (IWebElement aTag in aTags)
            {
                Console.WriteLine(aTag.GetAttribute("href"));
            }

        }
    }
}
