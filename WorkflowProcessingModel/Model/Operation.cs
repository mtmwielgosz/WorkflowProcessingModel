using System.Collections.Generic;

namespace WorkflowProcessingModel.Model
{
    class Operation
    {
        int Index { get; set; }
        Dictionary<Material, int> MaterialsDemand { get; set; }
        Dictionary<Machine, int> CapableMachinesWithProductionTime { get; set; }
        List<Setup> SetupTimes { get; set; }
        List<Move> TimesOfMovingSemiproducts { get; set; }
    }
}