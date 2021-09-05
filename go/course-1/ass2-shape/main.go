package main

import (
	"fmt"
	"reflect"
)

type shape interface {
	getArea() float64
}

type square struct {
	side float64
}

type triangle struct {
	height float64
	base   float64
}

func main() {
	square := square{side: 3.0}
	triangle := triangle{height: 4, base: 3}

	printArea(square)
	printArea(triangle)
}

func printArea(s shape) {
	name := getType(s)
	fmt.Println("Area of", name, ":", s.getArea())
}

func (s square) getArea() float64 {
	return s.side * s.side
}

func (t triangle) getArea() float64 {
	return t.base * t.height * 0.5
}

func getType(myvar interface{}) string {
	if t := reflect.TypeOf(myvar); t.Kind() == reflect.Ptr {
		return "*" + t.Elem().Name()
	} else {
		return t.Name()
	}
}
