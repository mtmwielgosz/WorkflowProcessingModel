using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowProcessingModel.Algorithm.Results;
using WorkflowProcessingModel.Factory;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;
using WorkflowProcessingModel.Scheduling.Utils;

namespace WorkflowProcessingModel.Algorithm
{
    public class GreedyScheduling : IScheduling
    {
        public ResultAssociation Schedule(ModelAssociation CurrentModel, MachineEnvironment CurrentMachineEnvironment, List<Constraint> CurrentConstraints,
            OptimisationObjective CurrentOptimisationObjective)
        {
            DateTime startingWholeProcessingDate = TimeUtils.GetDateTime("01.01.2020 06:00:00");
            ModelAssociation CurrentModelAssocation = ModelAssociationFactory.GenerateComplexProductionWithFamiliesFor(startingWholeProcessingDate, 100, 15, 20, 50, 6);
            List<Operation> AllOperations = SchedulingUtlis.GetAllOperations(CurrentModelAssocation.AllBatches);
            AllOperations.Sort((operation1, operation2) => operation1.CurrentBatch.DueDate.CompareTo(operation2.CurrentBatch.DueDate));

            List<OperationMachineAssignment> CurrentOperationMachineAssociations = new List<OperationMachineAssignment>();
            foreach (Operation CurrentOperation in AllOperations)
            {
                List<Machine> CapableMachines = CurrentOperation.CapableMachinesWithProcessingTime.Keys.ToList();
                CapableMachines.Sort((machine1, machine2) => machine1.NextAvailableStartProcessingDate.CompareTo(machine2.NextAvailableStartProcessingDate));
                Machine ChosenMachine = CapableMachines.First();

                DateTime startProcessingDate = ChosenMachine.NextAvailableStartProcessingDate;

                if (!startingWholeProcessingDate.Equals(startProcessingDate))
                {
                    SetupForBatch sfb = CurrentOperation.SetupTimes
                        .Find(setup => setup.CurrentMachine.Equals(ChosenMachine) && setup.PreviousOperation.Index.Equals(ChosenMachine.CurrentlyProcessedOperation.Index));

                    startProcessingDate = startProcessingDate.AddSeconds(sfb.SetupTime);
                }

                int neededTime = CurrentOperation.CapableMachinesWithProcessingTime[ChosenMachine] * CurrentOperation.CurrentBatch.NumberOfJobs;
                DateTime finishProcessingDate = startProcessingDate.AddSeconds(neededTime);
                CurrentOperationMachineAssociations.Add(new OperationMachineAssignment(CurrentOperation, ChosenMachine, startProcessingDate, finishProcessingDate));
                ChosenMachine.NextAvailableStartProcessingDate = finishProcessingDate;
                ChosenMachine.CurrentlyProcessedOperation = CurrentOperation;

            }


            return new ResultAssociation(CurrentOperationMachineAssociations, null, null);

        }
    }
}
