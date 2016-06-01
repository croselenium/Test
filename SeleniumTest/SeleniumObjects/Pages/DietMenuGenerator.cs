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
    public class DietMenuGenerator: SeleniumPage
    {
        protected internal IWebElement element;

        public DietMenuGenerator(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {
            base.NavigateTo("http://automatetheplanet.com/healthy-diet-menu-generator");
        }

        #region ELEMENTS

        private WebRadioGroupElement radiogroupCoffees
        {
            get
            {
                element = _driver.FindElementEx(By.Id("ninja_forms_field_19_options_span"));
                return new WebRadioGroupElement(element, "input");
            }
        }

        private WebDropDownElement dropdownBurgers
        {
            get
            {
                element = _driver.FindElementEx(By.Id("ninja_forms_field_21"));
                return new WebDropDownElement(element, "option");
            }
        }

        private WebRadioGroupElement checkboxHealthyDessert
        {
            get
            {
                element = _driver.FindElementEx(By.Id("ninja_forms_field_27_options_span"));
                return new WebRadioGroupElement(element, "input");
            }
        }

        private IWebElement txtDietComments
        {
            get
            {
                return _driver.FindElementEx(By.Id("ninja_forms_field_22"));
            }
        }

        private WebDropDownElement optionsRockStarLevel
        {
            get
            {
                element = _driver.FindElementEx(By.Id("ninja_forms_field_20_div_wrap"));
                return new WebDropDownElement(element, "a");
            }
        }

        private IWebElement txtFirstName
        {
            get
            {
                return _driver.FindElementEx(By.Id("ninja_forms_field_23"));
            }
        }

        private IWebElement txtLastName
        {
            get
            {
                return _driver.FindElementEx(By.Id("ninja_forms_field_24"));
            }
        }

        private IWebElement txtEmail
        {
            get
            {
                return _driver.FindElementEx(By.Id("ninja_forms_field_25"));
            }
        }

        private IWebElement btnGenerateDietMenu
        {
            get
            {
                return _driver.FindElementEx(By.Id("ninja_forms_field_28"));
                //return _driver.FindElementEx(By.Id("nothing"));  //to test visibility of element
            }
        }

        #endregion

        #region METHODS

        private void SelectCoffeesPerDayByIndex(int index)
        {
            radiogroupCoffees.SelectOptionByIndex(index);
        }

        public void Select5VentiCoffees()
        {
            SelectCoffeesPerDayByIndex(1);
        }

        public void SelectBurgersPerDay(string burgers)
        {
            dropdownBurgers.SelectOptionByValue(burgers);
        }

        private void SelectHealthyDessertByIndex(int index)
        {
            checkboxHealthyDessert.SelectOptionByIndex(index);
        }

        public void SelectNewYorkCheesecake()
        {
            SelectHealthyDessertByIndex(1);
        }

        public void SetDietComments(string comments)
        {
            txtDietComments.SetText(comments);
        }

        public void CancelRockStarLevel()
        {
            optionsRockStarLevel.SelectOptionByIndex(0);
        }

        public void SetRockStarLevel(int index)
        {
            optionsRockStarLevel.SelectOptionByIndex(index);
        }

        public void SetFirstName(string firstName)
        {
            txtFirstName.SetText(firstName);
        }

        public void SetLastName(string lastName)
        {
            txtLastName.SetText(lastName);
        }

        public void SetEmail(string email)
        {
            txtEmail.SetText(email);
        }

        public void GenerateDietMenu()
        {
            btnGenerateDietMenu.Click();
        }

        public void GenerateMyDiet(string burgers, string comments, int level, string firstName, string lastName, string email)
        {
            Select5VentiCoffees();
            SelectBurgersPerDay(burgers);
            SelectNewYorkCheesecake();
            SetDietComments(comments);
            SetRockStarLevel(level);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            GenerateDietMenu();
        }

        #endregion
    }
}
