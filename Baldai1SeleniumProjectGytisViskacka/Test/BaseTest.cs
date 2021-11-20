using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baldai1SeleniumProjectGytisViskacka.Drivers;
using Baldai1SeleniumProjectGytisViskacka.Page;
using Baldai1SeleniumProjectGytisViskacka.Tools;

namespace Baldai1.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static Baldai1Page _baldai1Page;
        public static LoginPage _loginPage;
        public static CartPage _cartPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _baldai1Page = new Baldai1Page(driver);
            _loginPage = new LoginPage(driver);
            _cartPage = new CartPage(driver);
        }

        [TearDown]

        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
