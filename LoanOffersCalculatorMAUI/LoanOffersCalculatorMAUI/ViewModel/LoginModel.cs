using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanOffersCalculatorMAUI.ViewModel
{
    public partial class LoginModel: BaseViewModel
    {
        

        [Required]
        [EmailAddress]
        public string EmailText { get; set; }

        [Required]
        [PasswordPropertyText]
        public string PasswordText { get; set; }
    }
}
