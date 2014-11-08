using numl;
using numl.Model;
using numl.Supervised.DecisionTree;
using numl.Supervised.NeuralNetwork;
using numl.Supervised.Perceptron;
using System;

namespace ConsoleApplication4
{
    public enum Outlook
    {
        Sunny,
        Overcast,
        Rainy
    }

    public enum Temperature
    {
        Low,
        High
    }

    public class Tennis
    {
        [Feature]
        public Outlook Outlook { get; set; }
        [Feature]
        public Temperature Temperature { get; set; }
        [Feature]
        public bool Windy { get; set; }
        [Label]
        public bool Play { get; set; }

        public static Tennis[] GetData()
        {
            return new Tennis[]  {
                new Tennis { Play = true, Outlook=Outlook.Sunny, Temperature = Temperature.Low, Windy=true},
                new Tennis { Play = false, Outlook=Outlook.Sunny, Temperature = Temperature.High, Windy=true},
                new Tennis { Play = false, Outlook=Outlook.Sunny, Temperature = Temperature.High, Windy=false},
                new Tennis { Play = true, Outlook=Outlook.Overcast, Temperature = Temperature.Low, Windy=true},
                new Tennis { Play = true, Outlook=Outlook.Overcast, Temperature = Temperature.High, Windy= false},
                new Tennis { Play = true, Outlook=Outlook.Overcast, Temperature = Temperature.Low, Windy=false},
                new Tennis { Play = false, Outlook=Outlook.Rainy, Temperature = Temperature.Low, Windy=true},
                new Tennis { Play = true, Outlook=Outlook.Rainy, Temperature = Temperature.Low, Windy=false}
            };
        }
    }

    public class Program
    {
        public static void Main()
        {
            Tennis[] data = Tennis.GetData();
            var d = Descriptor.Create<Tennis>();


            //var g = new DecisionTreeGenerator(d);
            //g.SetHint(false);
            var g = new PerceptronGenerator();
            g.Descriptor = d;


            //var g = new NeuralNetworkGenerator();
            //g.Descriptor = d;
            var model = Learner.Learn(data, 0.8, 1000, g);
            Console.WriteLine(model);
            Tennis t = new Tennis
            {
                Outlook = Outlook.Rainy,
                Temperature = Temperature.High,
                Windy = true
            };

            model.Model.Predict(t);



            Console.WriteLine(t.Play);
        }
    }
}