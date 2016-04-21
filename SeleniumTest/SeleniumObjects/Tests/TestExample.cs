using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumObjects.Tests
{
    [TestClass]
    public class TestExample: SeleniumTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            page.Login.LoginToPage("TestUser","password");
        }
    }
}
