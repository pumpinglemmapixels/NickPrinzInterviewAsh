using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Interfaces.Common;
using Workers.Interfaces.DataObjects;

namespace Workers.Application.Queries
{
    public class GetAllWorkersApplicationQuery : IQuery<GetAllWorkersApplicationQuery, IEnumerable<Worker>>
    {
        public async Task<CommandResult<IEnumerable<Worker>>> Get(GetAllWorkersApplicationQuery input)
        {
            //will just pass through to the repo query


            throw new NotImplementedException();
        }
    }
}
