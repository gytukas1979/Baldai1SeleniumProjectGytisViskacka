using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baldai1SeleniumProjectGytisViskacka.Drivers;
using Baldai1SeleniumProjectGytisViskacka.Page;
using Baldai1.Test;

namespace Baldai1SeleniumProjectGytisViskacka.Page
{
    public class CartPage : BasePage
    {
        private const string PageAddress = "https://www.baldai1.lt/cart/";
        private const string ExpectedResultOfEmptyBasket = "Jūsų krepšelis yra tuščias";
        private IWebElement ButtonIsvalytiKrepseli => Driver.FindElement(By.CssSelector("#tygh_main_container > div.tygh-content.clearfix > div > div:nth-child(2) > div > div > div > div.buttons-container.ty-cart-content__bottom-buttons.clearfix > div.ty-float-left.ty-cart-content__left-buttons > a.ty-btn.ty-btn__tertiary.text-button"));
        private IWebElement TextOfEmptyBasket => Driver.FindElement(By.CssSelector("#tygh_main_container > div.tygh-content.clearfix > div > div:nth-child(2) > div > div > div > p"));
        
        public CartPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public CartPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public CartPage RemoveAllProductsFromBasket()
        {
            ButtonIsvalytiKrepseli.Click();
            return this;
        }
        public CartPage CheckIfBasketIsEmpty()
        {
            Assert.AreEqual(ExpectedResultOfEmptyBasket, TextOfEmptyBasket.Text, "Basket is not empty");
            return this;
        }
    }
}
