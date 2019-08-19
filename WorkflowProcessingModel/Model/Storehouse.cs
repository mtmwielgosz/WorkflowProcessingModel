using System.Collections.Generic;

namespace WorkflowProcessingModel.Model
{
    class Storehouse
    {
        int Index { get; set; }
        string Name { get; set; }
        Dictionary<Material, int> AvailableMaterials { get; set; }
        double TimeNeededToTransportProductsToProductionHall { get; set; }
    }
}
