using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowProcessingModel.Algorithm.Results;
using WorkflowProcessingModel.Factory;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Scheduling.Utils;

namespace WorkflowProcessingModel.Algorithm
{
    public class GreedyScheduling : IScheduling
    {
        // TODO implement
        public ResultAssociation Schedule(ModelAssociation CurrentModel, MachineEnvironment CurrentMachineEnvironment, List<Constraint> CurrentConstraints,
            OptimisationObjective CurrentOptimisationObjective)
        {
            ModelAssociation CurrentModelAssocation = ModelAssociationFactory.GenerateComplexProductionWithFamiliesFor(TimeUtils.GetDateTime("01.01.2020 06:00:00"), 100, 50, 100, 300, 6);
            List<Operation> AllOperations = SchedulingUtlis.GetAllOperations(CurrentModelAssocation.AllBatches);
            AllOperations.Sort((operation1, operation2) => operation1.CurrentBatch.DueDate.CompareTo(operation2.CurrentBatch.DueDate));

            List<OperationMachineAssignment> CurrentOperationMachineAssociations = new List<OperationMachineAssignment>();
            foreach (Operation CurrentOperation in AllOperations)
            {
                List<Machine> CapableMachines = CurrentOperation.CapableMachinesWithProcessingTime.Keys.ToList();
                CapableMachines.Sort((machine1, machine2) => machine1.NextAvailableStartProcessingDate.CompareTo(machine2.NextAvailableStartProcessingDate));
                Machine ChosenMachine = CapableMachines.First();

                DateTime startProcessingDate = ChosenMachine.NextAvailableStartProcessingDate;

                int neededTime = CurrentOperation.CapableMachinesWithProcessingTime[ChosenMachine] * CurrentOperation.CurrentBatch.NumberOfJobs;
                DateTime finishProcessingDate = startProcessingDate.AddSeconds(neededTime);
                CurrentOperationMachineAssociations.Add(new OperationMachineAssignment(CurrentOperation, ChosenMachine, startProcessingDate, finishProcessingDate));
                ChosenMachine.NextAvailableStartProcessingDate = finishProcessingDate;
            }


            return new ResultAssociation(CurrentOperationMachineAssociations, null, null);

        }
    }
}
