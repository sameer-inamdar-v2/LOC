using MetroLog.Maui;
using Microsoft.Extensions.Logging;

namespace LoanOffersCalculatorMAUI;

public partial class MainPage : ContentPage
{
    ILogger<MainPage> _logger;
    public MainPage(ILogger<MainPage> logger)
    {
        InitializeComponent();
        BindingContext = new LogController();

        _logger = logger;
    }
}
