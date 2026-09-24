Pierre MICHEL

# Workshop noté - Consignes

## Création d'une petite page web avec 3 input + un bouton submit
- Réalisez une petite page web avec 3 input et un bouton submit
    - Credit Card Number
    - Expiration Date
    - CVC
    - + Submit button
- Pensez à mettre des id à vos éléments
- Et une page "paymentConfirmed" qui contiendra uniquement une div avec un id pour vérifier qu'on est bien sur cette page

## Mise en place de l'environnement
- Créez un projet de test MsTest que vous laissez pour l'instant vide
- Créez un projet SpecFlow (cible de tests MsTest)

## Scénarios
- Ajoutez un FeatureFile dans votre projet SpecFlow
- Ajoutez y 4 scénarios :
```
Feature: CreditCardValidator
	Validate credit card inputs

Scenario: All inputs are good
	Given user in on home page
    And inputs for three inputs and button exists
    When credit card number is sixteen digits long
    And expiration date is at format MM/YYYY
    And cvc is three digits long
    And submit button is pressed
    Then user is on page paymentConfirmed

Scenario: Credit card number is not 16 digits long
	Given user in on home page
    And inputs for three inputs and button exists
    When credit card number is not sixteen digits long
    And expiration date is at format MM/YYYY
    And cvc is three digits long
    And submit button is pressed
    Then user is on homePage

Scenario: Expiration is not at format MM/YYYY
	Given user in on home page
    And inputs for three inputs and button exists
    When credit card number is sixteen digits long
    And expiration date is not at format MM/YYYY
    And cvc is three digits long
    And submit button is pressed
    Then user is on homePage

Scenario: CVC is not three digits long
	Given user in on home page
    And inputs for three inputs and button exists
    When credit card number is sixteen digits long
    And expiration date is at format MM/YYYY
    And cvc is not three digits long
    And submit button is pressed
    Then user is on homePage
```

## Votre objectif
- L'objectif est de réaliser tout ce qui est nécessaire pour faire passer les tests découlant de ces scénarios.
- Si vous avez du mal à savoir par quoi commencer, faites en sortes de remplir chaque méthodes générés dans votre StepDefinition en utilisant directement un objet IWebDriver avec un ChromeDriver() par exemple.
- Vous factoriserez par la suite en utilisant un ObjectRepository, une BaseClass et les ComponentHelper vus ensembles lors de la première partie de la formation
- Des points bonus seront attribués à ceux qui mettent en place des paramètres propres provenant du appsettings.json et avec une bonne gestion de la configuration

En cas de souci de paramétrage ou autres, n'hésitez pas à me demander de l'aide.



## Journal d'avancement

1. Mise en place de l'environnement : installation du SDK .NET 8 (je fais les exos en Java d'habitude mais ca me permet de revoir C# aussi), MSTest et SpecFlow
2. Utilisation de Selenium (ChromeDriver) pour les tests automatisés
3. Pages web :
   1. paymentConfirmed.html : ajout dans la div `id="paymentConfirmed"`
4. Création de :
   1. CreditCardValidator.sln
   2. CreditCardValidator.Tests/
      1. Projet MsTest laissé tel quel pour l'instant (contient uniquement l'exemple UnitTest1.cs généré par le template)
   3. CreditCardValidator.Specs/ (projet SpecFlow, cible MsTest)
      1. Paquets SpecFlow, Selenium et lecture du appsettings.json
      2. Features/CreditCardValidator.feature : les 4 scénarios avec convention de nommage Should_When_
      3. appsettings.json : URL de la page (relative), navigateur, mode headless
      4. StepDefinitions/CreditCardValidatorSteps.cs : une méthode par phrase des scénarios
      5. Factorisation :
         1. BaseClass.cs : lit la config, démarre et ferme Chrome (hooks BeforeScenario et AfterScenario)
         2. Settings/TestSettings.cs : la section TestSettings de appsettings.json sous forme d'objet C#
         3. Repository/ObjectRepository.cs : tous les sélecteurs (By.Id) de la page
         4. ComponentHelper/ : TextBoxHelper, ButtonHelper, GenericHelper (actions Selenium réutilisables)

5. Résultat : les 4 scénarios passent (`dotnet test`)
