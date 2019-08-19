using System;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm
{
    class BatchMachineAssociation
    {
        public Batch CurrentBatch { get; set; }
        public Machine CurrentMachine { get; set; }
        public DateTime StartAssociatedTime { get; set; }
        public DateTime EndAssociatedTime { get; set; }

        public bool IsAssociatedTimeValid()
        {
            return StartAssociatedTime < EndAssociatedTime;
        }

        public bool IsBlockedBy(BatchMachineAssociation OtherBatchMachineAssociation)
        {
            return !this.Equals(OtherBatchMachineAssociation) && ((OtherBatchMachineAssociation.EndAssociatedTime < StartAssociatedTime)
                                                              || (OtherBatchMachineAssociation.StartAssociatedTime > EndAssociatedTime));
        }
    }
}
