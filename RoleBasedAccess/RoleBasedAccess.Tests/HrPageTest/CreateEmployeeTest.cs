using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace RoleBasedAccess.Tests.HrPageTest
{
    [TestClass]
    public class CreateEmployeeTest
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
        public void SuccessfulEmployeeCreationTest()
        {

            IWebDriver driver = HrLogin(); 
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxTitle")).SendKeys("Mr.");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxFirstName")).SendKeys("DemoEmployee");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxLastName")).SendKeys("DemoEmployee");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxEmail")).SendKeys("Demo5@email.com");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxDesignation")).SendKeys("Demo");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_ButtonEmpSubmit")).Click();
            try
            {
                Assert.AreEqual("Employee Created Succesfully.", driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_LabelCreateEmployee")).Text);
            }
            finally
            {
                Logout(driver);
            }
        }

        [TestMethod]
        public void EmailUniqueKeyCheckTest()
        {

            IWebDriver driver = HrLogin();
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxTitle")).SendKeys("Mr.");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxFirstName")).SendKeys("DemoEmployee");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxLastName")).SendKeys("DemoEmployee");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxEmail")).SendKeys("Demo@email.com");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_TextBoxDesignation")).SendKeys("Demo");
            driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_ButtonEmpSubmit")).Click();
            try
            {
                Assert.AreEqual("Employee Creation Failed.", driver.FindElement(By.Id("FeaturedContent_HRAddEmployeeTab_LabelCreateEmployee")).Text);
            }
            finally
            {
                Logout(driver);
            }
        }
    }
}
