using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;

namespace LoanOffersCalculator.UnitTest.Shared.Helper
{
    public abstract class BaseTest
    {
        protected AppiumDriver App => AppiumSetup.App;

        // This could also be an extension method to AppiumDriver if you prefer
        protected AppiumElement FindUIElement(string id)
        {
            try
            {
                if (App is WindowsDriver)
                {
                    return App.FindElement(MobileBy.AccessibilityId(id));
                }
                if (App is IOSDriver)
                    return App.FindElement(MobileBy.IosClassChain(id));
				return App.FindElement(By.XPath($"//*[@resource-id='{id}']"));
			}
            catch (Exception ex)
            {}
            return null;
        }

        protected AppiumElement GetInputElementAndInsertData(string elementName,string value)
        {
            var element = FindUIElement(elementName);
            element?.Click();
            element?.Clear();
            element?.SendKeys(value);
            Task.Delay(500).Wait();
            return element;
        }

        protected void ButtonClick(string elementName)
        {
            var element = FindUIElement(elementName);
            element?.Click();
            Task.Delay(500).Wait();
        }

        protected void Scroll(string text)
        {
            String uiSelector = "new UiSelector().textMatches(\"" + text
                        + "\")";

            String command = "new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView("
                                 + uiSelector + ");";
            App.FindElement(MobileBy.AndroidUIAutomator(command));
        }
    }
}
