namespace WorkflowProcessingModel.Model.SubElements
{
    public class SetupForBatch : Setup
    {
        public Operation PreviousOperation { get; set; }

        public SetupForBatch(Machine currentMachine, Operation previousOperation, int setupTime) : base(currentMachine, setupTime)
        {
            PreviousOperation = previousOperation;
        }
    }
}
