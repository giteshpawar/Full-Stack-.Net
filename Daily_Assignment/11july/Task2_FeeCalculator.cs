using System;
class Task2_FeeCalculator
{
    public static double CalculateFee(int credits, string type)
    {
        double fee = credits * 1000;

        switch (type.ToLower())
        {
            case "regular":
                return fee;

            case "scholarship":
                return fee * 0.5;

            case "part-time":
                return fee * 0.75;

            default:
                return fee;
        }
    }
}