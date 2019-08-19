namespace WorkflowProcessingModel.Model
{
    class Move
    {
        Machine FromMachine { get; set; }
        Machine ToMachine { get; set; }
        double TimeNeededInSec { get; set; }
    }
}