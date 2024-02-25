
using Workers.Interfaces.DataObjects;

namespace Workers.Interfaces.Arguments.Core
{
    public class ValidateAddWorker(Worker worker, Worker existingWorker)
    {
        public Worker Worker { get; set; } = worker;
        public Worker ExistingWorker { get; set; } = existingWorker;
    }
}
