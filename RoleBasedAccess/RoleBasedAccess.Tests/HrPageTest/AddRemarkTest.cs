using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace RoleBasedAccess.Tests.HrPageTest
{
    [TestClass]
    public class AddRemarkTest
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
        public void AddRemarkSuccessTest()
        {

            IWebDriver driver = HrLogin();
            driver.FindElement(By.Id("AddRemark")).Click();
            SelectElement dropDownList = new SelectElement(driver.FindElement(By.Id("FeaturedContent_HRAddRemarkTab_DropDownListEmp")));
            dropDownList.SelectByIndex(2);

            driver.FindElement(By.Id("FeaturedContent_HRAddRemarkTab_TextBoxRemark")).SendKeys("DemoRemark");
            driver.FindElement(By.Id("FeaturedContent_HRAddRemarkTab_ButtonSubmitRemark")).Click();
            try
            {
                Assert.AreEqual("Remark Added Successfully.", driver.FindElement(By.Id("FeaturedContent_HRAddRemarkTab_LabelAddRemark")).Text);
            }
            finally
            {
                Logout(driver);
            }
        }
    }
}
