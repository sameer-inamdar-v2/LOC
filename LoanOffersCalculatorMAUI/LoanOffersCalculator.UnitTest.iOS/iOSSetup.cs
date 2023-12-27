using LoanOffersCalculator.UnitTest.Shared.Helper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanOffersCalculator.UnitTest.iOS
{
	[SetUpFixture]
	internal class iOSSetup
	{
		private AppiumSetup appiumSetup;
		[OneTimeSetUp]
		public void Setup()
		{
			appiumSetup = new AppiumSetup("iOS");
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			appiumSetup?.DestroyDriver();
		}
	}
}
