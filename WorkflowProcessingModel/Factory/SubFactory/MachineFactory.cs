using System.Collections.Generic;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Factory
{
    class MachineFactory
    {
        public static List<Machine> GenerateComplexProductionFor(int quantity)
        {
            return GenerateFor(quantity, true);
        }

        public static List<Machine> GenerateSmallScaleProductionFor(int quantity)
        {
            return GenerateFor(quantity, false);
        }

        private static List<Machine> GenerateFor(int quantity, bool isComplexProduction)
        {
            List<Machine> GeneratedMachines = new List<Machine>();
            for (int index = 0; index < quantity; index++)
            {
                if (isComplexProduction)
                {
                    GeneratedMachines.Add(new Machine(index, "Name" + index,
                        RandomGenerator.MachineTimeLeftTillMaintenanceForComplexProduction(), RandomGenerator.MachineTimeOfMaintenanceForComplexProduction()));
                }
                else
                {
                    GeneratedMachines.Add(new Machine(index, "Name" + index,
                       RandomGenerator.MachineTimeLeftTillMaintenanceForSmallScaleProduction(), RandomGenerator.MachineTimeOfMaintenanceForSmallScaleProduction()));
                }
            }
            return GeneratedMachines;
        }
    }
}
