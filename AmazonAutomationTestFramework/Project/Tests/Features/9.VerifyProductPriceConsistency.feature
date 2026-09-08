Feature: 10.VerifyProductPriceConsistency

A short summary of the feature

@tag1
Scenario: TestCase: Verify product price consistency
	Given the user is on the amazon homepage
	When  the user searches for an item 
	And   the user clicks an item from the search results
	Then  the product price should match the price displayed in the search results
	When the user adds the item to the basket
	#Then the basket price should match the product price

