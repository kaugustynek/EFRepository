using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));
        public delegate void KADelegate();
        public static event KADelegate kaEvent;

        static void Main(string[] args)
        {
            BuilderTest();
        }

        private static void BuilderTest()
        {
            var shapes = new List<Shape> { 
                new CircleShape(1, 2, 3, new DrawingAPI1()),
                new CircleShape(5, 7, 11, new DrawingAPI2()),
            };

            foreach (var shape in shapes)
            {
                shape.ResizeByPercentage(2.5);
                shape.Draw();
            }
        }

        private static void FactoryTest()
        {
            var factory = new SedanFactory();
            var car = factory.MakeCar();

            Console.WriteLine(car.GetCarType());
        }

        public static void HelloWorld()
        {
            Console.WriteLine("Hello world");
        }

        private static void LoggerTest()
        {
            KADelegate ka = HelloWorld;

            kaEvent = HelloWorld;


            ka = delegate()
            {
                Console.WriteLine("Fiu Fiu");
            };

            kaEvent();

            DOMConfigurator.Configure();

            logger.Debug("Here is a debug log.");
            logger.Info("... and an Info log.");
            logger.Warn("... and a warning.");
            logger.Error("... and an error.");
            logger.Fatal("... and a fatal error.");
        }

        private static void ProxyTest()
        {
            var image1 = new ImageProxy("c:\\test.txt", "wzorce projektowe");
            var image2 = new ImageProxy("c:\\test.txt", "wzorce projektowe");

            image1.DisplayImage();
            image1.DisplayImage();
            image2.DisplayImage();
            image2.DisplayImage();
            image2.DisplayImage();
        }

        private static void FacadeTest()
        {
            var jogging = new JoggingFacade();

            Console.WriteLine("\n#############################");
            Console.WriteLine("Start jogging");
            Console.WriteLine("#############################\n");

            jogging.StartJogging();

            Console.WriteLine("\n#############################");
            Console.WriteLine("Stop jogging");
            Console.WriteLine("#############################\n");

            jogging.StopJogging();
        }
    }
}
