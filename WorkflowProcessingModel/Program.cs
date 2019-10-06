using System;
using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm;
using WorkflowProcessingModel.Algorithm.Results;

namespace WorkflowProcessingModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO generate data


            // TODO
            IScheduling scheduling = new GreedyScheduling();

            // TODO 
            // TODO aging effect
            ResultAssociation resultAssociation = scheduling.Schedule(null, MachineEnvironment.SINGLE_MACHINE, new List<Constraint> { Constraint.BATCH_PROCESSING, Constraint.SEQUENCE_DEPENDENT_SETUP_TIME }, OptimisationObjective.MAKESPAN);


            // TODO print results (ToString)
            Console.WriteLine(resultAssociation);

        }
    }
}
