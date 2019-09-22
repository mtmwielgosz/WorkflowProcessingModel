using System;

namespace WorkflowProcessingModel.Model
{
    internal class Machine
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public double TimeLeftTillMaintenance { get; set; }
        public double TimeOfMaintenance { get; set; }

        public Machine(int index, string name, double timeLeftTillMaintenance, double timeOfMaintenance)
        {
            Index = index;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            TimeLeftTillMaintenance = timeLeftTillMaintenance;
            TimeOfMaintenance = timeOfMaintenance;
        }
    }
}