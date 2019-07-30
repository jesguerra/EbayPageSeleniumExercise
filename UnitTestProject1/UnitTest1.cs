using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.Test;

namespace UnitTestProject1
{
    [TestClass]
    public  class UnitTest1
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void UserNavigateEbayStore(){

            Environment environment = new Environment(driver);
            environment.LaunchUrl();
            environment.CapabilitiesWindow();
            NavigateEbayStore navigateEbayStore = new NavigateEbayStore(driver);
            navigateEbayStore.UserSearchProduct();
            navigateEbayStore.UserSelectProduct(navigateEbayStore.Size="10");
            navigateEbayStore.UserValidateTextResults();
            navigateEbayStore.UserOrderByAscendantResults();
            navigateEbayStore.UserValidateFirstFiveResults();
            navigateEbayStore.UserValidateFirstFivePrices();
            navigateEbayStore.UserOrderByNameProducts();
            navigateEbayStore.UserOrderByDescendantPrice();
            environment.CloseDriver();
            environment.QuitDriver();
        }
    }
}
