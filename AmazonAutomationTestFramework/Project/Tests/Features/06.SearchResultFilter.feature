Feature: Search Filter

A short summary of the feature

@tag1
Scenario: userManipulateSearchFilters
	Given  I am on the amazon homepage
	When I type an item into the search bar and click search
	And the search result appears
	Then I am able to manipulate the price filter


