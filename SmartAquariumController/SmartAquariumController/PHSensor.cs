using System;

public class PHSensor
{
    Random rand = new Random();

    public double GetValue()
    {
        double r = rand.NextDouble();

        // 75% normal range: 6.5–8.0
        if (r < 0.75)
        {
            return Math.Round(6.5 + rand.NextDouble() * 1.5, 2);
        }

        // 12.5% too acidic: 5.8–6.4
        if (r < 0.875)
        {
            return Math.Round(5.8 + rand.NextDouble() * 0.6, 2);
        }

        // 12.5% too alkaline: 8.1–8.6
        return Math.Round(8.1 + rand.NextDouble() * 0.5, 2);
    }

    public double ReadValue() => GetValue();
}