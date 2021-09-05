package main

import (
	"fmt"
	"io"
	"log"
	"os"
)

func main() {
	if len(os.Args) == 1 {
		fmt.Println("Provide file name")
		os.Exit(1)
	}
	fileName := os.Args[1]

	fmt.Println("opening", fileName)

	fmt.Println("\nMETHOD ONE")
	methodOne(fileName)
	fmt.Println("\nMETHOD TWO")
	methodTwo(fileName)
}

func methodOne(fileName string) {
	f, err := os.Open(fileName)

	if err != nil {
		log.Fatalf("unable to read file: %v", err)
	}

	defer f.Close()
	var result string
	buf := make([]byte, 5)
	for {
		n, err := f.Read(buf)
		if err == io.EOF {
			break
		}
		if err != nil {
			log.Fatalf("error while reading: %v", err)
			continue
		}
		if n > 0 {
			result += string(buf[:n])
		}
	}

	fmt.Println(result)
}

func methodTwo(fileName string) {
	dat, err := os.ReadFile(fileName)
	if err != nil {
		log.Fatalf("unable to read file: %v", err)
	}
	fmt.Print(string(dat))
}
