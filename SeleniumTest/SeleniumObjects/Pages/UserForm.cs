using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumObjects.Controls;

namespace SeleniumObjects.Pages
{
    public class UserForm: SeleniumPage
    {
        protected internal IWebElement element;

        public UserForm(IWebDriver driver)
            : base(driver)
        {
            Connect();
        }

        public void Connect()
        {
            base.Connect("demosite/index.html");
        }

        #region ELEMENTS

        private IWebElement txtInitial
        {
            get
            {
                return _driver.FindElementEx(By.Id("Initial"));
            }
        }

        private IWebElement txtFirstName
        {
            get
            {
                return _driver.FindElementEx(By.Id("FirstName"));
            }
        }

        private IWebElement txtMiddleName
        {
            get
            {
                return _driver.FindElementEx(By.Id("MiddleName"));
            }
        }

        private WebDropDownElement checkboxLanguages
        {
            get
            {
                element = _driver.FindElementEx(By.Name("english")).GetParent();
                return new WebDropDownElement(element, "input");  
            }
        }

        private WebRadioGroupElement radiogroupGender
        {
            get
            {
                element = _driver.FindElementEx(By.Name("Male")).GetParent();
                return new WebRadioGroupElement(element, "input");  
            }
        }

        private WebDropDownElement dropdownTitle
        {
            get
            {
                element = _driver.FindElementEx(By.Id("TitleId"));
                return new WebDropDownElement(element, "option");
            }
        }

        private IWebElement btnSave
        {
            get
            {
                return _driver.FindElementEx(By.Name("Save"));
            }
        } 

        #endregion

        #region METHODS

        public void SetInitial(string initial)
        {
            txtInitial.SetText(initial);
        }

        public void SetFirstName(string firstName)
        {
            txtFirstName.SetText(firstName);
        }

        public void setMiddleName(string middleName)
        {
            txtMiddleName.SetText(middleName);
        }

        /// <summary>
        /// Select the gender, if "true" then Male else Female.
        /// </summary>
        public void SelectGender(bool gender)
        {
            if (gender) 
            {
                radiogroupGender.SelectOptionByName("Male");
            }
            else
            {
                radiogroupGender.SelectOptionByName("Female");
            }
        }

        public void SelectTitle(string title)
        {
            dropdownTitle.SelectOptionByText(title);
        }

        public void SelectLanguage(string language)
        {
            checkboxLanguages.SelectOptionByValue(language);
        }

        public void SaveForm()
        {
            btnSave.Click();
        }

        public void SetNewUser(string title, string initial, string firstName, string middleName, bool gender, string language)
        {
            SelectTitle(title);
            SetInitial(initial);
            SetFirstName(firstName);
            setMiddleName(middleName);
            SelectGender(gender);
            SelectLanguage(language);
            SaveForm();
        }

        #endregion
    }
}
