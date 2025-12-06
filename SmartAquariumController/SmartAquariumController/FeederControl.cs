using System;

public class FeederControl
{
    private string status = "Idle";
    private Random rand = new Random();

    public string GetStatus()
    {
        status = rand.Next(0, 2) == 1 ? "Feeding" : "Idle";
        return status;
    }
}
