
using Workers.Interfaces.Common;
using Workers.Interfaces.DataObjects;

namespace Workers.Repository.Queries
{
    public class GetAllWorkersRepoQuery : IQuery<GetAllWorkersRepoQuery, IEnumerable<Worker>>
    {
        //will define data in comments here
        //probably no time to write an actual repo query

        //to start there will just be 1 Worker table
        //Id (int)  indexed
        //SecondaryId (int) will reference the EmployeeId, ManagerId, or SupervisorId assuming those 3 may have collisions with each other
        //FirstName
        //LastName
        //AddressName
        //EmployeeType (int) 0 for employee, 1 for super, 2 for manager
        //PayPerHour   will be unused for super and manager
        //AnnualSalary   will be unused for employee
        //MaxExpenseAccount   will be unused for super and employee


        //if we assume later that EmployeeId, ManagerId, or SupervisorId have collisions and we will later need to get a worker by EmployeeId new tables can be added
        //one new mapping table for each employee type can be added
        //EmployeeId (int)  indexed
        //Id (int)

        //this allows for many new employee types to be added without indexing each id as a new column added to the main Worker table
        //to find by a SecondaryId Select * from EmployeeIdMap, Worker where EmployeeIdMap.EmployeeId = {param} and EmployeeIdMap.Id = Worker.Id



        public async Task<CommandResult<IEnumerable<Worker>>> Get(GetAllWorkersRepoQuery input)
        {
            //just select * from Worker
            //loop through data rows and put each into a Worker object
        }
    }
}
