using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace RoleBasedAccess.Tests
{
    [TestClass]
    public class LoginPageTest
    {
        private void Logout(IWebDriver driver)
        {
            driver.FindElement(By.Id("MainContent_LinkButton1")).Click();
        }
        [TestMethod]
        public void LoginUnsuccessfulTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:49909/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UsernameTextbox")).SendKeys("Bad Username");
            driver.FindElement(By.Id("MainContent_LoginUserControl_PasswordTextbox")).SendKeys("Bad Password");
            driver.FindElement(By.Id("MainContent_LoginUserControl_LoginButton")).Click();
            try
            {
                Assert.AreEqual("Login Failed.", driver.FindElement(By.Id("MainContent_LoginUserControl_LabelLoginState")).Text);
            }
            catch { }
        }

        [TestMethod]
        public void EmployeeLoginSuccessfulTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:49909/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UsernameTextbox")).SendKeys("www@gmail.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl_PasswordTextbox")).SendKeys("Deepak");
            driver.FindElement(By.Id("MainContent_LoginUserControl_LoginButton")).Click();
            try
            {
                Assert.AreEqual("Employee Page - My ASP.NET Application", driver.Title);
            }
            finally
            {
                Logout(driver);
            }
        }

        [TestMethod]
        public void HrLoginSuccessfulTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(2000));
            driver.Navigate().GoToUrl("http://localhost:49909/Login.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UsernameTextbox")).SendKeys("apalsapure@tavisca.com");
            driver.FindElement(By.Id("MainContent_LoginUserControl_PasswordTextbox")).SendKeys("amar");
            driver.FindElement(By.Id("MainContent_LoginUserControl_LoginButton")).Click();
            try
            {
                Assert.AreEqual("Add Employee - My ASP.NET Application", driver.Title);
            }
            finally
            {
                Logout(driver);
            }
        }
    }
}
