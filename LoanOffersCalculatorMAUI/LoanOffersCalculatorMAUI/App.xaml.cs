using MetroLog.Maui;
using Microsoft.Extensions.Logging;

namespace LoanOffersCalculatorMAUI;

public partial class App : Application
{

    public static Realms.Sync.App RealmApp;

    public App()
    {
        InitializeComponent();

        RealmApp = Realms.Sync.App.Create(AppConfig.RealmAppId);

        MainPage = new MainPage(null);


    }
}
