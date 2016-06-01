using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumObjects
{
    public class PageCollection
    {
        IWebDriver _driver;

        public PageCollection(IWebDriver driver)
        {
            _driver = driver;
        }

        public Pages.Login Login
        {
            get
            {
                return new Pages.Login(_driver);
            }
        }

        public Pages.UserForm UserForm
        {
            get
            {
                return new Pages.UserForm(_driver);
            }
        }

        public Pages.DietMenuGenerator DietMenuGenerator
        {
            get
            {
                return new Pages.DietMenuGenerator(_driver);
            }
        }

    }
}
