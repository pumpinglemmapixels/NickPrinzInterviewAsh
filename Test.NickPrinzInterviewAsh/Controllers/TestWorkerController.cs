using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NickPrinzInterviewAsh.Controllers;
using Workers.Interfaces.Arguments.Application;
using Workers.Interfaces.Common;
using Workers.Interfaces.DataObjects;

namespace Test.NickPrinzInterviewAsh.Controllers
{
    [TestClass]
    public class TestWorkerController
    {
        private WorkerController? controller;

        private Mock<ILogger<WorkerController>> logger = new Mock<ILogger<WorkerController>>();//make this a globally available static to get for testing
        private Mock<IQuery<GetAllWorkersApp, IEnumerable<Worker>>> getAllQuery = new Mock<IQuery<GetAllWorkersApp, IEnumerable<Worker>>>();
        private Mock<ICommand<AddWorkerApp, Worker>> insertCommand = new Mock<ICommand<AddWorkerApp, Worker>> ();

        [TestInitialize]
        public void TestInitialize()
        {
            controller = new WorkerController(logger.Object, getAllQuery.Object, insertCommand.Object);
        }

        [TestMethod]
        public async Task TestGetAllWorkers()
        {
            getAllQuery.Setup(x => x.Get(It.IsAny<GetAllWorkersApp>())).ReturnsAsync(
                new CommandResult<IEnumerable<Worker>>(
                    new List<Worker> { new Worker(1, 10, "f1", "l1", "add1", WorkerType.Employee, 1,2,3), new Worker(2, 20, "f2", "l2", "add2", WorkerType.Supervisor, 4, 5, 6) }
            ));
            IEnumerable<WorkerDto> result = await controller.GetAll();
            List<WorkerDto> listResult = result.ToList();
            Assert.AreEqual(listResult.Count, 2);
        }

        [TestMethod]
        public async Task TestAddWorker()
        {
            insertCommand.Setup(x => x.Execute(It.IsAny<AddWorkerApp>())).ReturnsAsync(
                new CommandResult<Worker>(
                    new Worker(1, 10, "f1", "l1", "add1", WorkerType.Employee, 1, 2, 3)
            ));
            WorkerDto result = await controller.AddWorker();
            Assert.AreEqual(result.FirstName, f1);
        }

    }
}
