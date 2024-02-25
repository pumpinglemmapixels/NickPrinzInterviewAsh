using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers.Interfaces.Common
{
    public interface IQuery<Input, Output>
    {
        public Task<CommandResult<Output>> Get(Input input);
    }
}
