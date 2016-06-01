using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace SeleniumObjects.Controls
{
    public class WebDropDownElement
    {
        private IWebElement innerElement;
        private string tag;  

        /// <summary>
        /// Initializes a custom web element control WebDropDownElement, element param must be dropdown container, optionsTag can be <option>.
        /// </summary>
        public WebDropDownElement(IWebElement element, string optionsTag)
        {

            innerElement = element;
            tag = optionsTag;
        }

        private List<IWebElement> dropDownList
        {
            get
            {
                var elements = innerElement.FindElements(By.TagName(tag));
                return elements.ToList<IWebElement>();
            }
        }

        public void SelectOptionByText(string text)
        {
            IWebElement option;
            try
            {
                option = dropDownList.Where(x => x.Text == text).First();
                option.Click();
            }
            catch (Exception)
            {
                throw new Exception("Option with " + text + " text value doesn't exist!");
            }
        }

        public void SelectOptionByIndex(int index)
        {
            IWebElement option;
            try
            {
                option = dropDownList[index];
                option.Click();
            }
            catch (Exception)
            {
                throw new Exception("Option on " + index + " position doesn't exist!");
            }
        }

        public void SelectOptionByValue(string value)
        {
            IWebElement option;
            try
            {
                option = dropDownList.Where(x => x.GetAttribute("value") == value).First();
                option.Click();
            }
            catch (Exception)
            {
                throw new Exception("Option with " + value + " attribute value value doesn't exist!");
            }
        }

        public string GetOptionTextByIndex(int index)
        {
            IWebElement option;
            try
            {
                option = dropDownList[index];
                return option.Text;
            }
            catch (Exception)
            {
                throw new Exception("Option on " + index + " position doesn't exist!");
            }
        }
    }
}
