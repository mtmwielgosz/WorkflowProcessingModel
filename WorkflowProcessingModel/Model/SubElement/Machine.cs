using System;

namespace WorkflowProcessingModel.Model
{
    public class Machine
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public int TimeLeftTillMaintenance { get; set; }
        public int TimeOfMaintenance { get; set; }
        public DateTime NextAvailableStartProcessingDate { get; set; }

        public Machine(int index, string name, int timeLeftTillMaintenance, int timeOfMaintenance, DateTime nextAvailableStartProcessingDate)
        {
            Index = index;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            TimeLeftTillMaintenance = timeLeftTillMaintenance;
            TimeOfMaintenance = timeOfMaintenance;
            NextAvailableStartProcessingDate = nextAvailableStartProcessingDate;
        }
    }
}