using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObject
{
    public class EbayFrontPage
    {
        IWebDriver Driver { get; set;}

        public EbayFrontPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public By ebayPanel = By.XPath(ebayBanner);
        public By searchField = By.XPath(ebaySearch);
        public By searchButton = By.XPath(ebaySearchButton);
        public By resultsPanel = By.Id(resultsControl);
        public By selectSize = By.XPath(sizeCheckBox);

        private static string url = "https://www.ebay.com";
        private static string ebayBanner = "//a[contains(text(),'Logotipo de eBay')]";
        private static string ebaySearch = "//input[@class='gh-tb ui-autocomplete-input']";
        private static string textShoes = "puma";
        private static string expectTitlePage = "Logotipo de eBay";
        private static string ebaySearchButton = "//input[@class='btn btn-prim gh-spr']";
        private static string resultsControl = "mainContent";
        private static string sizeCheckBox = "//span[text()='8']";
        private static long waitTime = 20;

        public string EbayBanner { get => ebayBanner; set => ebayBanner = value; }
        public long WaitTime { get => waitTime; set => waitTime = value; }
        public string Url { get => url; set => url = value; }

        public void UserValidateTitlePage()
        {
            String validateText = Driver.FindElement(ebayPanel).GetAttribute("text");
            Assert.AreEqual(expectTitlePage, validateText);
        }

        public void UserSearchArcticle()
        {
            IWebElement inputSearch = Driver.FindElement(searchField);
            inputSearch.SendKeys(textShoes);
            Driver.FindElement(searchButton).Click();
        }
    }
}

