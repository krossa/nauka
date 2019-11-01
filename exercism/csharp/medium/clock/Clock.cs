using System;

public class Clock
{
    private int hours;
    private int minutes;

    public Clock(int hours, int minutes)
    {
        while (minutes < 0)
        {
            minutes += 60;
            hours--;
        }
        while (hours < 0) hours += 24;
        this.hours = (hours + minutes / 60) % 24;
        this.minutes = minutes % 60;
    }

    public Clock Add(int minutesToAdd) => new Clock(this.hours, this.minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(this.hours, this.minutes - minutesToSubtract);

    public override bool Equals(object obj) => obj.GetType() == typeof(Clock) && (ToString() == obj.ToString());

    public override string ToString() => $"{hours:D2}:{minutes:D2}";
}