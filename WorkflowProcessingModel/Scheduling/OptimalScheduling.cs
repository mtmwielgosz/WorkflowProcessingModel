using System;
using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm.Results;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm
{
    class OptimalScheduling : IScheduling
    {
        public ResultAssociation Schedule(ModelAssociation CurrentModel, MachineEnvironment CurrentMachineEnvironment, List<Constraint> CurrentConstraints, OptimisationObjective CurrentOptimisationObjective, DateTime startingWholeProcessingDate)
        {
            throw new NotImplementedException();
        }
    }
}
