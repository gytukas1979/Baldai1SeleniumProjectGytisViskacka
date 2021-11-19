using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baldai1SeleniumProjectGytisViskacka.Page
{
    public class Baldai1Page : BasePage
    {
        private const string PageAddress = "https://www.baldai1.lt/";
        private const string ExpectedLoginResult = "Jūs sėkmingai prisijungėte.";

        private IWebElement PopUp => Driver.FindElement(By.ClassName("np_cookie-np-button"));
        private IWebElement ManoBaldaiDropdown => Driver.FindElement(By.Id("sw_dropdown_609"));
        private IWebElement KrepselisDropdown => Driver.FindElement(By.Id("sw_dropdown_610"));
        private IWebElement ButtonKrepselioPerziura => Driver.FindElement(By.LinkText("Krepšelio peržiūra"));
        private IWebElement ButtonPrisijungtiToLoginForm => Driver.FindElement(By.CssSelector("#account_info_609 > div > a.ty-btn.ty-btn__primary"));
        private IWebElement ButtonAtsijungtiLogOut => Driver.FindElement(By.LinkText("Atsijungti"));
        private IWebElement NotificationOfLogin => Driver.FindElement(By.CssSelector(".cm-notification-content"));
        private IWebElement ProductSearchInputFilter => Driver.FindElement(By.Id("search_input"));
        private IWebElement SearchedPageWithFilter => Driver.FindElement(By.CssSelector(".snize-overhidden"));
        private IWebElement ReturnedProductCode => Driver.FindElement(By.CssSelector(".ty-product-block-title"));
        private IWebElement ButtonIKrepseli => Driver.FindElement(By.CssSelector(".ty-btn__primary.ty-btn__big.ty-btn__add-to-cart.cm-form-dialog-closer.ty-btn"));
        private IWebElement ButtonTestiApsipirkima => Driver.FindElement(By.LinkText("Tęsti apsipirkimą"));
        private IWebElement NumberOfProductsInCartText => Driver.FindElement(By.ClassName("ty-minicart__amount"));

        public Baldai1Page(IWebDriver webdriver) : base(webdriver)
        {}

        public Baldai1Page NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public Baldai1Page ClosePopUp()
        {
            PopUp.Click();
            return this;
        }
        public Baldai1Page PutProductIntoCart(string productCode)
        {
            ProductSearch(productCode);
            ButtonIKrepseli.Click();
            ButtonTestiApsipirkima.Click();
            return this;
        }
        private void OpenManoBaldaiDropdown()
        {
            ManoBaldaiDropdown.Click();
        }

        private void OpenKrepselisDropdown()
        {
            KrepselisDropdown.Click();
        }
        private void CheckBasket()
        {
            ButtonKrepselioPerziura.Click();
        }

        public Baldai1Page GoToBasket()
        {
            OpenKrepselisDropdown();
            CheckBasket();
            return this;
        }

        public Baldai1Page OpenLoginForm()
        {
            OpenManoBaldaiDropdown();
            ButtonPrisijungtiToLoginForm.Click();
            return this;
        }

        public Baldai1Page PageLogOut()
        {
            OpenManoBaldaiDropdown();
            ButtonAtsijungtiLogOut.Click();
            return this;
        }

        public Baldai1Page ProductSearch(string productCode)
        {
            ProductSearchInputFilter.SendKeys(productCode);
            SearchedPageWithFilter.Click();
            return this;
        }

        public Baldai1Page CheckLoginResult()
        {
            Assert.IsTrue(NotificationOfLogin.Text.Contains(ExpectedLoginResult), "Login parameters are incorrect");
            return this;
        }


        public Baldai1Page CheckSearchReachResult(string expectedResult)
        {
            Assert.IsTrue(ReturnedProductCode.Text.Contains(expectedResult), "Returned incorrect product");
            return this;
        }
        public Baldai1Page CheckLogOutResult()
        {
            OpenManoBaldaiDropdown();
            Assert.AreEqual("Prisijungti", ButtonPrisijungtiToLoginForm.Text, "Logout wasn't succesfull");
            return this;
        }

        public Baldai1Page CheckProductCountResult(string expectedResult)
        {
            Assert.AreEqual(expectedResult, NumberOfProductsInCartText.Text, "Number of products in the cart is incorrect");
            return this;
        }
    }
}
