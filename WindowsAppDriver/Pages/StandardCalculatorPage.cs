using System;
using System.Threading;
using WindowsAppDriver.Driver;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;

namespace WindowsAppDriver.Helper
{
    public class StandardCalculatorPage
    {
        private readonly WinAppDriver _driver;
        public WindowsElement results => _driver.Current.FindElementByAccessibilityId("CalculatorResults");
        public WindowsElement header => _driver.Current.FindElementByAccessibilityId("Header");
        public WindowsElement openNavigation => _driver.Current.FindElementByName("Open Navigation");



        public StandardCalculatorPage(WinAppDriver driver)
        {
            _driver = driver;

        }

        public void EnterNumber(string number)
        {
            foreach (char c in number)
            {
                _driver.Current.FindElementByAccessibilityId("num" + c + "Button").Click();
            }
        }

        public void EnterSign(string sign)
        {
            _driver.Current.FindElementByAccessibilityId(sign + "Button").Click();
        }

        public void NavigateToStandard(string calculatorType)
        {
            openNavigation.Click();
           _driver.Current.FindElementByName(calculatorType).Click();
            Thread.Sleep(2000);
          
            // _driver.Current.FindElementByAccessibilityId("FlyoutNav").FindElementsByClassName("ListViewItem")[0].Click();
        }

        public string GetTitle()
        {
            return header.Text.Trim();
        }


        public string GetResult()
        {
            return results.Text.Trim().Replace("Display is ", "");
        }
    }
}
