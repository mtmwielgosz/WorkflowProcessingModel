namespace WorkflowProcessingModel.Model.SubElements
{
    class SetupForBatch : Setup
    {
        public Operation PreviousOperation { get; set; }

        public SetupForBatch(Operation previousOperation, Machine currentMachine, double setupTime) : base(currentMachine, setupTime)
        {
            PreviousOperation = previousOperation;
        }
    }
}
