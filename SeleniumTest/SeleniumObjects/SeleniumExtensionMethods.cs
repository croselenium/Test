using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;
using OpenQA.Selenium.Internal;

namespace SeleniumObjects
{
    static class SeleniumExtensionMethods
    {
        public static class Config
        {
            public static readonly TimeSpan ImplicitWait = new TimeSpan(0, 0, 0, 10);
            public static readonly TimeSpan NoWait = new TimeSpan(0, 0, 0, 0);
        }

        /// <summary>
        /// Get the text of text element.
        /// </summary>
        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        /// <summary>
        /// Get the text from dropdown element.
        /// </summary>
        public static string GetTextFromDDL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }

        /// <summary>
        /// Set the value to text element.
        /// </summary>
        public static void SetText(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
            if (element.GetText() != value)
            {
                throw new Exception("Element " + element.ToString() + " doesn't contain value: " + value);
            }
        }
        
        /// <summary>
        /// Get the parent of element.
        /// </summary>
        public static IWebElement GetParent(this IWebElement element)
        {
            return element.FindElement(By.XPath(".."));
        }

        /// <summary>
        /// Highlights the element for int "seconds".
        /// </summary>
        private static void HighlightElement(this IWebElement element, int miliseconds)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "background: yellow;");
            System.Threading.Thread.Sleep(miliseconds);
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "");
        }

        /// <summary>
        /// Check if element is displayed on page.
        /// </summary>
        public static bool ElementIsPresent(this IWebDriver driver, By by)
        {
            var present = false;
            driver.Manage().Timeouts().ImplicitlyWait(Config.NoWait);
            try
            {
                present = driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
            }
            driver.Manage().Timeouts().ImplicitlyWait(Config.ImplicitWait);
            return present;
        }

        /// <summary>
        /// Check if element exist on page, wait implicitWait seconds.
        /// </summary>
        public static bool ElementExists(this IWebDriver driver, By by, Int32 implicitWait = 10)
        {
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, implicitWait));
            var elements = driver.FindElements(by);
            var visibleElements = elements.Count(e => e.Displayed);
            return visibleElements != 0;
        }

        /// <summary>
        /// Extended driver.FindElement method
        /// </summary>
        public static IWebElement FindElementEx(this IWebDriver driver, By by)
        {
            int wait = 10;
            if (driver.ElementExists(by, wait))
            {
                //driver.FindElement(by).HighlightElement(100);
                return driver.FindElement(by);
            }
            throw new Exception("Element " + by.ToString() + " not found after " + wait.ToString() + " seconds!");
        }

        /// <summary>
        /// Takes the screenshot, add prefix to filename.
        /// </summary>
        public static string TakeScreenshot(this IWebDriver driver, string prefix = "")
        {
            var fileName = String.Format("{0}{1}{2}", prefix, DateTime.Now.ToString("HHmmss"), ".png");
            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            screenShot.SaveAsFile(fileName, ImageFormat.Png);
            return fileName;
        }
    }
}
