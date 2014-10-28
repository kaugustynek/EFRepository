using System.Collections.Generic;

namespace AutofacTest
{
    interface ITaskRepository
    {
        IEnumerable<CustomTask> GetAllTasks();
    }
}