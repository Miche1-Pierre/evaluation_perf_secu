using CreditCardValidator.Specs.ComponentHelper;
using CreditCardValidator.Specs.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace CreditCardValidator.Specs.StepDefinitions;

[Binding]
public class CreditCardValidatorSteps : BaseClass
{
    [Given("user in on home page")]
    public void GivenUserInOnHomePage()
    {
        Driver.Navigate().GoToUrl(Settings.BaseUrl);
    }

    [Given("inputs for three inputs and button exists")]
    public void GivenInputsForThreeInputsAndButtonExists()
    {
        Assert.IsTrue(GenericHelper.IsDisplayed(Driver, ObjectRepository.CreditCardNumber));
        Assert.IsTrue(GenericHelper.IsDisplayed(Driver, ObjectRepository.ExpirationDate));
        Assert.IsTrue(GenericHelper.IsDisplayed(Driver, ObjectRepository.Cvc));
        Assert.IsTrue(GenericHelper.IsDisplayed(Driver, ObjectRepository.SubmitButton));
    }

    [When("credit card number is sixteen digits long")]
    public void WhenCreditCardNumberIsSixteenDigitsLong()
    {
        TextBoxHelper.Type(Driver, ObjectRepository.CreditCardNumber, "1234567812345678");
    }

    [When("credit card number is not sixteen digits long")]
    public void WhenCreditCardNumberIsNotSixteenDigitsLong()
    {
        TextBoxHelper.Type(Driver, ObjectRepository.CreditCardNumber, "12345678");
    }

    [When("expiration date is at format MM/YYYY")]
    public void WhenExpirationDateIsAtFormatMMYYYY()
    {
        TextBoxHelper.Type(Driver, ObjectRepository.ExpirationDate, "12/2030");
    }

    [When("expiration date is not at format MM/YYYY")]
    public void WhenExpirationDateIsNotAtFormatMMYYYY()
    {
        TextBoxHelper.Type(Driver, ObjectRepository.ExpirationDate, "12-30");
    }

    [When("cvc is three digits long")]
    public void WhenCvcIsThreeDigitsLong()
    {
        TextBoxHelper.Type(Driver, ObjectRepository.Cvc, "123");
    }

    [When("cvc is not three digits long")]
    public void WhenCvcIsNotThreeDigitsLong()
    {
        TextBoxHelper.Type(Driver, ObjectRepository.Cvc, "12");
    }

    [When("submit button is pressed")]
    public void WhenSubmitButtonIsPressed()
    {
        ButtonHelper.Click(Driver, ObjectRepository.SubmitButton);
    }

    [Then("user is on page paymentConfirmed")]
    public void ThenUserIsOnPagePaymentConfirmed()
    {
        Assert.IsTrue(GenericHelper.IsDisplayed(Driver, ObjectRepository.PaymentConfirmed));
    }

    [Then("user is on homePage")]
    public void ThenUserIsOnHomePage()
    {
        Assert.IsTrue(GenericHelper.IsDisplayed(Driver, ObjectRepository.CreditCardNumber));
    }
}
