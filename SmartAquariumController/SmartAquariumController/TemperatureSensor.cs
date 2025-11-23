using System;

public class TemperatureSensor
{
    Random rand = new Random();

    public double GetValue()
    {
        double r = rand.NextDouble();

        // 75% of the time: normal 22–30°C
        if (r < 0.75)
        {
            return Math.Round(22 + rand.NextDouble() * 8, 1);
        }

        // 12.5%: cold dip 16–19°C
        if (r < 0.875)
        {
            return Math.Round(16 + rand.NextDouble() * 3, 1);
        }

        // 12.5%: hot spike 30–33°C
        return Math.Round(30 + rand.NextDouble() * 3, 1);
    }

    public double ReadValue() => GetValue();
}
