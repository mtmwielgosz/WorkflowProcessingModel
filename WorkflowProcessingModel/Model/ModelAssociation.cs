using System;
using System.Collections.Generic;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Model
{
    class ModelAssociation
    {
        public List<Family> FamiliesBatches { get; set; }
        public List<Batch> AllBatches { get; set; }
        public List<Machine> AllMachines { get; set; }
        public List<Storehouse> AllStorehouses { get; set; }

        public ModelAssociation(List<Family> familiesBatches, List<Batch> allBatches, List<Machine> allMachines, List<Storehouse> allStorehouses)
        {
            FamiliesBatches = familiesBatches ?? throw new ArgumentNullException(nameof(familiesBatches));
            AllBatches = allBatches ?? throw new ArgumentNullException(nameof(allBatches));
            AllMachines = allMachines ?? throw new ArgumentNullException(nameof(allMachines));
            AllStorehouses = allStorehouses ?? throw new ArgumentNullException(nameof(allStorehouses));
        }
    }
}
