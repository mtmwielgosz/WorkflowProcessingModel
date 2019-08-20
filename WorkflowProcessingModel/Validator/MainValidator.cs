using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm;
using WorkflowProcessingModel.Validator.SubValidator;

namespace WorkflowProcessingModel.Validate
{
    class MainValidator : IValidator
    {
        // TODO Add Validators
        private List<IValidator> AllValidators = new List<IValidator> { new MachineNeverBlockedByMoreThanOneBatch(), new BatchMachineAssociationsTimesValid() };

        public bool Validate(List<BatchMachineAssociation> BatchMachineAssociationsResult)
        {
            return AllValidators.TrueForAll(Validator => Validate(BatchMachineAssociationsResult));
        }
    }
}
