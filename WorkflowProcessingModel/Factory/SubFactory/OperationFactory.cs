using System.Collections.Generic;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory.SubFactory
{
    class OperationFactory
    {

        public static List<Operation> GenerateFor(List<Machine> allMachines, List<Material> allMaterials, int quantity)
        {
            List<Operation> AllOperations = new List<Operation>();
            List<Machine> CurrentCapableMachines = new List<Machine>();
            for (int OperationIndex = 0; OperationIndex < quantity; OperationIndex++)
            {
                int numberOfMaterials = RandomGenerator.MaterialsInOperation();
                Dictionary<Material, int> CurrentMaterialsDemand = new Dictionary<Material, int>();
                for (int MaterialIindex = 0; MaterialIindex < numberOfMaterials; MaterialIindex++)
                {
                    AddUniqeElementToDictionary(CurrentMaterialsDemand, allMaterials, RandomGenerator.MaterialsDemandInOperation());
                }

                int numberOfMachines = RandomGenerator.MachinesInOperation();
                Dictionary<Machine, int> CurrentCapableMachinesWithProductionTime = new Dictionary<Machine, int>();
                for (int MachineIindex = 0; MachineIindex < numberOfMachines; MachineIindex++)
                {
                    AddUniqeElementToDictionary(CurrentCapableMachinesWithProductionTime, allMachines, RandomGenerator.ProductionTimeForMachinesInOperation());
                }

                CurrentCapableMachines = new List<Machine>(CurrentCapableMachinesWithProductionTime.Keys);

                AllOperations.Add(new Operation(OperationIndex, CurrentMaterialsDemand, CurrentCapableMachinesWithProductionTime, null,
                    MoveFactory.GenerateFor(CurrentCapableMachines))); // no setup times yet
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
                            CurrentSetupTimes.Add(SetupFactory.GenerateFor(CurrentMachine, OperationForSetup));
                        }
                    }
                }
                CurrentOperation.SetupTimes = CurrentSetupTimes; // add setups 
            }

            return AllOperations;
        }


        private static void AddUniqeElementToDictionary<T>(Dictionary<T, int> currentDictionary, List<T> currentList, int valueToAdd)
        {
            T ElementToAdd = RandomGenerator.RandomElement<T>(currentList);
            if (!currentDictionary.ContainsKey(ElementToAdd))
            {
                currentDictionary.Add(ElementToAdd, valueToAdd);
            }
            else
            {
                AddUniqeElementToDictionary(currentDictionary, currentList, valueToAdd);
            }
        }

    }



}
