using NUnit.Framework;
using LoanOffersCalculator.UnitTest.Shared;

namespace LoanOffersCalculator.UnitTest.Windows
{
    internal class CalculatorTestCase
    {
        private Calculator cal;
        private OfferWizard offerWizard;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            cal = new Calculator();
            offerWizard = new OfferWizard();
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
        public void OpenOfferWizardPage() => offerWizard.OpenOfferWizardPage();

        [Test, Order(8)]
        public void ChooseProperty() => offerWizard.ChooseProperty();

        [Test, Order(9)]
        public void Price() => offerWizard.Price();

        [Test, Order(10)]
        public void Employed() => offerWizard.Employed();

        [Test, Order(11)]
        public void Name() => offerWizard.Name();
    }
}
