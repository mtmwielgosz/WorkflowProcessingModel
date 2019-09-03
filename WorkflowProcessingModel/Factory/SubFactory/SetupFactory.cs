using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory
{
    class SetupFactory
    {
        public static SetupForFamily GenerateFor(Machine currentMachine, Family previousFamily)
        {
            return new SetupForFamily(currentMachine, previousFamily, RandomGenerator.SetupTime());
        }

        public static SetupForBatch GenerateFor(Machine currentMachine, Operation previousOperation)
        {
            return new SetupForBatch(currentMachine, previousOperation, RandomGenerator.SetupTime());
        }

    }
}
