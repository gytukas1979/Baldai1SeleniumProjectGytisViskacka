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
    public class LoginPage : BasePage
    {
        private const string PageAddress = "https://www.baldai1.lt/login/?return_url=index.php";
        private IWebElement EmailAddressInput => Driver.FindElement(By.Id("login_main_login"));
        private IWebElement PasswordInput => Driver.FindElement(By.Id("psw_main_login"));
        private IWebElement ButtonPrisijungtiLoginToPage => Driver.FindElement(By.CssSelector("#tygh_main_container > div.tygh-content.clearfix > div > div:nth-child(2) > div.span8.main-content-grid > div > div > div > form > div.buttons-container.clearfix > div:nth-child(3) > button"));

        public LoginPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public LoginPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public LoginPage Login(string emailAddress, string password)
        {
            EmailAddressInput.SendKeys(emailAddress);
            PasswordInput.SendKeys(password);
            ButtonPrisijungtiLoginToPage.Click();
            return this;
        }
    }
}
