using System;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm
{
    class BatchMachineAssociation
    {
        Batch CurrentBatch { get; set; }
        Machine CurrentMachine { get; set; }
        DateTime AssociatedTime { get; set; }
    }
}
