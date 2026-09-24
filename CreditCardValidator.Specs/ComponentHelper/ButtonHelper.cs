using OpenQA.Selenium;

namespace CreditCardValidator.Specs.ComponentHelper;

public static class ButtonHelper
{
    public static void Click(IWebDriver driver, By locator)
    {
        driver.FindElement(locator).Click();
    }
}
