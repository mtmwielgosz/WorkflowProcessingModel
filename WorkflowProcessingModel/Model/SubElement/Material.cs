using System;

namespace WorkflowProcessingModel.Model
{
    public class Material
    {
        public int Index { get; set; }
        public string Name { get; set; }

        public Material(int index, string name)
        {
            Index = index;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}