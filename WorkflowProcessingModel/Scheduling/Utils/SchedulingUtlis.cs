using System.Collections.Generic;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Scheduling.Utils
{
    class SchedulingUtlis
    {
        public static List<Operation> GetAllOperations(List<Batch> allBatches)
        {
            List<Operation> AllOperations = new List<Operation>();
            foreach (Batch CurrentBatch in allBatches)
            {
                AllOperations.AddRange(CurrentBatch.JobInBatch.ListOfOperations);
            }
            return AllOperations;
        }
    }
}
