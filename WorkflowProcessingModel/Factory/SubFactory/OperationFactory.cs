using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowProcessingModel.Factory.Utils;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElement;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory.SubFactory
{
    class OperationFactory
    {

        public static List<Operation> GenerateComplexProductionFor(List<Machine> allMachines, List<Material> allMaterials, Batch currentBatch, Job currentJob, int quantity)
        {
            return GenerateFor(allMachines, allMaterials, currentBatch, currentJob, quantity, true);
        }

        public static List<Operation> GenerateSmallScaleProductionFor(List<Machine> allMachines, List<Material> allMaterials, Batch currentBatch, Job currentJob, int quantity)
        {
            return GenerateFor(allMachines, allMaterials, currentBatch, currentJob, quantity, false);
        }

        private static List<Operation> GenerateFor(List<Machine> allMachines, List<Material> allMaterials, Batch currentBatch, Job currentJob, int quantity, bool isComplexProduction)
        {
            List<Operation> AllOperations = new List<Operation>();
            List<Machine> CurrentCapableMachines = new List<Machine>();
            for (int OperationIndex = 0; OperationIndex < quantity; OperationIndex++)
            {
                int numberOfMaterials = RandomGenerator.MaterialsInOperation();
                Dictionary<Material, int> CurrentMaterialsDemand = new Dictionary<Material, int>();
                for (int MaterialIndex = 0; MaterialIndex < numberOfMaterials && MaterialIndex < allMaterials.Count; MaterialIndex++)
                {
                    CollectionUtils.AddUniqeElementToDictionary(CurrentMaterialsDemand, allMaterials, RandomGenerator.MaterialsDemandInOperation());
                }

                int numberOfMachines = RandomGenerator.MachinesInOperation();
                Dictionary<Machine, int> CurrentCapableMachinesWithProductionTime = new Dictionary<Machine, int>();
                for (int MachineIndex = 0; MachineIndex < numberOfMachines && MachineIndex < allMachines.Count; MachineIndex++)
                {
                    CollectionUtils.AddUniqeElementToDictionary(CurrentCapableMachinesWithProductionTime, allMachines, RandomGenerator.ProductionTimeForMachinesInOperation());
                }

                CurrentCapableMachines = new List<Machine>(CurrentCapableMachinesWithProductionTime.Keys);

                AllOperations.Add(new Operation(OperationIndex, "Operation" + OperationIndex, DateTime.MaxValue, CurrentMaterialsDemand, CurrentCapableMachinesWithProductionTime, null,
                    MoveFactory.GenerateFor(CurrentCapableMachines), currentBatch, currentJob, RandomGenerator.ColorForChart())); // no setup times yet
            }

            foreach (Operation CurrentOperation in AllOperations)
            {
                List<SetupForBatch> CurrentSetupTimes = new List<SetupForBatch>();
                foreach (Operation PreviousOperation in AllOperations)
                {

                    foreach (Machine CurrentMachine in CurrentOperation.CapableMachinesWithProcessingTime.Keys.ToList())
                    {
                        if (CurrentOperation.Equals(PreviousOperation))
                        {
                            CurrentSetupTimes.Add(new SetupForBatch(CurrentMachine, PreviousOperation, 0));
                        }
                        else if (isComplexProduction)
                        {
                            CurrentSetupTimes.Add(SetupFactory.GenerateComplexProductionFor(CurrentMachine, PreviousOperation));
                        }
                        else
                        {
                            CurrentSetupTimes.Add(SetupFactory.GenerateSmallScaleProductionFor(CurrentMachine, PreviousOperation));
                        }
                    }

                }
                CurrentOperation.SetupTimes = CurrentSetupTimes;
            }

            return AllOperations;
        }

        public static Maintenance generateMaintenance()
        {
            return new Maintenance();
        }
    }
}
