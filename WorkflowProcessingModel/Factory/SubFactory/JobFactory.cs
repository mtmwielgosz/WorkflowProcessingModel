using System.Collections.Generic;
using WorkflowProcessingModel.Factory.Utils;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Factory
{
    class JobFactory
    {
        public static List<Job> GenerateComplexProductionFor(List<Operation> allOperations, int quantity)
        {
            return GenerateFor(allOperations, quantity, true);
        }

        public static List<Job> GenerateSmallScaleFor(List<Operation> allOperations, int quantity)
        {
            return GenerateFor(allOperations, quantity, false);
        }

        private static List<Job> GenerateFor(List<Operation> allOperations, int quantity, bool isComplexProduction)
        {
            List<Job> AllJobs = new List<Job>();
            for (int index = 0; index < quantity; index++)
            {
                AllJobs.Add(new Job(index, ChooseRandomOperations(allOperations, isComplexProduction)));
            }
            return AllJobs;
        }

        private static List<Operation> ChooseRandomOperations(List<Operation> allOperations, bool isComplexProduction)
        {
            int NumberOfOperations = 0;
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
                CollectionUtils.AddUniqeElementToList(ChosenOperations, allOperations);
            }
            return ChosenOperations;
        }



    }
}
