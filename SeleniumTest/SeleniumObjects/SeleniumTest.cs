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
    [TestClass]
    public class SeleniumTest
    {
        protected TestContext testContextInstance = null;  

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;

            }
        }

        protected PageCollection page;
        protected IWebDriver driver;
        protected static NameValueCollection appSetings;
        protected static string environmentBrowser;
        protected string environmentUrl;

        public SeleniumTest()
        {
            appSetings = System.Configuration.ConfigurationManager.AppSettings;
            environmentBrowser = appSetings["Browser"];
            environmentUrl = appSetings["Url"];  
        }

        [TestInitialize()]
        public virtual void InitializeMyTest()
        {
            InitBrowser(environmentBrowser, environmentUrl);  //parametrize
        }

        protected void InitBrowser(string browser, string url)
        {
            switch (browser)
            {

                case "IE":
                    Console.WriteLine("Starting test in IE");
                    var optionsIE = new InternetExplorerOptions()
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    };
                    driver = new InternetExplorerDriver(optionsIE);
                    break;

                case "FF":
                    Console.WriteLine("Starting test in Firefox");
                    driver = new FirefoxDriver();
                    break;

                case "CH":
                    Console.WriteLine("Starting test in Chrome");
                    var optionsCH = new ChromeOptions();
                    optionsCH.AddArgument("--start-maximized");
                    optionsCH.AddArgument("--disable-popup-blocking");
                    driver = new ChromeDriver(optionsCH);
                    break;

                default:
                    Console.WriteLine("Browser not found");
                    break;
            }

            page = new PageCollection(driver);

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 10));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        [TestCleanup()]
        public void CleanupMyTest()
        {
            driver.Quit();
        }

        protected void TakeScreenshot()  
        {
            //implement
        }

    }
}
