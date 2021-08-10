package main

import "fmt"

func main() {
	numbers := make([]int, 10)
	for i := range numbers {
		numbers[i] = i + 1
	}
	fmt.Println(numbers)

	for _, n := range numbers {
		if n%2 == 0 {
			fmt.Println(n, " Even")
		} else {
			fmt.Println(n, " Odd")
		}

	}
}
