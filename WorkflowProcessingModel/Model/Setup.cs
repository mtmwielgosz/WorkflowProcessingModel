namespace WorkflowProcessingModel.Model
{
    internal class Setup
    {
        Operation PreviousOperation { get; set; }
        Machine CurrentMachine { get; set; }
        double SetupTime { get; set; }
    }
}