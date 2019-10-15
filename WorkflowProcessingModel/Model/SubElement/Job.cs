using System;
using System.Collections.Generic;

namespace WorkflowProcessingModel.Model
{
    public class Job
    {
        public int Index { get; set; }
        public List<Operation> ListOfOperations { get; set; }
        public Batch CurrentBatch { get; set; }

        public Job(int index, List<Operation> listOfOperations, Batch currentBatch)
        {
            Index = index;
            ListOfOperations = listOfOperations ?? throw new ArgumentNullException(nameof(listOfOperations));
            CurrentBatch = currentBatch;
        }

        public Operation GetNextOperation(Operation previousOperation)
        {
            int CurrentOperationIndex = ListOfOperations.IndexOf(previousOperation);
            if (CurrentOperationIndex < ListOfOperations.Count - 1)
            {
                return ListOfOperations[CurrentOperationIndex + 1];
            }
            return null;
        }
    }
}