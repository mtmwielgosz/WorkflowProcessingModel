using System;
using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm.Results;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm
{
    public interface IScheduling
    {

        /// <summary>
        /// A scheduling problem is described by a three-field notation α | β | γ proposed by Grahama et al.
        /// </summary>
        /// <param name="CurrentModel">Current model to be optimalised.</param>
        /// <param name="CurrentMachineEnvironment">α – machine environment - contains just one entry.</param>
        /// <param name="CurrentConstraints">β – details of processing characteristics and constraints - may contain no entry at all, a single entry, or multiple entries.</param>
        /// <param name="CurrentOptimisationObjective">γ – the objective to be minimized - often contains a single entry.</param>
        /// <returns>The result of optimisation.</returns>
        ResultAssociation Schedule(ModelAssociation CurrentModel, MachineEnvironment CurrentMachineEnvironment,
            List<Constraint> CurrentConstraints, OptimisationObjective CurrentOptimisationObjective, DateTime startingWholeProcessingDate);
    }
}
