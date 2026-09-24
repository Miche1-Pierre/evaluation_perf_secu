Feature: CreditCardValidator
    Validate credit card inputs

Scenario: Should go to paymentConfirmed when all inputs are good
    Given user in on home page
    And inputs for three inputs and button exists
    When credit card number is sixteen digits long
    And expiration date is at format MM/YYYY
    And cvc is three digits long
    And submit button is pressed
    Then user is on page paymentConfirmed

Scenario: Should stay on homePage when credit card number is not 16 digits long
    Given user in on home page
    And inputs for three inputs and button exists
    When credit card number is not sixteen digits long
    And expiration date is at format MM/YYYY
    And cvc is three digits long
    And submit button is pressed
    Then user is on homePage

Scenario: Should stay on homePage when expiration is not at format MM/YYYY
    Given user in on home page
    And inputs for three inputs and button exists
    When credit card number is sixteen digits long
    And expiration date is not at format MM/YYYY
    And cvc is three digits long
    And submit button is pressed
    Then user is on homePage

Scenario: Should stay on homePage when cvc is not three digits long
    Given user in on home page
    And inputs for three inputs and button exists
    When credit card number is sixteen digits long
    And expiration date is at format MM/YYYY
    And cvc is not three digits long
    And submit button is pressed
    Then user is on homePage
