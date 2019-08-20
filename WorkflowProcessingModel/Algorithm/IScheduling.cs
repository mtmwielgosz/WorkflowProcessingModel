using System.Collections.Generic;
using WorkflowProcessingModel.Algorithm.Results;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm
{
    interface IScheduling
    {
        /// <summary> input </summary>
        ModelAssociation CurrentModel { get; set; }

        /// <summary> main output (optimation result) </summary>
        List<BatchMachineAssociation> BatchMachineAssociationsResult { get; set; }
        /// <summary> extra output </summary>
        List<MaintenanceOccurence> MaintenanceOccurencesResult { get; set; }
        /// <summary> extra output </summary>
        Dictionary<Material, int> ExtraNeededMaterialsResult { get; set; }

        /// <summary>
        /// A scheduling problem is described by a three-field notation α | β | γ proposed by Grahama et al.
        /// </summary>
        /// <param name="CurrentMachineEnvironment">α – machine environment - contains just one entry.</param>
        /// <param name="CurrentConstraints">β – details of processing characteristics and constraints - may contain no entry at all, a single entry, or multiple entries.</param>
        /// <param name="CurrentOptimisationObjective">γ – the objective to be minimized - often contains a single entry.</param>
        void Schedule(MachineEnvironment CurrentMachineEnvironment, List<Constraint> CurrentConstraints, OptimisationObjective CurrentOptimisationObjective);
    }
}
