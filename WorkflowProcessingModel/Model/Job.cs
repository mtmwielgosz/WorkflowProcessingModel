using System.Collections.Generic;

namespace WorkflowProcessingModel.Model
{
    class Job
    {
        int Index { get; set; }
        List<Operation> ListOfOperations { get; set; }
    }
}