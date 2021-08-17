using System;
using System.Collections.Generic;
using System.Text;
using WindowsAppDriver.Driver;
using OpenQA.Selenium.Appium.Windows;

namespace WindowsAppDriver.Pages
{
    public class ScientificCalculatorPage
    {
        private readonly WinAppDriver _driver;
        public WindowsElement trigonometriButton => _driver.Current.FindElementByAccessibilityId("trigButton");


        public ScientificCalculatorPage(WinAppDriver driver)
        {
            _driver = driver;
            
        }

        public bool checkList(string type)
        {
            return _driver.Current.FindElementByAccessibilityId(type+"Button").Displayed;
        }

        public void EnterType(string type)
        {
            _driver.Current.FindElementByAccessibilityId( type+ "Button").Click();
        }



    }
}
