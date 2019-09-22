using System.Collections.Generic;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Factory
{
    class MaterialFactory
    {
        public static List<Material> GenerateFor(int quantity)
        {
            List<Material> GeneratedMaterials = new List<Material>();
            for (int index = 0; index < quantity; index++)
            {
                GeneratedMaterials.Add(new Material(index, "Name" + index));
            }
            return GeneratedMaterials;
        }
    }
}
