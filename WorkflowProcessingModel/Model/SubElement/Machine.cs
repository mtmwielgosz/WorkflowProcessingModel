using System;

namespace WorkflowProcessingModel.Model
{
    public class Machine
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public int TimeLeftTillMaintenance { get; set; }
        private int OriginalTimeLeftTillMaintenance;
        private int PreviousTimeLeftTillMaintenance;
        public int TimeOfMaintenance { get; set; }
        public int AgingEffectPercentage { get; set; }
        public DateTime NextAvailableStartProcessingDate { get; set; }
        public Operation CurrentlyProcessedOperation { get; set; }

        public Machine(int index, string name, int timeLeftTillMaintenance, int timeOfMaintenance, DateTime nextAvailableStartProcessingDate, Operation currentlyProcessedOperation, int agingEffectProcent)
        {
            Index = index;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            TimeLeftTillMaintenance = timeLeftTillMaintenance;
            PreviousTimeLeftTillMaintenance = timeLeftTillMaintenance;
            OriginalTimeLeftTillMaintenance = timeLeftTillMaintenance;
            TimeOfMaintenance = timeOfMaintenance;
            NextAvailableStartProcessingDate = nextAvailableStartProcessingDate;
            CurrentlyProcessedOperation = currentlyProcessedOperation;
            AgingEffectPercentage = agingEffectProcent;
        }

        public void ResetTimeLeftTillMaintenanceWithAgingEffect()
        {
            TimeLeftTillMaintenance = (PreviousTimeLeftTillMaintenance * (100 - AgingEffectPercentage)) / 100;
            PreviousTimeLeftTillMaintenance = TimeLeftTillMaintenance;

            // buy new machine
            if ((OriginalTimeLeftTillMaintenance / 4) > TimeLeftTillMaintenance)
            {
                PreviousTimeLeftTillMaintenance = OriginalTimeLeftTillMaintenance;
                TimeLeftTillMaintenance = OriginalTimeLeftTillMaintenance;
            }
        }
    }
}