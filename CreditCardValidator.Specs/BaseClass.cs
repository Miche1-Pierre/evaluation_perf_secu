using CreditCardValidator.Specs.Settings;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace CreditCardValidator.Specs;

// Lit la config et gère le navigateur ; les StepDefinitions en héritent
public class BaseClass
{
    protected IWebDriver Driver = null!;
    protected TestSettings Settings = null!;

    [BeforeScenario]
    public void StartBrowser()
    {
        Settings = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables() // ex : TestSettings__Headless=true (utilisé par la CI)
            .Build()
            .GetSection("TestSettings")
            .Get<TestSettings>()!;

        // BaseUrl est relatif au dossier de build (bin/Debug/net8.0)
        Settings.BaseUrl = new Uri(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, Settings.BaseUrl))).AbsoluteUri;

        if (Settings.Browser != "Chrome")
        {
            throw new NotSupportedException($"Navigateur non géré : {Settings.Browser}");
        }

        var options = new ChromeOptions();
        if (Settings.Headless)
        {
            options.AddArgument("--headless=new");
        }

        Driver = new ChromeDriver(options);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Settings.ImplicitWaitSeconds);
    }

    [AfterScenario]
    public void CloseBrowser()
    {
        Driver.Quit();
    }
}
