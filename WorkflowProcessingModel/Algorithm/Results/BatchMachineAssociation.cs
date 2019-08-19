using System;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm
{
    class BatchMachineAssignation
    {
        Batch CurrentBatch { get; set; }
        Machine CurrentMachine { get; set; }
        DateTime AssociatedTime { get; set; }
    }
}
