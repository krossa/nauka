using System;

public class Matcher
{
    public static int TollFare(Object vehicleType) => vehicleType switch
    {
        Car c => 100,
        DeliveryTruck d => 200,
        Bus b => 150,
        Taxi t => 120,
        null => 0,
        { } => 0
    };

    public static int OccupancyTypeTollFare(Object vehicleType) => vehicleType switch
    {
        Car { PassengerCount: 0 } => 100 + 10,
        Car { PassengerCount: 1 } => 100,
        Car { PassengerCount: 2 } => 100 - 10,
        Car c => 100 - 20,

        Taxi { Fare: 0 } => 100 + 10,
        Taxi { Fare: 1 } => 100,
        Taxi { Fare: 2 } => 100 - 10,
        Taxi t => 100 - 20,

        Bus b when ((double)b.RidersCount / (double)b.Capacity) < 0.50 => 150 + 30,
        Bus b when ((double)b.RidersCount / (double)b.Capacity) > 0.90 => 150 - 40,
        Bus b => 150,

        DeliveryTruck t when (t.Weight > 5000) => 200 + 100,
        DeliveryTruck t when (t.Weight < 3000) => 200 - 20,
        DeliveryTruck t => 200,

        null => 0,
        { } => 0,
    };
}