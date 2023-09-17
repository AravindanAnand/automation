@swaglabs
Feature: Sanity

Background: Login
Given Login to the application

@addbyprice
Scenario: AddByPrice
    Given Add item to cart by price "29.99"
    Then Open cart to view the purchased items
    Then Checkout the items
    Then Add the billing user information "testnamefirst" and "testnamelast" and "213123123"
    Then Finish the purchase
    When Purchase is successfull
    Then Come back to homepage


@addbyname
Scenario: Add to cart by name
    Given Add item to cart by name "Sauce Labs Fleece Jacket"
    Then Open cart to view the purchased items
    Then Checkout the items
    Then Add the billing user information "testnamefirst" and "testnamelast" and "213123123"
    Then Finish the purchase
    When Purchase is successfull
    Then Come back to homepage



