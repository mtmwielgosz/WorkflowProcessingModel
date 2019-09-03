using System.Collections.Generic;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Factory
{
    class StorehouseFactory
    {
        public Storehouse GenerateFor(List<Material> allMaterials)
        {

            Dictionary<Material, int> AvailableMaterials = new Dictionary<Material, int>();
            foreach (Material CurrentMaterial in allMaterials)
            {
                AvailableMaterials.Add(CurrentMaterial, RandomGenerator.NumberOfAvailableMaterials());
            }
            return new Storehouse(0, "Storehouse", AvailableMaterials, RandomGenerator.TimeNeededToTransportProductsToProductionHall());
        }
    }
}
