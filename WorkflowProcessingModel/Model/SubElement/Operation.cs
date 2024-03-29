﻿using System;
using System.Collections.Generic;
using System.Drawing;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Model
{
    public class Operation
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Dictionary<Material, int> MaterialsDemand { get; set; }
        public Dictionary<Machine, int> CapableMachinesWithProcessingTime { get; set; }
        public List<SetupForBatch> SetupTimes { get; set; }
        public List<Move> TimesOfMovingSemiproducts { get; set; }
        public Batch CurrentBatch { get; set; }
        public Job CurrentJob { get; set; }
        public Color GanntChartColor { get; set; }

        public Operation(int index, string name, DateTime releaseDate, Dictionary<Material, int> materialsDemand, Dictionary<Machine, int> capableMachinesWithProductionTime, List<SetupForBatch> setupTimes,
            List<Move> timesOfMovingSemiproducts, Batch currentBatch, Job currentJob, Color ganntChartColor)
        {
            Index = index;
            Name = name;
            MaterialsDemand = materialsDemand;
            CapableMachinesWithProcessingTime = capableMachinesWithProductionTime;
            SetupTimes = setupTimes;
            TimesOfMovingSemiproducts = timesOfMovingSemiproducts;
            CurrentBatch = currentBatch;
            CurrentJob = currentJob;
            GanntChartColor = ganntChartColor;
            ReleaseDate = releaseDate;
        }

        public Operation Clone(int jobIndex)
        {
            return new Operation(this.Index, this.Name + " - clone for Job with index " + jobIndex, this.ReleaseDate, this.MaterialsDemand,
                this.CapableMachinesWithProcessingTime, this.SetupTimes, this.TimesOfMovingSemiproducts, this.CurrentBatch, this.CurrentJob, this.GanntChartColor);
        }
    }
}