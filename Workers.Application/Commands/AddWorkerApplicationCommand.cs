using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Interfaces.Arguments.Application;
using Workers.Interfaces.Arguments.Core;
using Workers.Interfaces.Common;
using Workers.Interfaces.DataObjects;

namespace Workers.Application.Commands
{

    public class AddWorkerApplicationCommand : ICommand<AddWorkerApp, Worker>(ICommand<ValidateAddWorker, Worker> validateAddWorker, ICommand<AddWorkerRepo, Worker> addWorkerRepo)
    {
        public async Task<CommandResult<Worker>> Execute(AddWorkerApp input)
        {
            //there are 2 ways the id could work, either be given one externally or assign one within this service
            //if external, need to have a GetWorkerByIdQuery to get possible existing worker with that id
            //will validate the worker, comparing it to potentially null previous worker with same id
            //validation will be done in core with ValidateWorkerCommand
            var validateResult = await validateAddWorker.Execute(new ValidateAddWorker(input.Worker, WORKER_FROM_GET_BY_ID));
            if(validateResult.statusCode != 200)
            {
                throw new Error();
            }


            var addResult = await addWorkerRepo.Execute(new AddWorkerRepo(validateResult.Result));

            throw new NotImplementedException();
        }
    }
}
