using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm;

namespace WorkflowProcessingModel.Validate
{
    interface IValidator
    {
        bool Validate(List<OperationMachineAssignment> BatchMachineAssociationsResult);
    }
}
