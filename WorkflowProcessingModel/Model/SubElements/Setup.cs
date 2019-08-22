using System;

namespace WorkflowProcessingModel.Model
{
    abstract class Setup
    {
        public Machine CurrentMachine { get; set; }
        public double SetupTime { get; set; }

        public Setup(Machine currentMachine, double setupTime)
        {
            CurrentMachine = currentMachine ?? throw new ArgumentNullException(nameof(currentMachine));
            SetupTime = setupTime;
        }
    }
}