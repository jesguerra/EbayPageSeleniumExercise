using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject1.PageObject;

namespace UnitTestProject1.Utils
{
    class UtilsActions
    {
        IWebDriver Driver;

        public UtilsActions(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public void clickAndHold(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.ClickAndHold(element).Build().Perform();
        }

        public void ValidateOrder()
        {
            List<string> expectResultsList = new List<String>();
            expectResultsList.Add("Zapatos De Cuero rara VINTAGE PUMA especial 657, Alemania del Oeste, Azul Talla 10, NUEVO!!!");
            expectResultsList.Add("Puma Clyde X WWE \"dinero en el banco\" Colección maletín Limitada US talla 10 para hombre");
            expectResultsList.Add("Puma Clyde X WWE dinero en el Bank Oro tenis zapatos Limited 100 pares nuevo 10");
            expectResultsList.Add("Nuevo 2006 PUMA YO MTV RAPS CLYDE Zapatillas US 10 28.5cm mundo sólo 50 Rara");
            expectResultsList.Add("Puma Clyde X WWE dinero en los zapatos de oro Bank Edición Limitada 100 pares nuevo 10");

            EbayProductPage resultsList = new EbayProductPage(Driver);
            IList<string> fiveResults = new List<string>();
            fiveResults = resultsList.UserObtainOrderResults();

            for (var i = 0; i < fiveResults.Count; i++)
            {
                Assert.AreEqual(expectResultsList[i], fiveResults[i]);
                Console.WriteLine("Firts Five Puma Products : " + fiveResults[i]);
            }
        }
        public void ValidatePrice() {

            List<int> fivePriceResults = new List<int>();
            EbayProductPage resultsPriceList = new EbayProductPage(Driver);
            fivePriceResults = resultsPriceList.UserObtainsFirstPriceResults();

            foreach (var priceProduct in fivePriceResults)
            {
                Console.WriteLine("First Five Puma Prices : " + priceProduct);
            }
        }
        public void OrderNameProducts(List<String> products,String orderText)
        {
            List<String> orderName = new List<String>(products);
            List<String> orderAscendantName = new List<String>(orderName);
            orderAscendantName.Sort();

            foreach(String orderNameProducts in orderAscendantName)
            {
                Console.WriteLine(orderText + orderNameProducts);
            }
            
        }
        public void OrderPriceProducts(List<int> products, String orderText)
        {
            List<int> orderPrice = new List<int>(products);
            List<int> orderDescendantPrice = new List<int>(orderPrice);
            orderDescendantPrice.OrderByDescending(o=>o).ToList();

            foreach (int orderPriceProducts in orderDescendantPrice)
            {
                Console.WriteLine(orderText + orderPriceProducts);
            }
        }
    }
}
