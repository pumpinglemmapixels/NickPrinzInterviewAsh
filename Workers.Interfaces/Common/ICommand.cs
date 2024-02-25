using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers.Interfaces.Common
{
    public interface ICommand<Input, Output>
    {
        public Task<CommandResult<Output>> Execute(Input input);
    }
    public interface ICommand<Input>
    {
        public Task<CommandResult> Execute(Input input);
    }
}
