@swaglabs
Feature: Regression

Background: Login
Given Login to the application
@addmultipleitems
Scenario: Add multiple items
    Given Add item to cart by price "29.99"
    Given Add item to cart by name "Sauce Labs Fleece Jacket"
    Then Open cart to view the purchased items
    Then Checkout the items
    Then Add the billing user information "testnamefirst" and "testnamelast" and "213123123"
    Then Finish the purchase
    When Purchase is successfull
    Then Come back to homepage

@failcase
Scenario: Fail the case
    Given Add item to cart by price "29.99"
    Given Add item to cart by name "Sauce Labs Fleece Jacket"
    Then Open cart to view the purchased items
    Then Checkout the items
    Then Add the billing user information "testnamefirst" and "testnamelast" and "213123123"
    #Then Finish the purchase
    When Purchase is successfull
    Then Come back to homepage