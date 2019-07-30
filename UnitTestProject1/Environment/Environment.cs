using OpenQA.Selenium;

namespace UnitTestProject1
{
    public class Environment : SeleniumCapabilities
    {
        private IWebDriver driver { get; set; }       
        private static string Url = "https://www.ebay.com";

        public Environment(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CloseDriver()
        {
            driver.Close();

        }

        public void LaunchUrl()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void CapabilitiesWindow()
        {
            driver.Manage().Window.Maximize();
        }

        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
