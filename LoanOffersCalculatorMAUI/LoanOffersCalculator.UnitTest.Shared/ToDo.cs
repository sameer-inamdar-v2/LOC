using LoanOffersCalculator.UnitTest.Shared.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LoanOffersCalculator.UnitTest.Shared
{
    public class ToDo : BaseTest
    {
        public void OpenTodoPage()
        {
            ButtonClick("NavMenuAutoTodo");
        }

        public void AddToDo()
        {
            GetInputElementAndInsertData("AddItemAutoTodoName", "Random Value1");
            ButtonClick("AddItemAutoTodoSubmit");

            var elementPage = App.FindElements(By.XPath("//*"));
            var okElement = elementPage.Where(e => e.Text == "OK").FirstOrDefault();
            okElement?.Click();
            Task.Delay(500).Wait();

            elementPage = App.FindElements(By.XPath("//*"));
            var randomElement = elementPage.Where(e => e.Text == "Random Value1").FirstOrDefault();
            randomElement?.Click();

            Assert.AreEqual("Random Value1", randomElement?.Text);
        }

        public void RemoveToDo()
        {
            ButtonClick("HomeNavLink");
            OpenTodoPage();

			var deleteBtnElements = FindUIElement("Random Value1");
            deleteBtnElements.Click();

            Task.Delay(500).Wait();
            var deleteBtnElement = FindUIElement("Random Value1");
            Assert.True(deleteBtnElement == null);


        }

    }
}
