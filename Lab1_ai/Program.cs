using Lab1_ai;
using System;

class Program
{
    static void Main(string[] args)
    {
     int N = 30;
     double MaxTemperature = 100;
     double MinTemperature = 0.1;
     double TemperatureDecreaseFactor = 0.98;
     int IterationsPerTemperature = 100;

    AnnealingAlgorithm algorithm = new AnnealingAlgorithm(N, MaxTemperature, MinTemperature, TemperatureDecreaseFactor, IterationsPerTemperature);

        Board solution = algorithm.Solve();
        Console.WriteLine("\n___Фiнальне розташування ферзей на шаховiй дошцi___\n");
        solution.Print(); 
    }
}
