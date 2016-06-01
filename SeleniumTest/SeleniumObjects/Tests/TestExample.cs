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
        public void ExecuteAutomationSeleniumTest()
        {
            page.Login.LoginToPage("TestUser","password");
            page.UserForm.SetNewUser("Mr.","QA","Tomica","Ambruš",false,"hindi");
        }

        [TestMethod]
        public void TestDietMenuGenerator()
        {
            page.DietMenuGenerator.NavigateTo();
            page.DietMenuGenerator.GenerateMyDiet("10 x Double Cheeseburgers", "I don't wan't to be on diet!", 5, "Tomo", "Tomić", "tom@mail.com");
        }
    }
}
