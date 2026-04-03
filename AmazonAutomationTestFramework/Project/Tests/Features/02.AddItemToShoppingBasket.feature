Feature: AddItemToShoppingBasket

user adds items to amazon shopping basket 

@tag1
Scenario: Search and add item to shopping basket
	Given the user is on the amazon homepage
	When  the user searches and selects an item to purchase
	Then that item is reflected in the shopping basket as expected
	
