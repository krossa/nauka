package main

import (
	"os"
	"testing"
)

func TestNewDeck(t *testing.T) {
	d := newDeck()

	if len(d) != 16 {
		t.Errorf("Invalid card count: %d", len(d))
	}

	if d[0] != "Ace of Spades" {
		t.Errorf("First card is not Ace of Spades: %v", d[0])
	}

	if d[len(d)-1] != "Four of Clubs" {
		t.Errorf("Last card is not Four of Clubs: %v", d[len(d)-1])
	}
}

func TestSaveToAndNewDeckFromFile(t *testing.T) {
	fileName := "_decktesting"
	os.Remove(fileName)

	deck := newDeck()
	deck.saveToFile(fileName)

	loadedDeck := newDeckFromFile(fileName)

	if len(loadedDeck) != 16 {
		t.Errorf("Invalid card count: %d", len(loadedDeck))
	}

	if loadedDeck[0] != "Ace of Spades" {
		t.Errorf("First card is not Ace of Spades: %v", loadedDeck[0])
	}

	if loadedDeck[len(loadedDeck)-1] != "Four of Clubs" {
		t.Errorf("Last card is not Four of Clubs: %v", loadedDeck[len(loadedDeck)-1])
	}

	os.Remove(fileName)
}
