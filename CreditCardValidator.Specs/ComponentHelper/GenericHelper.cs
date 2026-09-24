using OpenQA.Selenium;

namespace CreditCardValidator.Specs.ComponentHelper;

public static class GenericHelper
{
    public static bool IsDisplayed(IWebDriver driver, By locator)
    {
        try
        {
            return driver.FindElement(locator).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
