using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm.Results;
using WorkflowProcessingModel.Factory;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm
{
    class GreedyScheduling : IScheduling
    {
        // TODO implement
        public ResultAssociation Schedule(ModelAssociation CurrentModel, MachineEnvironment CurrentMachineEnvironment, List<Constraint> CurrentConstraints, OptimisationObjective CurrentOptimisationObjective)
        {
            ModelAssociation CurrentModelAssocation = ModelAssociationFactory.GenerateComplexProductionWithFamiliesFor(100, 25, 30, 120, 6);

            return null;
        }
    }
}
