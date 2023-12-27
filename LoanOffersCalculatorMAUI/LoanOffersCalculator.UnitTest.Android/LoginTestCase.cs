using NUnit.Framework;
using LoanOffersCalculator.UnitTest.Shared;
using LoanOffersCalculator.UnitTest.Shared.Helper;
using OpenQA.Selenium;
using System.Xml.Linq;

namespace LoanOffersCalculator.UnitTest.Android
{
	public class LoginTestCase : BaseTest
	{

        private Login l;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            l = new Login();
        }

        [Test]
        public void SignIn() => l.SignIn();
    }
}
