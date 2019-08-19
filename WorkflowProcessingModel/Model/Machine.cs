namespace WorkflowProcessingModel.Model
{
    internal class Machine
    {
        int Index { get; set; }
        string Name { get; set; }
        double TimeLeftTillMaintenance { get; set; }
        double TimeOfMaintenance { get; set; }
    }
}