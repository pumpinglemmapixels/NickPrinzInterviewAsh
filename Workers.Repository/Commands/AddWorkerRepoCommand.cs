using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Interfaces.Common;
using Workers.Interfaces.DataObjects;

namespace Workers.Repository.Commands
{
    public class AddWorkerRepoCommand : ICommand<AddWorkerRepo, Worker>
    {
        public async Task<CommandResult<Worker>> Execute(AddWorkerRepo input)
        {
            //there are 2 ways the id could work, either be given one externally or assign one within this service
            //if external, need to have a GetWorkerByIdQuery to get possible existing worker with that id
            //will validate the worker, comparing it to potentially null previous worker with same id
            //validation will be done in core with ValidateWorkerCommand


            throw new NotImplementedException();
        }
    }
}
