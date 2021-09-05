package main

import "fmt"

type contactInfo struct {
	email   string
	zipCode int
}

type person struct {
	firstName string
	lastName  string
	contactInfo
}

func main() {
	jim := person{
		firstName: "Jim",
		lastName:  "P",
		contactInfo: contactInfo{
			email:   "my.mail@sdf.pl",
			zipCode: 123,
		},
	}

	jim.updateName("asd")

	fmt.Println(jim)
	jim.print()
	jim.print()
}

func (p *person) updateName(firstName string) {
	(*p).firstName = firstName
}

func (p person) print() {
	fmt.Printf("%+v\n", p)
}
