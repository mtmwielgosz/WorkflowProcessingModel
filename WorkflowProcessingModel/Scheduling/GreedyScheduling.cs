using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowProcessingModel.Algorithm.Results;
using WorkflowProcessingModel.Factory.SubFactory;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Algorithm
{
    public class GreedyScheduling : IScheduling
    {
        public ResultAssociation Schedule(ModelAssociation currentModelAssoscation, MachineEnvironment currentMachineEnvironment, List<Constraint> currentConstraints,
            OptimisationObjective currentOptimisationObjective, DateTime startingWholeProcessingDate)
        {
            // Sort all batches on nearest Due Date first
            List<Batch> AllBatches = currentModelAssoscation.AllBatches;
            AllBatches.Sort((batch1, batch2) => batch1.DueDate.CompareTo(batch2.DueDate));

            List<OperationMachineAssignment> CurrentOperationMachineAssociations = new List<OperationMachineAssignment>();
            foreach (Batch CurrentBatch in AllBatches)
            {
                List<Operation> CurrentOperations = CurrentBatch.JobInBatch.ListOfOperations;
                foreach (Operation CurrentOperation in CurrentOperations)
                {
                    // First operation in Job will start immidiatelly
                    if (CurrentOperation.ReleaseDate.Equals(DateTime.MaxValue))
                    {
                        CurrentOperation.ReleaseDate = startingWholeProcessingDate;
                    }

                    // Find next available machine for the processing of current operation
                    List<Machine> CapableMachines = CurrentOperation.CapableMachinesWithProcessingTime.Keys.ToList();
                    CapableMachines.Sort((machine1, machine2) => machine1.NextAvailableStartProcessingDate.CompareTo(machine2.NextAvailableStartProcessingDate));
                    Machine ChosenMachine = CapableMachines.First();
                    DateTime StartProcessingDate = CurrentOperation.ReleaseDate;

                    // if it isn't the first process on the machine in the scheduling => we have to include setup time
                    SetupForBatch CurrentSetupForBatch = CurrentOperation.SetupTimes
                        .Find(setup => setup.CurrentMachine.Equals(ChosenMachine)
                        && ChosenMachine.CurrentlyProcessedOperation != null
                        && setup.PreviousOperation.Index.Equals(ChosenMachine.CurrentlyProcessedOperation.Index));

                    // If the machine wasn't able to be setup after previous job -> add setup time
                    if (CurrentSetupForBatch != null && StartProcessingDate.CompareTo(ChosenMachine.NextAvailableStartProcessingDate.AddSeconds(CurrentSetupForBatch.SetupTime)) < 0)
                    {
                        StartProcessingDate = ChosenMachine.NextAvailableStartProcessingDate.AddSeconds(CurrentSetupForBatch.SetupTime);
                    }
                    else
                    {
                        Console.WriteLine("Now " + ChosenMachine.Name + StartProcessingDate);
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
                        ChosenMachine.ResetTimeLeftTillMaintenanceWithAgingEffect();
                        StartProcessingDate = FinishProcessingDate;
                    }

                    // Operation
                    FinishProcessingDate = FinishProcessingDate.AddSeconds(NeededProcessingTime);
                    CurrentOperationMachineAssociations.Add(new OperationMachineAssignment(CurrentOperation, ChosenMachine, StartProcessingDate, FinishProcessingDate));
                    ChosenMachine.TimeLeftTillMaintenance -= NeededProcessingTime;

                    // Update dates for the machine
                    ChosenMachine.NextAvailableStartProcessingDate = FinishProcessingDate;
                    ChosenMachine.CurrentlyProcessedOperation = CurrentOperation;

                    // Next operation can start after previous one in the same job
                    if (CurrentOperation.CurrentJob.GetNextOperation(CurrentOperation) != null)
                    {
                        CurrentOperation.CurrentJob.GetNextOperation(CurrentOperation).ReleaseDate = FinishProcessingDate;
                    }
                }
            }
            return new ResultAssociation(CurrentOperationMachineAssociations, null, null);
        }
    }
}
