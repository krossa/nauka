package main

import (
	"fmt"
	"net/http"
	"time"
)

func main() {
	links := []string{
		"http://google.com",
		"http://facebook.com",
		"http://stackoverflow.com",
		"http://golang.org",
		"http://amazon.com",
		// "http://invalid",
	}

	start := time.Now()
	for _, v := range links {
		checkLink(v, nil)
	}
	fmt.Println("\033[31m", "serial", time.Since(start))

	start = time.Now()

	c := make(chan string)
	for _, link := range links {
		go checkLink(link, c)
	}

	for i := 0; i < len(links); i++ {
		fmt.Println("\033[33m", <-c)
	}

	fmt.Println("\033[31m", "concurent", time.Since(start))

	// keep checking links
	for _, link := range links {
		go checkLink(link, c)
	}
	for link := range c {
		go func(l string) {
			time.Sleep(5 * time.Second)
			checkLink(l, c)
		}(link)
	}

}

func checkLink(link string, c chan string) {
	// fmt.Println("\033[32m", link, "START")

	_, err := http.Get(link)
	if err != nil {
		fmt.Println("\033[34m", link, "might be down")
		if c != nil {
			c <- link
		}
		return
	}
	fmt.Println("\033[34m", link, "is up!")
	if c != nil {
		c <- link
	}
}
