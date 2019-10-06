using System.Collections.Generic;
using WorkflowProcessingModel.Factory.Utils;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory.SubFactory
{
    class OperationFactory
    {

        public static List<Operation> GenerateComplexProductionFor(List<Machine> allMachines, List<Material> allMaterials, Batch currentBatch, int quantity)
        {
            return GenerateFor(allMachines, allMaterials, currentBatch, quantity, true);
        }

        public static List<Operation> GenerateSmallScaleProductionFor(List<Machine> allMachines, List<Material> allMaterials, Batch currentBatch, int quantity)
        {
            return GenerateFor(allMachines, allMaterials, currentBatch, quantity, false);
        }

        private static List<Operation> GenerateFor(List<Machine> allMachines, List<Material> allMaterials, Batch currentBatch, int quantity, bool isComplexProduction)
        {
            List<Operation> AllOperations = new List<Operation>();
            List<Machine> CurrentCapableMachines = new List<Machine>();
            for (int OperationIndex = 0; OperationIndex < quantity; OperationIndex++)
            {
                int numberOfMaterials = RandomGenerator.MaterialsInOperation();
                Dictionary<Material, int> CurrentMaterialsDemand = new Dictionary<Material, int>();
                for (int MaterialIindex = 0; MaterialIindex < numberOfMaterials; MaterialIindex++)
                {
                    CollectionUtils.AddUniqeElementToDictionary(CurrentMaterialsDemand, allMaterials, RandomGenerator.MaterialsDemandInOperation());
                }

                int numberOfMachines = RandomGenerator.MachinesInOperation();
                Dictionary<Machine, int> CurrentCapableMachinesWithProductionTime = new Dictionary<Machine, int>();
                for (int MachineIindex = 0; MachineIindex < numberOfMachines; MachineIindex++)
                {
                    CollectionUtils.AddUniqeElementToDictionary(CurrentCapableMachinesWithProductionTime, allMachines, RandomGenerator.ProductionTimeForMachinesInOperation());
                }

                CurrentCapableMachines = new List<Machine>(CurrentCapableMachinesWithProductionTime.Keys);

                AllOperations.Add(new Operation(OperationIndex, "Name" + OperationIndex, CurrentMaterialsDemand, CurrentCapableMachinesWithProductionTime, null,
                    MoveFactory.GenerateFor(CurrentCapableMachines), currentBatch)); // no setup times yet
            }

            foreach (Operation CurrentOperation in AllOperations)
            {
                List<SetupForBatch> CurrentSetupTimes = new List<SetupForBatch>();
                foreach (Operation OperationForSetup in AllOperations)
                {
                    if (!CurrentOperation.Equals(OperationForSetup))
                    {
                        foreach (Machine CurrentMachine in CurrentCapableMachines)
                        {
                            if (isComplexProduction)
                            {
                                CurrentSetupTimes.Add(SetupFactory.GenerateComplexProductionFor(CurrentMachine, OperationForSetup));
                            }
                            else
                            {
                                CurrentSetupTimes.Add(SetupFactory.GenerateSmallScaleProductionFor(CurrentMachine, OperationForSetup));
                            }
                        }
                    }
                }
                CurrentOperation.SetupTimes = CurrentSetupTimes;
            }

            return AllOperations;
        }
    }
}
