using System;

public class OxygenSensor
{
    Random rand = new Random();

    public double GetValue()
    {
        double r = rand.NextDouble();

        // 75% normal range: 5.0–7.5 mg/L
        if (r < 0.75)
        {
            return Math.Round(5.0 + rand.NextDouble() * 2.5, 1);
        }

        // 25% low oxygen: 3.8–4.9 mg/L
        return Math.Round(3.8 + rand.NextDouble() * 1.1, 1);
    }

    public double ReadValue() => GetValue();
}