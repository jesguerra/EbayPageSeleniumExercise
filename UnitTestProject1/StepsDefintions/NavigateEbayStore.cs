using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UnitTestProject1.PageObject;
using UnitTestProject1.Utils;

namespace UnitTestProject1.Test
{
    public class NavigateEbayStore
    {
        IWebDriver driver { get; set; }
        WebDriverWait wait;
        private String size;
        private string orderBy;

        public NavigateEbayStore(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Size { get => size; set => size = value; }
        public string OrderBy { get => orderBy; set => orderBy = value; }

        public void UserSearchProduct()
        {
            EbayFrontPage navigatePageFront = new EbayFrontPage(driver);
            wait = new WebDriverWait(driver,TimeSpan.FromSeconds(navigatePageFront.WaitTime));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(navigatePageFront.ebayPanel));
            navigatePageFront.UserValidateTitlePage();
            navigatePageFront.UserSearchArcticle();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(navigatePageFront.resultsPanel));
        }
        public void UserSelectProduct(String Size)
        {
            EbayProductPage selectProduct = new EbayProductPage(driver);
            selectProduct.UserSelectSize(Size);
        }
        public void UserValidateTextResults()
        {
            EbayProductPage validateResults = new EbayProductPage(driver);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(validateResults.numberResult));
            String obtainResults = validateResults.UserOptainNumberResults();
            Console.WriteLine("the Results Obtain is : " + obtainResults);
        }
        public void UserOrderByAscendantResults()
        {
            EbayProductPage orderBy = new EbayProductPage(driver);
            orderBy.UserOrderBy(orderBy.AscendantPrice);
        }
        public void UserValidateFirstFiveResults()
        {
            UtilsActions userObtainFirstFiveResults = new UtilsActions(driver);
            userObtainFirstFiveResults.ValidateOrder();
        }
        public void UserValidateFirstFivePrices()
        {
            UtilsActions userObtainFirstFivePrices = new UtilsActions(driver);
            userObtainFirstFivePrices.ValidatePrice();
        }
        public void UserOrderByNameProducts()
        {
            UtilsActions userOrderByName = new UtilsActions(driver);
            EbayProductPage nameProductsList = new EbayProductPage(driver);
            userOrderByName.OrderNameProducts(nameProductsList.UserObtainOrderResults(),nameProductsList.OrderByNameText);
        }
        public void UserOrderByDescendantPrice()
        {
            UtilsActions userOrderByDescendantPrice = new UtilsActions(driver);
            EbayProductPage priceProductsList = new EbayProductPage(driver);
            userOrderByDescendantPrice.OrderPriceProducts(priceProductsList.UserObtainsFirstPriceResults(), priceProductsList.OrderByPriceText);
        }

    }
}
