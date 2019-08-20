using System;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Model
{
    internal class Setup
    {
        public Operation PreviousOperation { get; set; }
        public Family PreviousFamily { get; set; }
        public Machine CurrentMachine { get; set; }
        public double SetupTime { get; set; }

        public Setup(Operation previousOperation, Family previousFamily, Machine currentMachine, double setupTime)
        {
            PreviousOperation = previousOperation ?? throw new ArgumentNullException(nameof(previousOperation));
            PreviousFamily = previousFamily ?? throw new ArgumentNullException(nameof(previousFamily));
            CurrentMachine = currentMachine ?? throw new ArgumentNullException(nameof(currentMachine));
            SetupTime = setupTime;
        }
    }
}