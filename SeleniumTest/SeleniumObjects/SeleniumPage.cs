using System;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Selenium;

namespace SeleniumObjects
{
    public class SeleniumPage
    {
        protected internal IWebDriver _driver;
        protected static string parentWindowsHandler;

        internal SeleniumPage(IWebDriver driver)
        {
            _driver = driver;
        }

        protected internal string Connect(string url)
        {
            try
            {
                parentWindowsHandler = _driver.CurrentWindowHandle;
            }
            catch (Exception)
            {

            }
            for (int i = 0; i < 10; i++)
            {
                IWebDriver popup = null;
                var windowIterator = _driver.WindowHandles;

                foreach (var windowHandle in windowIterator)
                {
                    popup = _driver.SwitchTo().Window(windowHandle);

                    if (popup.Url.Contains(url))
                    {
                        return parentWindowsHandler;
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
            throw new Exception("Can't connect to screen after 10 seconds");
        }

        /// <summary>
        /// Navigates to URL that is not part of tested web page (not in app.config).
        /// </summary>
        protected internal string NavigateTo(string url)
        {
            if (_driver.Url != url)
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        _driver.Navigate().GoToUrl(url);

                        if (_driver.Url.Contains(url))
                        {
                            return _driver.CurrentWindowHandle;
                        }
                    }
                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception)
                {
                }   
            }
            throw new Exception("Can't connect to screen after 10 seconds");
        }
    }
}
