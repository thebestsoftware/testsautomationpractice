using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WebDriverMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //RemoteWebDriver Driver = new InternetExplorerDriver();
            RemoteWebDriver Driver = new InternetExplorerDriver();
            //Driver.Url = "www.football.ua";
            Driver.Navigate().GoToUrl(@"http://en.wikipedia.org/");
            //Driver.Manage().Window.Maximize();

            var lnkSupportUs = Driver.FindElementByCssSelector(@"a[title = 'Support us']");
            lnkSupportUs.Click();

            // Cannot find with this locator!
            var radio50UAH = Driver.FindElementByXPath("/html/body/div[3]/div[2]/div[3]/table/tbody/tr/td[2]/form/div/div[3]/table/tbody/tr[1]/td[1]/label");//Driver.FindElementById("input_amount_0");// Driver.FindElementByCssSelector(@"#input_amount_0[value='50']");
            radio50UAH.Click();

            var btnDonate = Driver.FindElement(By.ClassName("payment-method-button"));
            btnDonate.Click();

            var txtFirstName = Driver.FindElementById("fname");
            var txtlastName = Driver.FindElementById("lname");
            var txtEmail = Driver.FindElementById("emailAdd");
            var radioCardType = Driver.FindElementById("cc-visa");

            txtFirstName.Clear();
            txtFirstName.SendKeys("Vasya");

            txtlastName.Clear();
            txtlastName.SendKeys("Poopkin");

            txtEmail.Clear();
            txtEmail.SendKeys("test@example.com");

            radioCardType.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(6));

            var txtCreditCardNum = Driver.FindElementByName("CREDITCARDNU");
            var selectExpMonth = new SelectElement(Driver.FindElementById("F1010_MM"));
            var selectExpYear = new SelectElement(Driver.FindElementById("F1010_YY"));
            var txtCVV = Driver.FindElementById(@"F1136");
            var btnSubmit = Driver.FindElementById(@"btnSubmit");

            txtCreditCardNum.Clear();
            txtCreditCardNum.SendKeys("8975397698238467");

            selectExpMonth.SelectByText("02");
            selectExpYear.SelectByText("15");

            txtCVV.Clear();
            txtCVV.SendKeys("836");

            btnSubmit.SendKeys(Keys.Enter);

            Driver.SwitchTo().DefaultContent();

            // On Donate results page

            string headerSelector = @"h1.firstHeading";
            var headingElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(headerSelector)));

            Assert.AreEqual("Donate-error", headingElement.Text);

            Driver.Quit();
            Driver.Dispose();
        }
    }
}
