using LoanOffersCalculator.UnitTest.Shared;
using NUnit.Framework;

namespace LoanOffersCalculator.UnitTest.Windows
{
    public class LoginTestCase
	{
		private Login l;
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			l = new Login();
		}

		[Test]
		public void SignIn()
		{
			l.SignIn();
		}
	}
}