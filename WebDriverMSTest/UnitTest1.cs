using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
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
            txtFirstName.SendKeys("V");

            txtlastName.Clear();
            txtlastName.SendKeys("P");

            txtEmail.Clear();
            txtEmail.SendKeys("a@b.com");

            radioCardType.Click();
        }
    }
}
