namespace SmartAquariumController
{
    public static class SensorStatus
    {
        public static string FormatTemperature(double temp)
        {
            return $"{temp:0.0} °C";
        }

        public static string FormatPH(double ph)
        {
            return $"{ph:0.00}";
        }

        public static string FormatOxygen(double oxy)
        {
            return $"{oxy:0.0} mg/L";
        }
    }
}