using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Workers.Interfaces.Arguments.Application;
using Workers.Interfaces.Common;
using Workers.Interfaces.DataObjects;

namespace NickPrinzInterviewAsh.Controllers
{
    [Route("workers")]
    [ApiController]
    public class WorkerController(
        ILogger<WorkerController> logger,
        IQuery<GetAllWorkersApp, IEnumerable<Worker>> getAllQuery,
        ICommand<AddWorkerApp, Worker> insertCommand)
    {

        [HttpGet]
        public async Task<IEnumerable<WorkerDto>> GetAll()
        {
            try
            {
                var response = await getAllQuery.Get(new GetAllWorkersApp());
                return WorkerDto.ToDtos(response.Result);

            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<WorkerDto> AddWorker([FromBody] WorkerDto value)
        {
            try
            {
                var response = await insertCommand.Execute(new AddWorkerApp(value.ToObject()));
                return WorkerDto.ToDto(response.Result);

            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw;
            }
        }
    }
}
