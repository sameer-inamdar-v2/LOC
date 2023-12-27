using LoanOffersCalculator.UnitTest.Shared.Helper;
using NUnit.Framework;

namespace LoanOffersCalculator.UnitTest.Windows
{
    [SetUpFixture]
    internal class WindowsSetup
    {
        private AppiumSetup appiumSetup;
        [OneTimeSetUp]
        public void Setup()
        {
            appiumSetup = new AppiumSetup("windows");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            appiumSetup?.DestroyDriver();
        }
    }
}
