using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace SeleniumObjects.Controls
{
    public class WebRadioGroupElement
    {
        private IWebElement innerElement;
        private string tag;
        private static readonly StringComparer DefaultComparer = StringComparer.InvariantCultureIgnoreCase;
        private static readonly string[] Checked = new[] { "true", "checked" };

        /// <summary>
        /// Initializes a custom web element control WebRadioGroupElement, element param must be radio group container, optionsTag can be <input>.
        /// </summary>
        public WebRadioGroupElement(IWebElement element, string optionsTag)
        {
            innerElement = element;
            tag = optionsTag;
        }

        private List<IWebElement> radioOptionsList
        {
            get
            {
                var elements = innerElement.FindElements(By.TagName(tag));
                return elements.ToList<IWebElement>();
            }
        }

        /// <summary>
        /// Determines whether this radio option is checked.
        /// </summary>
        private static bool IsChecked(IWebElement element)
        {
            var attribute = element.GetAttribute("checked");
            return Checked.Contains(attribute, DefaultComparer);
        }

        /// <summary>
        /// Set radio option checked.
        /// </summary>
        private static void SetChecked(IWebElement element)
        {
            if (!IsChecked(element))
            {
                element.Click();
            }
        }

        /// <summary>
        /// Set radio option unchecked.
        /// </summary>
        private static void SetUnchecked(IWebElement element)
        {
            if (IsChecked(element))
            {
                element.Click();
            }
        }

        /// <summary>
        /// Select the option in radio group by text value.
        /// </summary>
        public void SelectOptionByText(string text)
        {
            IWebElement option;
            try
            {
                option = radioOptionsList.Where(x => x.Text == text).First();
                SetChecked(option);
            }
            catch (Exception)
            {
                throw new Exception("Option with " + text + " text value doesn't exist!");
            }
        }

        public void SelectOptionById(string id) 
        {
            IWebElement option;
            try
            {
                option = radioOptionsList.Where(x => x.GetAttribute("id") == id).First();
                SetChecked(option);
            }
            catch (Exception)
            {
                throw new Exception("Option with " + id + " attribute id value doesn't exist!");
            }
        }

        public void SelectOptionByName(string name) 
        {
            IWebElement option;
            try
            {
                option = radioOptionsList.Where(x => x.GetAttribute("name") == name).First();
                SetChecked(option);
            }
            catch (Exception)
            {
                throw new Exception("Option with " + name + " attribute name value doesn't exist!");
            }
        }

        public void SelectOptionByIndex(int index)
        {
            IWebElement option;
            try
            {
                option = radioOptionsList[index];
                SetChecked(option);
            }
            catch (Exception)
            {
                throw new Exception("Option on " + index + " position doesn't exist!");
            }
        }

    }
}
