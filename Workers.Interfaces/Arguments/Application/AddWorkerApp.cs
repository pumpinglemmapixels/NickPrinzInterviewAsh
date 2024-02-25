using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Interfaces.DataObjects;

namespace Workers.Interfaces.Arguments.Application
{
    public record AddWorkerApp(Worker Worker)
    {
    }
}
