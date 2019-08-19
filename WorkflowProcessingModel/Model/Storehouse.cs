using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
