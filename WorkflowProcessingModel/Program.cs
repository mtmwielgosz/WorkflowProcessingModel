using System;
using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO generate data
            List<Family> familiesBatches = null;
            List<Batch> allBatches = null;
            List<Machine> allMachines = null;
            List<Storehouse> allStorehouses = null;
            ModelAssociation model = new ModelAssociation(familiesBatches, allBatches, allMachines, allStorehouses);

            // TODO replace interface with implementation
            IScheduling scheduling = null;
            scheduling.CurrentModel = model;

            // TODO set parameters higher
            scheduling.Schedule(MachineEnvironment.SINGLE_MACHINE, new List<Constraint> { Constraint.BATCH_PROCESSING, Constraint.SEQUENCE_DEPENDENT_SETUP_TIME }, OptimisationObjective.MAKESPAN);

            // TODO print results (ToString)
            Console.WriteLine(scheduling.BatchMachineAssociationsResult);
            Console.WriteLine(scheduling.MaintenanceOccurencesResult);
            Console.WriteLine(scheduling.ExtraNeededMaterialsResult);
        }
    }
}
