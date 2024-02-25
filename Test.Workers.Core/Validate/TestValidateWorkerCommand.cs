using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Core.Validation;
using Workers.Interfaces.Arguments.Core;
using Workers.Interfaces.Common;
using Workers.Interfaces.DataObjects;

namespace Test.Workers.Core.Validate
{
    [TestClass]
    public class TestValidateWorkerCommand
    {
        private ValidateAddWorkerCommand? validateCommand;

        [TestInitialize]
        public void TestInitialize()
        {
            validateCommand = new ValidateAddWorkerCommand();
        }

        //tests here show value in the core layer. No need for mocking or extensive data gathering. Just testing business logic

        [TestMethod]
        public async Task TestAddNew()
        {
            ValidateAddWorker addWorker = new ValidateAddWorker(new Worker(1, 10, "f1", "l1", "add1", WorkerType.Employee, 1, 2, 3), null);

            CommandResult<Worker> result = await validateCommand.Execute(addWorker);
            Assert.AreEqual(result.StatusCode, 200);
        }

        [TestMethod]
        public async Task TestAddNewWithCollision()
        {
            ValidateAddWorker addWorker = new ValidateAddWorker(new Worker(1, 10, "f1", "l1", "add1", WorkerType.Employee, 1, 2, 3), new Worker(1, 10, "f1", "l1", "add1", WorkerType.Employee, 1, 2, 3));

            CommandResult<Worker> result = await validateCommand.Execute(addWorker);
            Assert.AreEqual(result.StatusCode, 400);
        }

        [TestMethod]
        public async Task TestAddNewWithNameTooLong()
        {
            ValidateAddWorker addWorker = new ValidateAddWorker(new Worker(1, 10, "f1fdgfdsgfdgfdsgfdsgfdsgfdgfdgfdsgdfgdfsgfdgfdgfdsgdfsgfdgsdfgfdgfdgfdgdfgdfsg", "l1", "add1", WorkerType.Employee, 1, 2, 3), null);

            CommandResult<Worker> result = await validateCommand.Execute(addWorker);
            Assert.AreEqual(result.StatusCode, 400);
        }
    }
}
