using System;
using System.Collections.Generic;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Factory
{
    class MachineFactory
    {
        public static List<Machine> GenerateComplexProductionFor(DateTime startProcessingDate, int quantity)
        {
            return GenerateFor(startProcessingDate, quantity, true);
        }

        public static List<Machine> GenerateSmallScaleProductionFor(DateTime startProcessingDate, int quantity)
        {
            return GenerateFor(startProcessingDate, quantity, false);
        }

        private static List<Machine> GenerateFor(DateTime startProcessingDate, int quantity, bool isComplexProduction)
        {
            List<Machine> GeneratedMachines = new List<Machine>();
            for (int index = 0; index < quantity; index++)
            {
                if (isComplexProduction)
                {
                    GeneratedMachines.Add(new Machine(index, "Machine" + index,
                        RandomGenerator.MachineTimeLeftTillMaintenanceForComplexProduction(), RandomGenerator.MachineTimeOfMaintenanceForComplexProduction(), startProcessingDate, null));
                }
                else
                {
                    GeneratedMachines.Add(new Machine(index, "Machine" + index,
                       RandomGenerator.MachineTimeLeftTillMaintenanceForSmallScaleProduction(), RandomGenerator.MachineTimeOfMaintenanceForSmallScaleProduction(), startProcessingDate, null));
                }
            }
            return GeneratedMachines;
        }
    }
}
