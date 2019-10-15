using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm;
using WorkflowProcessingModel.Algorithm.Results;
using WorkflowProcessingModel.Factory;

namespace WorkflowProcessingModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO generate data


            // TODO
            IScheduling scheduling = new GreedySchedulingSI();

            // TODO 
            // TODO aging effect
            ResultAssociation resultAssociation = scheduling.Schedule(null, MachineEnvironment.SINGLE_MACHINE, new List<Constraint> { Constraint.BATCH_PROCESSING, Constraint.SEQUENCE_DEPENDENT_SETUP_TIME }, OptimisationObjective.MAKESPAN, TimeUtils.GetDateTime("01.01.2020 06:00:00"));


            // TODO print results (ToString)


        }
    }
}
