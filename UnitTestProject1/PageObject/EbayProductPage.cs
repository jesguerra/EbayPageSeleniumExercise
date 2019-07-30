using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using UnitTestProject1.Utils;

namespace UnitTestProject1.PageObject
{
    class EbayProductPage
    {
        IWebDriver driver { get; set; }
        WebDriverWait wait;

        public EbayProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By numberResult = By.XPath(resultsLabel);
        private static string resultsLabel = "//h1[@class='srp-controls__count-heading']";

        public By orderList = By.XPath(orderListElement);
        private static string orderListElement = "//button[@aria-labelledby='w7_btn_label']";

        public By filterResults = By.XPath(resultsElement);
        private static string resultsElement = "//h3[@class='s-item__title']";

        public By filterPriceResults = By.XPath(resultsPrice);
        private static string resultsPrice = "//span[@class='s-item__price']";

        private long waitTime = 1;

        private string ascendantPrice = "Precio + Envío: más alto primero";
        private String orderByNameText = "Order Name Products is : ";
        private String orderByPriceText = "Order Price Descendant mode is : ";

        public string AscendantPrice { get => ascendantPrice; set => ascendantPrice = value; }
        public string OrderByNameText { get => orderByNameText; set => orderByNameText = value; }
        public string OrderByPriceText { get => orderByPriceText; set => orderByPriceText = value; }

        public void UserSelectSize(String size)
        {
            string selectSizeElement = "//span[text()='" + size + "']";
            IWebElement inputSize = driver.FindElement(By.XPath(selectSizeElement));
            inputSize.Click();
        }

        public String UserOptainNumberResults()
        {
            IWebElement results = driver.FindElement(numberResult);
            string textResults = results.Text.Substring(0, 5);
            return textResults;
        }
        public void UserOrderBy(string orderOption)
        {
            string ascendantOrderElement = "//span[contains(text(),'" + orderOption + "')]";
            IWebElement orderListElement = driver.FindElement(orderList);
            UtilsActions displayList = new UtilsActions(driver);
            displayList.clickAndHold(orderListElement);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(ascendantOrderElement)));
            driver.FindElement(By.XPath(ascendantOrderElement)).Click();
        }
        public List<String> UserObtainOrderResults()
        {
            IList<IWebElement> firstResults = driver.FindElements(filterResults);
            List<String> fiveFirstResultsList = new List<string>();
            String resultsText = null;

            for (int i = 0; i < 5; i++)
            {
                resultsText =  firstResults [i].Text;
                fiveFirstResultsList.Add(resultsText);
            }
            return fiveFirstResultsList;
        }
        public List<int> UserObtainsFirstPriceResults()
        {
            IList<IWebElement> firstPriceResults = driver.FindElements(filterPriceResults);
            List<int> fiveFirstPriceResultsList = new List<int>();
            String resultsPriceText = null;

            for(int i = 0; i < 5; i++)
            {
                resultsPriceText = firstPriceResults[i].Text
                    .Replace("$", String.Empty)
                    .Replace("C", String.Empty)
                    .Replace("O", String.Empty)
                    .Replace("P", String.Empty)
                    .Replace(".", String.Empty)
                    .Replace(" ", String.Empty);
                                                            
                int result = Convert.ToInt32(resultsPriceText);
                fiveFirstPriceResultsList.Add(result);
            }
            return fiveFirstPriceResultsList;
        }
    }
}
