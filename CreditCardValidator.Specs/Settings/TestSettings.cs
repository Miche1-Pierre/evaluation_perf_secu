namespace CreditCardValidator.Specs.Settings;

// Section "TestSettings" de appsettings.json
public class TestSettings
{
    public string BaseUrl { get; set; } = "";
    public string Browser { get; set; } = "Chrome";
    public bool Headless { get; set; }
    public int ImplicitWaitSeconds { get; set; }
}
