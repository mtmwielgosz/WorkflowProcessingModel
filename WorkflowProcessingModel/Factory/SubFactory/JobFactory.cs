using System.Collections.Generic;
using WorkflowProcessingModel.Factory.Utils;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Factory
{
    class JobFactory
    {
        public static List<Job> GenerateComplexProductionFor(List<Operation> allOperations, Batch currentBatch, int quantity)
        {
            return GenerateFor(allOperations, currentBatch, quantity, true);
        }

        public static List<Job> GenerateSmallScaleProductionFor(List<Operation> allOperations, Batch currentBatch, int quantity)
        {
            return GenerateFor(allOperations, currentBatch, quantity, false);
        }

        private static List<Job> GenerateFor(List<Operation> allOperations, Batch currentBatch, int quantity, bool isComplexProduction)
        {
            List<Job> AllJobs = new List<Job>();
            for (int index = 0; index < quantity; index++)
            {
                AllJobs.Add(new Job(index, ChooseRandomOperations(allOperations, index, isComplexProduction), currentBatch));
            }
            return AllJobs;
        }

        private static List<Operation> ChooseRandomOperations(List<Operation> allOperations, int jobIndex, bool isComplexProduction)
        {
            int NumberOfOperations = 0;
            List<Operation> CloneOfOperations = allOperations.ConvertAll(operation => operation.Clone(jobIndex));
            if (isComplexProduction)
            {
                NumberOfOperations = RandomGenerator.OperationsInJobForComplexProduction();
            }
            else
            {
                NumberOfOperations = RandomGenerator.OperationsInJobForSmallScaleProduction();
            }

            List<Operation> ChosenOperations = new List<Operation>();
            for (int index = 0; index < NumberOfOperations; index++)
            {
                CollectionUtils.AddUniqeElementToList(ChosenOperations, CloneOfOperations);
            }
            return ChosenOperations;
        }



    }
}
