using LoanOffersCalculator.UnitTest.Shared;
using LoanOffersCalculator.UnitTest.Shared.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanOffersCalculator.UnitTest.iOS
{
    internal class CalculatorTestCase : BaseTest
    {
        private Calculator cal;
        private OfferWizard offerWizard;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            cal = new Calculator();
            offerWizard = new OfferWizard();
        }

        [Test, Order(0)]
        public void OpenMenu()
        {
            var menuElement = FindUIElement("**/XCUIElementTypeButton[`name == \"Navigation menu\"`]");
            Actions actions = new(App);
            actions.Click(menuElement).Perform();
        }

        [Test, Order(1)]
        public void OpenCalculatorPage()
        {
            ButtonClick("**/XCUIElementTypeStaticText[`name == \"Calculators\"`]");
        }


        [Test, Order(2)]
        public void OpenCalculatorHomePage()
        {
            ButtonClick("**/XCUIElementTypeOther[`value == \"0\"`][1]");
        }

        [Test, Order(2)]
        public void NegativeTest()
        {
            GetInputElementAndInsertData("**/XCUIElementTypeTextField[`value == \"Enter Loan Amount\"`]", "-100");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Calculate EMI\"`]");
            var element = FindUIElement("**/XCUIElementTypeTextField[`value == \"-100\"`]");
            if(element != null)
                Assert.Fail();
            else
                Assert.Pass();
            
        }

        [Test, Order(3)]
        public void PreVerifyInputDetails()
        {
            var element = FindUIElement("**/XCUIElementTypeTextField[`value == \"-100\"`]");
            element?.Click();
            element?.Clear();
            GetInputElementAndInsertData("**/XCUIElementTypeTextField[`value == \"Enter Loan Amount\"`]", "1000");
            GetInputElementAndInsertData("**/XCUIElementTypeTextField[`value == \"ROI\"`]", "12");
            GetInputElementAndInsertData("**/XCUIElementTypeTextField[`value == \"Loan Tenure\"`]", "1");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Calculate EMI\"`]");
            //Assert.AreEqual(loanAmtElement.Text, "1000");
            //Assert.AreEqual(intRateElement.Text, "12");
            //Assert.AreEqual(loanTenElement.Text, "1");
        }

        [Test, Order(4)]
        public void VerifyLaonEmi()
        {
            var emiElement = FindUIElement("**/XCUIElementTypeOther[`name == \"article\"`]/XCUIElementTypeTextField[1]");
            Assert.IsTrue(string.Equals(emiElement.Text, "88") ||
                string.Equals(emiElement.Text, "88.85"));
        }

        [Test, Order(5)]
        public void VerifyIntrestPaid()
        {
            var intrestPaidElemet = FindUIElement("**/XCUIElementTypeOther[`name == \"article\"`]/XCUIElementTypeTextField[2]");
            Assert.IsTrue(string.Equals(intrestPaidElemet.Text, "66") ||
                string.Equals(intrestPaidElemet.Text, "66.19"));
        }

        [Test, Order(6)]
        public void VerifyTotalAmtPaid()
        {
            var totalAmtElement = FindUIElement("**/XCUIElementTypeOther[`name == \"article\"`]/XCUIElementTypeTextField[3]");
            Assert.IsTrue(string.Equals(totalAmtElement.Text, "1066") ||
                string.Equals(totalAmtElement.Text, "1066.19"));
        }

        [Test, Order(7)]
        public void OpenOfferWizardPage()
        {
            //Scroll("Need few details");
            //offerWizard.OpenOfferWizardPage();
            ButtonClick("**/XCUIElementTypeButton[`name == \"Need few details\"`]");
        }

        [Test, Order(8)]
        public void ChooseProperty()
        {
            //Scroll("Next");
            //offerWizard.ChooseProperty();
            ButtonClick("**/XCUIElementTypeOther[`value == \"0\"`][1]");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Next\"`]");
        }

        [Test, Order(9)]
        public void Price()
        {
            ButtonClick("**/XCUIElementTypeButton[`name == \"Next\"`]");
        }

        [Test, Order(10)]
        public void Employed()
        {
            ButtonClick("**/XCUIElementTypeOther[`name == \"Part-time\"`]");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Next\"`]");
        }

        [Test, Order(11)]
        public void Name()
        {
            GetInputElementAndInsertData("**/XCUIElementTypeTextField[`value == \"First name\"`]", "Arman");
            GetInputElementAndInsertData("**/XCUIElementTypeTextField[`value == \"Last name\"`]", "Shaikh");
            var elementPage = App.FindElements(By.XPath("//*"));
            var test = elementPage.Where(e => e.Text == "Next").ToList();
            foreach (var element in test)
            {
                if (element.Text == "Next")
                {
                    element.Click();
                }
            }
            GetInputElementAndInsertData("**/XCUIElementTypeTextField[`value == \"City...\"`]", "Mumbai");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Submit\"`]");
        }

        [Test, Order(12)]
        public void TestPersonal()
        {
            var menuElement = FindUIElement("**/XCUIElementTypeButton[`name == \"Navigation menu\"`]");
            Actions actions = new(App);
            actions.Click(menuElement).Perform();

            ButtonClick("**/XCUIElementTypeStaticText[`name == \"Calculators\"`]");

            ButtonClick("**/XCUIElementTypeOther[`value == \"0\"`][2]");
            GetInputElementAndInsertData("**/XCUIElementTypeTextField[`value == \"Enter Loan Amount\"`]", "1000");
            GetInputElementAndInsertData("**/XCUIElementTypeTextField[`value == \"ROI\"`]", "12");
            ButtonClick("**/XCUIElementTypeOther[`name == \"Default select example\"`]");
            ButtonClick("**/XCUIElementTypeButton[`name == \"2 Years\"`]");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Calculate EMI\"`]");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Need few details\"`]");
            ButtonClick("**/XCUIElementTypeOther[`value == \"0\"`][2]");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Next\"`]");
            ButtonClick("**/XCUIElementTypeOther[`name == \"Self-employed\"`]");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Next\"`]");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Next\"`]");
            GetInputElementAndInsertData("**/XCUIElementTypeOther[`name == \"article\"`]", "Vikas");
            GetInputElementAndInsertData("**/XCUIElementTypeTextField[`value == \"Last name\"`]", "Raut");
            
            var elementPage = App.FindElements(By.XPath("//*"));
            var test = elementPage.Where(e=>e.Text == "Next").ToList();
            foreach (var element in test)
            {
                if (element.Text == "Next")
                {
                    element.Click();
                }
            }
            GetInputElementAndInsertData("**/XCUIElementTypeTextField[`value == \"Phone\"`]", "9699211164");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Submit\"`]");
            ButtonClick("**/XCUIElementTypeButton[`name == \"Contact Lender\"`][1]");
        }
    }
}
