using OpenQA.Selenium;

namespace CreditCardValidator.Specs.Repository;

// Tous les sélecteurs de la page au même endroit
public static class ObjectRepository
{
    public static readonly By CreditCardNumber = By.Id("creditCardNumber");
    public static readonly By ExpirationDate = By.Id("expirationDate");
    public static readonly By Cvc = By.Id("cvc");
    public static readonly By SubmitButton = By.Id("submitCard");
    public static readonly By PaymentConfirmed = By.Id("paymentConfirmed");
}
