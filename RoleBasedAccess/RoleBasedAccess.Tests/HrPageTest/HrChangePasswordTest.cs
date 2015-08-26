using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace RoleBasedAccess.Tests.HrPageTest
{
    [TestClass]
    public class HrChangePasswordTest
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
        private void Logout(IWebDriver driver)
        {
            driver.FindElement(By.Id("MainContent_LinkButton1")).Click();
        }

        [TestMethod]
        public void HrChangePasswordUnsuccessfulTest()
        {

            IWebDriver driver = HrLogin();
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_LinkButton1")).Click();

            driver.FindElement(By.Id("FeaturedContent_TextBoxOldPassword")).SendKeys("BadOldPassword");
            driver.FindElement(By.Id("FeaturedContent_TextBoxNewPassword")).SendKeys("BadNewPassword");
            driver.FindElement(By.Id("FeaturedContent_TextBoxConformPassword")).SendKeys("BadNewPassword");

            driver.FindElement(By.Id("FeaturedContent_ButtonSubmitChangePassword")).Click();
            try
            {
                Assert.AreEqual("Change Password Failed.", driver.FindElement(By.Id("FeaturedContent_LabelChangePassword")).Text);
            }
            finally
            {
                Logout(driver);
            }
        }
        [TestMethod]
        public void HrChangePasswordSuccessfulTest()
        {

            IWebDriver driver = HrLogin();
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_LinkButton1")).Click();

            driver.FindElement(By.Id("FeaturedContent_TextBoxOldPassword")).SendKeys("amar");
            driver.FindElement(By.Id("FeaturedContent_TextBoxNewPassword")).SendKeys("amar");
            driver.FindElement(By.Id("FeaturedContent_TextBoxConformPassword")).SendKeys("amar");

            driver.FindElement(By.Id("FeaturedContent_ButtonSubmitChangePassword")).Click();
            try
            {
                Assert.AreEqual("Password Changed Succesfully.", driver.FindElement(By.Id("FeaturedContent_LabelChangePassword")).Text);
            }
            finally
            {
                Logout(driver);
            }
        }
    }
}
