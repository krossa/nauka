using System;

namespace pattern_matching
{
    class Program
    {
        static void Main(string[] args)
        {
            MatchOne();

            MatchTwo();
        }

        private static void MatchOne()
        {
            Console.WriteLine("TollFare");
            var car = new Car();
            var taxi = new Taxi();
            var bus = new Bus();
            var truck = new DeliveryTruck();
            Console.WriteLine($"The toll for a car is {Matcher.TollFare(car)}");
            Console.WriteLine($"The toll for a taxi is {Matcher.TollFare(taxi)}");
            Console.WriteLine($"The toll for a bus is {Matcher.TollFare(bus)}");
            Console.WriteLine($"The toll for a truck is {Matcher.TollFare(truck)}");
        }

        private static void MatchTwo()
        {
            Console.WriteLine("OccupancyTypeTollFare");
            var car1 = new Car { PassengerCount = 2 };
            var taxi1 = new Taxi { Fare = 0 };
            var bus1 = new Bus { Capacity = 100, RidersCount = 30 };
            var truck1 = new DeliveryTruck { Weight = 30000 };
            Console.WriteLine($"The toll for a car is {Matcher.OccupancyTypeTollFare(car1)}");
            Console.WriteLine($"The toll for a taxi is {Matcher.OccupancyTypeTollFare(taxi1)}");
            Console.WriteLine($"The toll for a bus is {Matcher.OccupancyTypeTollFare(bus1)}");
            Console.WriteLine($"The toll for a truck is {Matcher.OccupancyTypeTollFare(truck1)}");
        }
    }
}
