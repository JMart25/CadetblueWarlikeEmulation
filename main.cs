using System;
using System.Collections.Generic;
using System.Linq;

class TemperaturesComparison
{
    static void Main(string[] args)
    {
        const int numberOfTemperatures = 5;
        int[] temperatures = new int[numberOfTemperatures];

        for (int i = 0; i < numberOfTemperatures; i++)
        {
            temperatures[i] = GetValidTemperature(i + 1);
        }

        string trendMessage = DetermineTrendMessage(temperatures);
        Console.WriteLine(trendMessage);

        Console.WriteLine($"5-day Temperature [{string.Join(", ", temperatures)}]");

        double averageTemperature = temperatures.Average();
        Console.WriteLine($"Average Temperature is {averageTemperature:F1} degrees");
    }

    static int GetValidTemperature(int day)
    {
        while (true)
        {
            Console.Write($"Enter Temperature for day {day}: ");
            int temperature;
            if (int.TryParse(Console.ReadLine(), out temperature))
            {
                if (temperature >= -30 && temperature <= 130)
                {
                    return temperature;
                }
            }
            Console.WriteLine("Invalid temperature. Please enter a valid temperature between -30 and 130.");
        }
    }

    static string DetermineTrendMessage(int[] temperatures)
    {
        bool gettingWarmer = true;
        bool gettingCooler = true;

        for (int i = 1; i < temperatures.Length; i++)
        {
            if (temperatures[i] <= temperatures[i - 1])
            {
                gettingWarmer = false;
            }
            if (temperatures[i] >= temperatures[i - 1])
            {
                gettingCooler = false;
            }
        }

        if (gettingWarmer)
        {
            return "Getting Warmer";
        }
        else if (gettingCooler)
        {
            return "Getting Cooler";
        }
        else
        {
            return "It's a mixed bag";
        }
    }
}
