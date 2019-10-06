using System;
using System.Collections.Generic;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Model
{
    public class Operation
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public Dictionary<Material, int> MaterialsDemand { get; set; }
        public Dictionary<Machine, int> CapableMachinesWithProcessingTime { get; set; }
        public List<SetupForBatch> SetupTimes { get; set; }
        public List<Move> TimesOfMovingSemiproducts { get; set; }
        public Batch CurrentBatch { get; set; }
        public Job CurrentJob { get; set; }

        public Operation(int index, string name, Dictionary<Material, int> materialsDemand, Dictionary<Machine, int> capableMachinesWithProductionTime, List<SetupForBatch> setupTimes,
            List<Move> timesOfMovingSemiproducts, Batch currentBatch, Job currentJob)
        {
            Index = index;
            Name = name;
            MaterialsDemand = materialsDemand ?? throw new ArgumentNullException(nameof(materialsDemand));
            CapableMachinesWithProcessingTime = capableMachinesWithProductionTime ?? throw new ArgumentNullException(nameof(capableMachinesWithProductionTime));
            SetupTimes = setupTimes;
            TimesOfMovingSemiproducts = timesOfMovingSemiproducts ?? throw new ArgumentNullException(nameof(timesOfMovingSemiproducts));
            CurrentBatch = currentBatch;
            CurrentJob = currentJob;
        }

        public Operation Clone(int jobIndex)
        {
            return new Operation(this.Index, this.Name + " - clone for Job with index " + jobIndex, this.MaterialsDemand,
                this.CapableMachinesWithProcessingTime, this.SetupTimes, this.TimesOfMovingSemiproducts, this.CurrentBatch, this.CurrentJob);
        }
    }
}