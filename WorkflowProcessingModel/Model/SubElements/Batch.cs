using System;

namespace WorkflowProcessingModel.Model
{
    class Batch
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Double PunishmentPetDay { get; set; }
        public Job JobInBatch { get; set; }
        public int NumerOfJobs { get; set; }

        public Batch(int index, string name, DateTime dueDate, double punishmentPetDay, Job jobInBatch, int numerOfJobs)
        {
            Index = index;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DueDate = dueDate;
            PunishmentPetDay = punishmentPetDay;
            JobInBatch = jobInBatch ?? throw new ArgumentNullException(nameof(jobInBatch));
            NumerOfJobs = numerOfJobs;
        }
    }
}
