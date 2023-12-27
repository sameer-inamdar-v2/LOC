using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Internal;

namespace LoanOffersCalculator.UnitTest.Shared.Helper
{
    public class AppiumSetup
    {
        public AppiumSetup(string application)
        {
            CreateDriver(application);
        }
        private static AppiumDriver? driver;

        public static AppiumDriver App => driver ?? throw new NullReferenceException("AppiumDriver is null");

        public void CreateDriver(string application = "windows")
        {
            try
            {
                // If you started an Appium server manually, make sure to comment out the next line
                // This line starts a local Appium server for you as part of the test run
                //AppiumServerHelper.StartAppiumLocalServer();
                if (application == "windows")
                {
                    var windowsOptions = new AppiumOptions
                    {
                        // Specify windows as the driver, typically don't need to change this
                        AutomationName = "windows",
                        // Always Windows for Windows
                        PlatformName = "Windows",
                        // The identifier of the deployed application to test
                        App = "9D769ACF-D160-48D9-8741-747AE3316976_9zz4h110yvjzm!App",
                    };

                    // Note there are many more options that you can use to influence the app under test according to your needs

                    driver = new WindowsDriver(windowsOptions);
                }
                else if (application == "android")
                {
                    var androidOptions = new AppiumOptions
                    {
                        // Specify UIAutomator2 as the driver, typically don't need to change this
                        AutomationName = "UIAutomator2",
                        // Always Android for Android
                        PlatformName = "Android",
                        // This is the Android version, not API level
                        // This is ignored if you use the avd option below
                        PlatformVersion = "13",
                        // The full path to the .apk file to test or the package name if the app is already installed on the device
                        //App = "com.companyname.loanofferscalculatormaui",
                        //App = @"C:\Users\arman.shaikh\source\repos\v2disha\LoanOffersCalculatorMAUI\LoanOffersCalculatorMAUI\bin\Debug\net6.0-android\com.companyname.loanofferscalculatormaui.apk",
                        //App = @"C:\Users\arman.shaikh\Downloads\Facebook Lite_383.0.0.0.4_Apkpure.apk"

                    };

                    // Specifying the avd option will boot the emulator for you
                    // make sure there is an emulator with the name below
                    // If not specified, make sure you have an emulator booted
                    androidOptions.AddAdditionalAppiumOption("avd", "pixel_5_-_api_33");
                    androidOptions.AddAdditionalAppiumOption("appPackage", "com.companyname.loanofferscalculatormaui");
                    androidOptions.AddAdditionalAppiumOption("appActivity", "crc64d931dcbeae13f95e.MainActivity");
                    androidOptions.AddAdditionalAppiumOption("noReset", "true");
                    androidOptions.AddAdditionalAppiumOption("fullReset", "false");
                    //androidOptions.AddAdditionalAppiumOption("enableMultiWindows", "true");
                    // Note there are many more options that you can use to influence the app under test according to your needs

                    driver = new AndroidDriver(androidOptions, TimeSpan.FromSeconds(180));
					driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
					//Task.Delay(100000).Wait();
					//driver.ActivateApp("com.companyname.loanofferscalculatormaui");

				}
                else if (application == "iOS")
                {
					var iOSOptions = new AppiumOptions
					{
						// Specify XCUITest as the driver, typically don't need to change this
						AutomationName = "XCUITest",
						// Always iOS for iOS
						PlatformName = "iOS",
						// iOS Version
						PlatformVersion = "17.2",
						// Don't specify if you don't want a specific device
						DeviceName = "iPhone SE (3rd generation)",
						// The full path to the .app file to test or the bundle id if the app is already installed on the device
						App = "com.companyname.loanofferscalculatormaui",
                        //App = "9D769ACF-D160-48D9-8741-747AE3316976_9zz4h110yvjzm!App",

					};
					iOSOptions.AddAdditionalAppiumOption("udid", "261BE548-4E4F-43F2-8600-FE83055DBF6E");
					iOSOptions.AddAdditionalAppiumOption("noReset", "true");
					iOSOptions.AddAdditionalAppiumOption("fullReset", "false");
					// Note there are many more options that you can use to influence the app under test according to your needs
					Uri uri = new("http://192.168.0.104:4723");
					
					driver = new IOSDriver(uri, iOSOptions, TimeSpan.FromSeconds(180));
					driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
				}
            }
            catch (Exception ex)
            {
                driver?.Quit();
                //AppiumServerHelper.DisposeAppiumLocalServer();
            }
        }

        public void DestroyDriver()
        {
            driver?.Quit();

            // If an Appium server was started locally above, make sure we clean it up here
            //AppiumServerHelper.DisposeAppiumLocalServer();
        }
    }
}
