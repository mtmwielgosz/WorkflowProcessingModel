using System;
using System.Collections.Generic;

namespace WorkflowProcessingModel.Model
{
    class Job
    {
        public int Index { get; set; }
        public List<Operation> ListOfOperations { get; set; }

        public Job(int index, List<Operation> listOfOperations)
        {
            Index = index;
            ListOfOperations = listOfOperations ?? throw new ArgumentNullException(nameof(listOfOperations));
        }
    }
}