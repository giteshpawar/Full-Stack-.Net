using System;
class Task1_FeeCalculator
{
    public static double CalculateFee(int credits, string type)
    {
        double fee = credits * 1000;

        if (type.ToLower() == "regular")
            return fee;

        if (type.ToLower() == "scholarship")
            return fee * 0.5;

        if (type.ToLower() == "part-time")
            return fee * 0.75;

        return fee;
    }
}