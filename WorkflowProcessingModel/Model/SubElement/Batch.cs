using System;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Model
{
    class Batch
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Double PunishmentPerDay { get; set; }
        public Job JobInBatch { get; set; }
        public int NumberOfJobs { get; set; }

        /// <summary> optional, can be null! </summary>
        public Family FamilyOfBatch { get; set; }

        public Batch(int index, string name, DateTime dueDate, double punishmentPerDay, Job jobInBatch, int numberOfJobs, Family familyOfBatch)
        {
            Index = index;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DueDate = dueDate;
            PunishmentPerDay = punishmentPerDay;
            JobInBatch = jobInBatch ?? throw new ArgumentNullException(nameof(jobInBatch));
            NumberOfJobs = numberOfJobs;
            FamilyOfBatch = familyOfBatch;
        }
    }
}
