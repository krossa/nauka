package main

import "fmt"

func main() {
	// var colors map[string]string
	// colors := make(map[string]string)

	colors := map[string]string{
		"red":   "#ff0000",
		"green": "#ff1111",
		"blue":  "#ff2222",
	}

	fmt.Println(colors)

	colors["blue"] = "new blue"
	colors["white"] = "0000000"
	fmt.Println(colors)

	delete(colors, "white")
	fmt.Println(colors)
	printMap(colors)

}

func printMap(m map[string]string) {
	for key, value := range m {
		fmt.Println(key, " : ", value)
	}
}
