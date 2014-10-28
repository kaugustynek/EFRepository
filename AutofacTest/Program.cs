using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AutofacTest
{
    class Program
    {
        static double Max(double b, double a)
        {
            return a > b ? a : b;
        }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
 
            // Register individual components
            builder.RegisterType<TaskRepository>()
                   .As<ITaskRepository>().InstancePerDependency();
 
            var container = builder.Build();

            var taskRepo = container.Resolve<ITaskRepository>();
            foreach (var customTask in taskRepo.GetAllTasks())
            {
                Console.WriteLine(customTask.Name);
            }

            Console.WriteLine("Max = {0}", Max(b: 3, a: 2));
            ;
        }
    }
}
