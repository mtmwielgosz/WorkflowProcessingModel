using System;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm
{
    class OperationMachineAssignment
    {
        public Operation CurrentOperation { get; set; }
        public Machine CurrentMachine { get; set; }
        public DateTime StartProcessingDate { get; set; }
        public DateTime FinishProcessingDate { get; set; }

        public OperationMachineAssignment(Operation currentOperation, Machine currentMachine, DateTime startProcessingDate, DateTime finishProcessingDate)
        {
            CurrentOperation = currentOperation ?? throw new ArgumentNullException(nameof(currentOperation));
            CurrentMachine = currentMachine ?? throw new ArgumentNullException(nameof(currentMachine));
            StartProcessingDate = startProcessingDate;
            FinishProcessingDate = finishProcessingDate;
        }

        public bool IsBlockedBy(OperationMachineAssignment OtherBatchMachineAssociation)
        {
            return !this.Equals(OtherBatchMachineAssociation) && ((OtherBatchMachineAssociation.FinishProcessingDate < StartProcessingDate)
                                                              || (OtherBatchMachineAssociation.StartProcessingDate > FinishProcessingDate));
        }
    }
}
