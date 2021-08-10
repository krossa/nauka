package main

func main() {
	cards := newDeck()
	// cards.print()

	// hand, remainingCards := deal(cards, 5)
	// hand.print()
	// fmt.Println("\nxxxxxxxxx")
	// remainingCards.print()
	// fmt.Println(cards.toString())

	// cards.saveToFile("my_cards")
	// cardsFromFile := newDeckFromFile("my_cards")
	// cardsFromFile.print()

	cards.shuffle()
	cards.print()
}

func newCard() string {
	return "Five of Dimonds"
}
