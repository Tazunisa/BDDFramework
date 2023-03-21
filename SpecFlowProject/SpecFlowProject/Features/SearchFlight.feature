Feature: Flight Search As a user of the British Airways website

  @myTag
  Scenario Outline: Search for flights between London and New York

    Given I am on the British Airways homepage
    When I click the Flights icon
    And I enter <From> as the from destination
    And I enter <To> as the to destination
    And I enter <DepartureDate> as the departure date
    And I enter <ReturnDate> as the return date
    And I select <Passengers> adults from the Passengers drop down
    And I select <TravelClass> from the Travel class drop down
    And I click the Search flight button
    Then I should see flight search results for London to New York

    Examples: 
    | From      | To       | DepartureDate          | ReturnDate               | Passengers | TravelClass |
    | "London"  | "New York" | "Monday, 27 March, 2023" | "Friday, 31 March, 2023"   | "2"          | "Economy"     |

 @myTag1
  Scenario: Search for flights between New Delhi to Canada

    Given I am on the British Airways homepage
    When I click the Flights icon
    And I enter <From> as the from destination
    And I enter <To> as the to destination
    And I enter <DepartureDate> as the departure date
    And I enter <ReturnDate> as the return date
    And I select <Passengers> adults from the Passengers drop down
    And I select <TravelClass> from the Travel class drop down
    And I click the Search flight button
    Then I should see flight search results for London to New York

   Examples:  
   | From        | To         | DepartureDate            | ReturnDate                 | Passengers | TravelClass |
   | "New Delhi" | "Canada"   | "Sunday, 26 March, 2023" | "Thursday, 30 March, 2023" |    "3"     | "Business"  |
   