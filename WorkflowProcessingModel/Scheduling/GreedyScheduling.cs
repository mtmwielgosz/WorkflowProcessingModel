using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowProcessingModel.Algorithm.Results;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;
using WorkflowProcessingModel.Scheduling.Utils;

namespace WorkflowProcessingModel.Algorithm
{
    public class GreedyScheduling : IScheduling
    {
        public ResultAssociation Schedule(ModelAssociation currentModelAssoscation, MachineEnvironment currentMachineEnvironment, List<Constraint> currentConstraints,
            OptimisationObjective currentOptimisationObjective, DateTime startingWholeProcessingDate)
        {
            // Sort operations on nearest DueDate first
            List<Operation> AllOperations = SchedulingUtlis.GetAllOperations(currentModelAssoscation.AllBatches);
            AllOperations.Sort((operation1, operation2) => operation1.CurrentBatch.DueDate.CompareTo(operation2.CurrentBatch.DueDate));

            List<OperationMachineAssignment> CurrentOperationMachineAssociations = new List<OperationMachineAssignment>();
            foreach (Operation CurrentOperation in AllOperations)
            {
                // Find next available machine for the processing of current operation
                List<Machine> CapableMachines = CurrentOperation.CapableMachinesWithProcessingTime.Keys.ToList();
                CapableMachines.Sort((machine1, machine2) => machine1.NextAvailableStartProcessingDate.CompareTo(machine2.NextAvailableStartProcessingDate));
                Machine ChosenMachine = CapableMachines.First();
                DateTime StartProcessingDate = ChosenMachine.NextAvailableStartProcessingDate;

                // if it isn't the first process on the machine in the scheduling => we have to include setup time
                if (!startingWholeProcessingDate.Equals(StartProcessingDate))
                {
                    SetupForBatch CurrentSetupForBatch = CurrentOperation.SetupTimes
                        .Find(setup => setup.CurrentMachine.Equals(ChosenMachine) && setup.PreviousOperation.Index.Equals(ChosenMachine.CurrentlyProcessedOperation.Index));
                    StartProcessingDate = StartProcessingDate.AddSeconds(CurrentSetupForBatch.SetupTime);
                }

                // Generate next Operation-Machine Association 
                int NeededProcessingTime = CurrentOperation.CapableMachinesWithProcessingTime[ChosenMachine] * CurrentOperation.CurrentBatch.NumberOfJobs;
                DateTime FinishProcessingDate = StartProcessingDate.AddSeconds(NeededProcessingTime);
                CurrentOperationMachineAssociations.Add(new OperationMachineAssignment(CurrentOperation, ChosenMachine, StartProcessingDate, FinishProcessingDate));

                // Update dates for the machine
                ChosenMachine.NextAvailableStartProcessingDate = FinishProcessingDate;
                ChosenMachine.CurrentlyProcessedOperation = CurrentOperation;
            }
            return new ResultAssociation(CurrentOperationMachineAssociations, null, null);
        }
    }
}
