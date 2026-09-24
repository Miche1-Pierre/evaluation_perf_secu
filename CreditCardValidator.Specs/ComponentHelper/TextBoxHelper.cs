using OpenQA.Selenium;

namespace CreditCardValidator.Specs.ComponentHelper;

public static class TextBoxHelper
{
    public static void Type(IWebDriver driver, By locator, string text)
    {
        driver.FindElement(locator).SendKeys(text);
    }
}
