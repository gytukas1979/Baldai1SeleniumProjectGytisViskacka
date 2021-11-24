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

namespace Baldai1SeleniumProjectGytisViskacka.Test
{
    public class Baldai1Test : BaseTest
    {

        [Order(1)]
        [TestCase("email", "pass")]
        public void TestLoginToPage(string emailAddress, string password)
        {
            _baldai1Page.NavigateToDefaultPage()
                .ClosePopUp()
                .OpenLoginForm();
            _loginPage.Login(emailAddress, password);
            _baldai1Page.CheckLoginResult();
        }

        [Order(2)]
        [TestCase("NK278")]
        public void TestProductSearchWithInput(string productCode)
        {
            _baldai1Page.NavigateToDefaultPage()
                .ProductSearch(productCode)
                .CheckSearchReachResult(productCode);
        }

        [Order(3)]
        [TestCase("NK278", "MT615", "UL7", "3")]
        public void TestIfNumberOfProductsIsCorrectInTheCart(string firstProduct, string secondProduct, string thirdProduct, string expectedResult)
        {
            _baldai1Page.NavigateToDefaultPage()
                .PutProductIntoCart(firstProduct)
                .PutProductIntoCart(secondProduct)
                .PutProductIntoCart(thirdProduct)
                .CheckProductCountResult(expectedResult);
        }

        [Order(4)]
        [Test]
        public void TestIfBasketIsEmptyAfterCleanUp()
        {
            _baldai1Page.NavigateToDefaultPage()
                .GoToBasket();
            _cartPage.RemoveAllProductsFromBasket()
                .CheckIfBasketIsEmpty();
        }

        [Order(5)]
        [Test]
        public void TestLogOutOfPage()
        {
            _baldai1Page.NavigateToDefaultPage()
                .PageLogOut()
                .CheckLogOutResult();
        }
    }
}
