using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm;
using WorkflowProcessingModel.Validate;

namespace WorkflowProcessingModel.Validator.SubValidator
{
    class BatchMachineAssociationsTimesValid : IValidator
    {
        public bool Validate(List<BatchMachineAssociation> BatchMachineAssociationsResult)
        {
            return BatchMachineAssociationsResult.TrueForAll(BatchMachineAssociation => BatchMachineAssociation.IsAssociatedTimeValid());
        }
    }
}
