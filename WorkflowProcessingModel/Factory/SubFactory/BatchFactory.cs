using System;
using System.Collections.Generic;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory
{
    class BatchFactory
    {

        public static List<Batch> GenerateWithoutFamiliesFor(DateTime startProcessingDate, List<Job> allJobs)
        {
            return GenerateFor(startProcessingDate, allJobs, null);
        }

        public static List<Batch> GenerateWithFamiliesFor(DateTime startProcessingDate, List<Job> allJobs, List<Family> allFamilies)
        {
            return GenerateFor(startProcessingDate, allJobs, allFamilies);
        }

        private static List<Batch> GenerateFor(DateTime startProcessingDate, List<Job> allJobs, List<Family> allFamilies)
        {
            List<Batch> AllBatches = new List<Batch>();
            foreach (Job CurrentJob in allJobs)
            {
                Family ChosenFamily = null;
                if (allFamilies != null)
                {
                    ChosenFamily = RandomGenerator.RandomElement(allFamilies);
                }
                Batch GeneratedBatch = new Batch(CurrentJob.Index, "Batch" + CurrentJob.Index, RandomGenerator.DueDate(startProcessingDate),
                    RandomGenerator.PenaltyPerDay(), CurrentJob, RandomGenerator.JobsInBatch(), ChosenFamily);
                FillBatchAndJobInformationInJobsAndOperations(GeneratedBatch);
                AllBatches.Add(GeneratedBatch);

            }
            return AllBatches;
        }

        private static void FillBatchAndJobInformationInJobsAndOperations(Batch generatedBatch)
        {
            Job CurrentJob = generatedBatch.JobInBatch;
            CurrentJob.CurrentBatch = generatedBatch;
            foreach (Operation CurrentOperation in CurrentJob.ListOfOperations)
            {
                CurrentOperation.CurrentBatch = generatedBatch;
                CurrentOperation.CurrentJob = CurrentJob;
            }
        }
    }
}
