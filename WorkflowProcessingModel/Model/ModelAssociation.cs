using System;
using System.Collections.Generic;

namespace WorkflowProcessingModel.Model
{
    public class ModelAssociation
    {
        public List<Batch> AllBatches { get; set; }
        public List<Machine> AllMachines { get; set; }
        public Storehouse CurrentStorehouse { get; set; }

        public ModelAssociation(List<Batch> allBatches, List<Machine> allMachines, Storehouse currentStorehouse)
        {
            AllBatches = allBatches ?? throw new ArgumentNullException(nameof(allBatches));
            AllMachines = allMachines ?? throw new ArgumentNullException(nameof(allMachines));
            CurrentStorehouse = currentStorehouse ?? throw new ArgumentNullException(nameof(currentStorehouse));
        }
    }
}
