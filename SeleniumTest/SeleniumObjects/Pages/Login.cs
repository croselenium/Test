using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumObjects.Pages
{
    public class Login: SeleniumPage
    {
        public Login(IWebDriver driver)
            : base(driver)
        {
        }
        
        private IWebElement txtUserName 
        {
            get
            {
                return _driver.FindElement(By.Name("UserName"));
            } 
        }
        
        private IWebElement txtPassword 
        {
            get
            {
                return _driver.FindElement(By.Name("Password"));
            } 
        }

        private IWebElement btnLogin 
        {
            get 
            {
                return _driver.FindElement(By.TagName("form")).FindElement(By.Name("Login"));
            } 
        }

        public void LoginToPage(string userName, string password)
        {
            //txtUserName.SendKeys(userName);
            txtUserName.SetText(userName);  //extension method
            txtPassword.SendKeys(password);
            btnLogin.Click();
        }
         
    }
}
