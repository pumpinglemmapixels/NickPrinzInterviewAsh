using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Workers.Interfaces.DataObjects
{
    //having implementations in a common library does break dependency injection a little, but the alternative is to make an interface that gets implemented as below in multiple project
    //the comprise is to keep the implemented object free of any logic
    public class Worker(int id, int secondaryId, string firstName, string lastName, string address, WorkerType workerType, decimal payPerHour, decimal annualSalary, decimal maxExpenseAmount)
    {
        public int Id { get; set; } = id;
        public int SecondaryId { get; set; } = secondaryId;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Address { get; set; } = address;
        public WorkerType WorkerType { get; set; } = workerType;
        public decimal PayPerHour { get; set; } = payPerHour;
        public decimal AnnualSalary { get; set; } = annualSalary;
        public decimal MaxExpenseAmount { get; set; } = maxExpenseAmount;
    }
}
}
