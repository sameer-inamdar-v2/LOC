using LoanOffersCalculator.UnitTest.Shared.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Xml.Linq;

namespace LoanOffersCalculator.UnitTest.Shared
{

    public class Login : BaseTest
    {
        public void AppLaunches()
        {
            App.GetScreenshot().SaveAsFile($"LoginPage.png");
        }

        public void SignIn()
        {
            ButtonClick("SignInBtn");
            var pElement = FindUIElement("indexh1auto1");
            
            //App.GetScreenshot().SaveAsFile($"Home.png");
            Assert.That(pElement?.Text, Is.EqualTo("Hello, world!"));
        }

    }
}
