using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm;
using WorkflowProcessingModel.Validator.SubValidator;

namespace WorkflowProcessingModel.Validate
{
    class MainValidator : IValidator
    {
        private List<IValidator> AllValidators = new List<IValidator> { new MachineNeverBlockedByMoreThanOneBatch() };

        public bool Validate(List<BatchMachineAssignment> BatchMachineAssociationsResult)
        {
            return AllValidators.TrueForAll(Validator => Validate(BatchMachineAssociationsResult));
        }
    }
}
