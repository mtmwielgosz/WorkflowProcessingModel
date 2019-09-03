using System;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm
{
    class BatchMachineAssignment
    {
        public Batch CurrentBatch { get; set; }
        public Machine CurrentMachine { get; set; }
        public DateTime StartAssociatedTime { get; set; }
        public DateTime EndAssociatedTime { get; set; }

        public BatchMachineAssignment(Batch currentBatch, Machine currentMachine, DateTime startAssociatedTime, DateTime endAssociatedTime)
        {
            if (StartAssociatedTime >= EndAssociatedTime)
            {
                throw new InvalidOperationException(String.Format("startAssociatedTime ({0}) can't be later than endAssociatedTime ({1}).", startAssociatedTime, endAssociatedTime));
            }

            CurrentBatch = currentBatch ?? throw new ArgumentNullException(nameof(currentBatch));
            CurrentMachine = currentMachine ?? throw new ArgumentNullException(nameof(currentMachine));
            StartAssociatedTime = startAssociatedTime;
            EndAssociatedTime = endAssociatedTime;
        }

        public bool IsBlockedBy(BatchMachineAssignment OtherBatchMachineAssociation)
        {
            return !this.Equals(OtherBatchMachineAssociation) && ((OtherBatchMachineAssociation.EndAssociatedTime < StartAssociatedTime)
                                                              || (OtherBatchMachineAssociation.StartAssociatedTime > EndAssociatedTime));
        }
    }
}
