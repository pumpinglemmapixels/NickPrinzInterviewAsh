using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Interfaces.Arguments.Core;
using Workers.Interfaces.Common;
using Workers.Interfaces.DataObjects;

namespace Workers.Core.Validation
{
    //this command (and the entire core layer) exists as a separate pocket from the application layer, as a part of onion architecture
    //this helps to isolate business logic from technology changes, meaning files in this project should only change because a business rule has changed
    //data gathering and massaging is handled by the application layer
    public class ValidateAddWorkerCommand : ICommand<ValidateAddWorker, Worker>
    {
        public async Task<CommandResult<Worker>> Execute(ValidateAddWorker input)
        {
            //validate the proposed new worker
            //check for field lengths, ids being > 0, either error or clear out values that are not appropriate for type(employee can't have an expense)
            //if input.ExistingWorker exists this is a key collision with the id, which is an error 

            throw new NotImplementedException();
        }
    }
}
