using LoanOffersCalculator.UnitTest.Shared.Helper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanOffersCalculator.UnitTest.Shared
{
    public class OfferWizard : BaseTest
    {
        public void OpenOfferWizardPage()
        {
            //ButtonClick("NavMenuAutoCalculator");
            //ButtonClick("walk");
            ButtonClick("needFewDetails");
            //Assert.Pass();
        }

        public void ChooseProperty()
        {
            ButtonClick("walk");
            ButtonClick("nextBtn");
            //Assert.Pass();
        }

        public void Price()
        {
            //var estPriceElement = FindUIElement("customRange1");
            //estPriceElement.SendKeys("77763");
            ButtonClick("nextBtn");
            //Assert.Pass();
        }

        public void Employed()
        {
            ButtonClick("btnradio2");
            ButtonClick("nextBtn");
            //Assert.Pass();
        }

        public void Name() 
        {
            GetInputElementAndInsertData("firstNameAut", "Arman");
            GetInputElementAndInsertData("lastNameAut", "Shaikh");
            ButtonClick("nextBtn");
            GetInputElementAndInsertData("emailAut", "Mumbai");
            ButtonClick("nextBtn");
            //Assert.Pass();
        }
    }
}
