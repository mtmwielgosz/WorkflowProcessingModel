using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowProcessingModel.Algorithm.Results;
using WorkflowProcessingModel.Factory;
using WorkflowProcessingModel.Factory.SubFactory;
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
            // Sort all operations on nearest Due Date first
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

                // Calculate processing time
                int NeededProcessingTime = CurrentOperation.CapableMachinesWithProcessingTime[ChosenMachine] * CurrentOperation.CurrentBatch.NumberOfJobs;

                // Include maintenance
                DateTime FinishProcessingDate = StartProcessingDate;
                while (NeededProcessingTime > ChosenMachine.TimeLeftTillMaintenance)
                {
                    // Operation before maintenance
                    FinishProcessingDate = FinishProcessingDate.AddSeconds(ChosenMachine.TimeLeftTillMaintenance);
                    CurrentOperationMachineAssociations.Add
                        (new OperationMachineAssignment(CurrentOperation, ChosenMachine, StartProcessingDate, FinishProcessingDate));
                    NeededProcessingTime -= ChosenMachine.TimeLeftTillMaintenance;
                    StartProcessingDate = FinishProcessingDate;

                    // Maintenance
                    FinishProcessingDate = StartProcessingDate.AddSeconds(ChosenMachine.TimeOfMaintenance);
                    CurrentOperationMachineAssociations.Add
                        (new OperationMachineAssignment(OperationFactory.generateMaintenance(), ChosenMachine, StartProcessingDate, FinishProcessingDate));
                    ChosenMachine.TimeLeftTillMaintenance = RandomGenerator.MachineTimeLeftTillMaintenanceForSmallScaleProduction();
                    StartProcessingDate = FinishProcessingDate;
                }

                // Operation
                FinishProcessingDate = FinishProcessingDate.AddSeconds(NeededProcessingTime);
                CurrentOperationMachineAssociations.Add(new OperationMachineAssignment(CurrentOperation, ChosenMachine, StartProcessingDate, FinishProcessingDate));
                ChosenMachine.TimeLeftTillMaintenance -= NeededProcessingTime;

                // Update dates for the machine
                ChosenMachine.NextAvailableStartProcessingDate = FinishProcessingDate;
                ChosenMachine.CurrentlyProcessedOperation = CurrentOperation;
            }
            return new ResultAssociation(CurrentOperationMachineAssociations, null, null);
        }
    }
}
