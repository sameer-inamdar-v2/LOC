using LoanOffersCalculator.UnitTest.Shared.Helper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanOffersCalculator.UnitTest.Shared
{
    public class Calculator : BaseTest
    {
		public void OpenCalculatorPage()
        {
            ButtonClick("NavMenuAutoCalculator");
		}

        public void OpenCalculatorHomePage()
        {
            ButtonClick("walk");
        }

        public void LoanAmtNegtiveCheck()
        {
            var laonElement = GetInputElementAndInsertData("loanAmount", "-100");
            ButtonClick("calEMIbtn");
            Assert.IsTrue(string.Equals(laonElement.Text,"100") || 
                string.Equals(laonElement.Text,"0") || 
                string.Equals(laonElement.Text, "") );
        }

        public void InterestRateNegtiveCheck()
        {
            var intRateElement = GetInputElementAndInsertData("interestRate", "-1");
            ButtonClick("calEMIbtn");
            Assert.IsTrue(string.Equals(intRateElement.Text, "1") ||
                string.Equals(intRateElement.Text, "0") ||
                string.Equals(intRateElement.Text, ""));
        }

        public void LoanTenureNegtiveCheck()
        {
            var loanTenElement = GetInputElementAndInsertData("loanTenure", "-1");
            ButtonClick("calEMIbtn");
            Assert.IsTrue(string.Equals(loanTenElement.Text, "1") ||
                string.Equals(loanTenElement.Text, "0") ||
                string.Equals(loanTenElement.Text, ""));
        }

        public void PreVerifyInputDetails()
        {
            var loanAmtElement = GetInputElementAndInsertData("loanAmount", "1000");
            var intRateElement = GetInputElementAndInsertData("interestRate", "12");
            var loanTenElement = GetInputElementAndInsertData("loanTenure", "1");
            ButtonClick("calEMIbtn");
            Assert.AreEqual(loanAmtElement.Text, "1000");
            Assert.AreEqual(intRateElement.Text, "12");
            Assert.AreEqual(loanTenElement.Text, "1");
        }

        public void VerifyLaonEmi()
        {
            var emiElement = FindUIElement("calMonthlyEMI");
            Assert.IsTrue(string.Equals(emiElement.Text, "88") ||
                string.Equals(emiElement.Text, "88.85"));
        }

        public void VerifyIntrestPaid()
        {
            var intrestPaidElemet = FindUIElement("caltotalIntPaid");
            Assert.IsTrue(string.Equals(intrestPaidElemet.Text, "66") ||
                string.Equals(intrestPaidElemet.Text, "66.19"));
        }

        public void VerifyTotalAmtPaid()
        {
            var totalAmtElement = FindUIElement("caltotalAmtPaid");
            Assert.IsTrue(string.Equals(totalAmtElement.Text, "1066") ||
                string.Equals(totalAmtElement.Text, "1066.19"));
        }
    }
}
