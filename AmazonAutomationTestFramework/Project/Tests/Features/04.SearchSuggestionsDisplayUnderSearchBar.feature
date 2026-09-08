Feature: SearchSuggestionsDisplayUnderSearchBar

Testing search suggestion functionality

@tag1
Scenario: search suggestions
	Given User is on the Amazon homepage
	When  the user enters a search term into the search bar 
	Then  item suggestions appear under the search bar


	
	