using LoanOffersCalculator.UnitTest.Shared;
using LoanOffersCalculator.UnitTest.Shared.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LoanOffersCalculator.UnitTest.Android
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
			var menuElement = FindUIElement("DivMenuAuto");
			Actions actions = new(App);
			actions.Click(menuElement).Perform();
		}

		[Test, Order(1)]
		public void OpenCalculatorPage() => cal.OpenCalculatorPage();

		[Test, Order(2)]
		public void OpenCalculatorHomePage() => cal.OpenCalculatorHomePage();

		[Test, Order(3)]
		public void PreVerifyInputDetails() => cal.PreVerifyInputDetails();

		[Test, Order(4)]
		public void VerifyLaonEmi() => cal.VerifyLaonEmi();

		[Test, Order(5)]
		public void VerifyIntrestPaid() => cal.VerifyIntrestPaid();

		[Test, Order(6)]
		public void VerifyTotalAmtPaid() => cal.VerifyTotalAmtPaid();

		[Test, Order(7)]
		public void OpenOfferWizardPage()
		{
			Scroll("Need few details");
			offerWizard.OpenOfferWizardPage();
		}

		[Test, Order(8)]
		public void ChooseProperty()
		{
			Scroll("Next");
			offerWizard.ChooseProperty();
		}

		[Test, Order(9)]
		public void Price() => offerWizard.Price();

		[Test, Order(10)]
		public void Employed() => offerWizard.Employed();

		[Test, Order(11)]
		public void Name() => offerWizard.Name();
	}
}
