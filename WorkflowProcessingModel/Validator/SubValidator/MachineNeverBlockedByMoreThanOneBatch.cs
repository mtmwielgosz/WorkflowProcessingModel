using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Validate;

namespace WorkflowProcessingModel.Validator.SubValidator
{
    class MachineNeverBlockedByMoreThanOneBatch : IValidator
    {
        public bool Validate(List<BatchMachineAssignment> BatchMachineAssociationsResult)
        {
            List<Machine> ValidatedMachines = new List<Machine>();
            foreach (BatchMachineAssignment CurrentBatchMachineAssociation in BatchMachineAssociationsResult)
            {
                Machine CurrentMachine = CurrentBatchMachineAssociation.CurrentMachine;
                if (!ValidatedMachines.Contains(CurrentMachine))
                {
                    List<BatchMachineAssignment> MachineBlockingBatches = BatchMachineAssociationsResult.FindAll
                        (SubBatchMachineAssociation => SubBatchMachineAssociation.CurrentMachine.Equals(CurrentMachine));

                    foreach (BatchMachineAssignment CurrentMachineBlockingBatch in MachineBlockingBatches)
                    {
                        // If exists at least one Batch-Machine Association, which takes place in the same time as another Batch-Machine Association -> the result is not valid.
                        // The same Machine can't be used in more than one Batch at the same time. 
                        if (MachineBlockingBatches.Exists(SubMachineBlockingBatch => SubMachineBlockingBatch.IsBlockedBy(CurrentMachineBlockingBatch)))
                        {
                            return false;
                        }

                    }
                    ValidatedMachines.Add(CurrentMachine);
                }
            }
            return true;
        }

    }
}
