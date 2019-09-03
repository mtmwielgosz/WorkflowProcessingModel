using System.Collections.Generic;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Factory
{
    class MachineFactory
    {
        public static List<Machine> Generate(int quantity)
        {
            List<Machine> GeneratedMachines = new List<Machine>();
            for (int index = 0; index < quantity; index++)
            {
                GeneratedMachines.Add(new Machine(index, "Name" + index,
                    RandomGenerator.MachineTimeLeftTillMaintenance(), RandomGenerator.MachineTimeOfMaintenance()));
            }
            return GeneratedMachines;
        }
    }
}
