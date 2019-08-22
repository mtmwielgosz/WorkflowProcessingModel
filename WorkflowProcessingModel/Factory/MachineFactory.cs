using System;
using System.Collections.Generic;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Factory
{
    class MachineFactory : IFactory<Machine>
    {
        public List<Machine> Generate(int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
