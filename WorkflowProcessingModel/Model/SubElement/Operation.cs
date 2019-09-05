using System;
using System.Collections.Generic;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Model
{
    class Operation
    {
        public int Index { get; set; }
        public Dictionary<Material, int> MaterialsDemand { get; set; }
        public Dictionary<Machine, int> CapableMachinesWithProductionTime { get; set; }
        public List<SetupForBatch> SetupTimes { get; set; }
        public List<Move> TimesOfMovingSemiproducts { get; set; }

        public Operation(int index, Dictionary<Material, int> materialsDemand, Dictionary<Machine, int> capableMachinesWithProductionTime, List<SetupForBatch> setupTimes, List<Move> timesOfMovingSemiproducts)
        {
            Index = index;
            MaterialsDemand = materialsDemand ?? throw new ArgumentNullException(nameof(materialsDemand));
            CapableMachinesWithProductionTime = capableMachinesWithProductionTime ?? throw new ArgumentNullException(nameof(capableMachinesWithProductionTime));
            SetupTimes = setupTimes;
            TimesOfMovingSemiproducts = timesOfMovingSemiproducts ?? throw new ArgumentNullException(nameof(timesOfMovingSemiproducts));
        }
    }
}