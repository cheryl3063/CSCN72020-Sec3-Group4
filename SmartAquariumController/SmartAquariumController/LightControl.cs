using System;

public class LightControl
{
    private bool isOn = false;
    private Random rand = new Random();

    public bool IsOn()
    {
        isOn = rand.Next(0, 2) == 1;
        return isOn;
    }

    public bool IsLightOn()
    {
        return IsOn();
    }
}
