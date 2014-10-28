using System.Collections.Generic;

namespace AutofacTest
{
    class TaskRepository: ITaskRepository
    {
        public IEnumerable<CustomTask> GetAllTasks()
        {
            return new[]
            {
                new CustomTask("Czytaj"),
                new CustomTask("Pisz"),
                new CustomTask("Testuj"),
            };
        }
    }
}