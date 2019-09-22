using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory
{
    class SetupFactory
    {
        public static SetupForFamily GenerateComplexProductionFor(Machine currentMachine, Family previousFamily)
        {
            return new SetupForFamily(currentMachine, previousFamily, RandomGenerator.SetupTimeForComplexProduction());
        }

        public static SetupForBatch GenerateComplexProductionFor(Machine currentMachine, Operation previousOperation)
        {
            return new SetupForBatch(currentMachine, previousOperation, RandomGenerator.SetupTimeForComplexProduction());
        }

        public static SetupForFamily GenerateSmallScaleProductionFor(Machine currentMachine, Family previousFamily)
        {
            return new SetupForFamily(currentMachine, previousFamily, RandomGenerator.SetupTimeForSmallScaleProduction());
        }

        public static SetupForBatch GenerateSmallScaleProductionFor(Machine currentMachine, Operation previousOperation)
        {
            return new SetupForBatch(currentMachine, previousOperation, RandomGenerator.SetupTimeForSmallScaleProduction());
        }

    }
}
