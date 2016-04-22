using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumObjects.Pages
{
    public class UserForm: SeleniumPage
    {
        public UserForm(IWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement dropdownTitle
        {
            get
            {
                return _driver.FindElement(By.Id("TitleId"));
            }
        }
    }
}
