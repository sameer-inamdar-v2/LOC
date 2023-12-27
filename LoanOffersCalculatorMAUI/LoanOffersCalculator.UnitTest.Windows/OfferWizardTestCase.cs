using LoanOffersCalculator.UnitTest.Shared;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanOffersCalculator.UnitTest.Windows
{
    public class OfferWizardTestCase
    {
        private OfferWizard offerWizard;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            offerWizard = new OfferWizard();
        }

        [Test, Order(1)]
        public void OpenOfferWizardPage() => offerWizard.OpenOfferWizardPage();

        [Test, Order(2)]
        public void ChooseProperty() => offerWizard.ChooseProperty();

        [Test, Order(3)]
        public void Price() => offerWizard.Price();

        [Test, Order(4)]
        public void Employed() => offerWizard.Employed();

        [Test, Order(5)]
        public void Name() => offerWizard.Name();
    }
}
