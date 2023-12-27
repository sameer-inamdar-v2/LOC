using LoanOffersCalculator.UnitTest.Shared.Helper;
using NUnit.Framework;

namespace LoanOffersCalculator.UnitTest.Android
{
    [SetUpFixture]
    internal class AndroidSetup
    {
        private AppiumSetup appiumSetup;
        [OneTimeSetUp]
        public void Setup()
        {
            appiumSetup = new AppiumSetup("android");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            appiumSetup?.DestroyDriver();
        }
    }
}
