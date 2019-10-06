using System;

namespace WorkflowProcessingModel.Model
{
    public abstract class Setup
    {
        public Machine CurrentMachine { get; set; }
        public int SetupTime { get; set; }

        public Setup(Machine currentMachine, int setupTime)
        {
            CurrentMachine = currentMachine ?? throw new ArgumentNullException(nameof(currentMachine));
            SetupTime = setupTime;
        }
    }
}