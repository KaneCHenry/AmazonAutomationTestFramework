Feature: UserIsAbleToRemoveItemsFromShoppingBasket

remove items basket feature

@tag1
Scenario: user is able to remove items from shopping basket
	Given the user is on the amazon hompage and there are items displayed in the search basket
	When the user clicks on the shopping basket and is on the shopping basket page
	Then the user is able to remove items from the cart and the cart amount reflects remaining number correctly
