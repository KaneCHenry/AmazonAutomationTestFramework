
Feature: Amazon First BDD

Item is displayed on the amazon search result
@tag1


Scenario: User is able to search for an item
	Given User is on the amazon homepage
	When  the user types an item into the search field
	Then  item is displayed in the search result


