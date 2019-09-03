using System;
using System.Collections.Generic;

namespace WorkflowProcessingModel.Model
{
    class Storehouse
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public Dictionary<Material, int> AvailableMaterials { get; set; }
        public int TimeNeededToTransportProductsToProductionHall { get; set; }

        public Storehouse(int index, string name, Dictionary<Material, int> availableMaterials, int timeNeededToTransportProductsToProductionHall)
        {
            Index = index;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            AvailableMaterials = availableMaterials ?? throw new ArgumentNullException(nameof(availableMaterials));
            TimeNeededToTransportProductsToProductionHall = timeNeededToTransportProductsToProductionHall;
        }
    }
}
