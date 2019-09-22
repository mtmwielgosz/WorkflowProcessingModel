using System.Collections.Generic;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory
{
    class BatchFactory
    {

        public static List<Batch> GenerateWithoutFamiliesFor(List<Job> allJobs)
        {
            return GenerateFor(allJobs, null);
        }

        public static List<Batch> GenerateWithFamiliesFor(List<Job> allJobs, List<Family> allFamilies)
        {
            return GenerateFor(allJobs, allFamilies);
        }

        private static List<Batch> GenerateFor(List<Job> allJobs, List<Family> allFamilies)
        {
            List<Batch> AllBatches = new List<Batch>();
            foreach (Job CurrentJob in allJobs)
            {
                Family ChosenFamily = null;
                if (allFamilies != null)
                {
                    ChosenFamily = RandomGenerator.RandomElement(allFamilies);
                }
                AllBatches.Add(new Batch(CurrentJob.Index, "Batch" + CurrentJob.Index, RandomGenerator.DueDate(),
                    RandomGenerator.PunishmentPerDay(), CurrentJob, RandomGenerator.JobsInBatch(), ChosenFamily));
            }
            return AllBatches;
        }

    }
}
