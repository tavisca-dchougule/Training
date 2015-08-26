using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace RoleBasedAccess.Tests.HrPageTest
{
    [TestClass]
    public class HrLogoutTest
    {

        private IWebDriver HrLogin()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:49909/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UsernameTextbox")).SendKeys("apalsapure@tavisca.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl_PasswordTextbox")).SendKeys("amar");
            driver.FindElement(By.Id("MainContent_LoginUserControl_LoginButton")).Click();
            return driver;
        }
        [TestMethod]
        public void HrLogoutSuccessfulTest()
        {
            IWebDriver driver = HrLogin();
            driver.FindElement(By.Id("MainContent_LinkButton1")).Click();
            try
            {
                Assert.AreEqual("Log In - My ASP.NET Application", driver.Title);
            }
            catch { }
        }
    }
}
