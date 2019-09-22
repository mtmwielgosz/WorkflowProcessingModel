using System.Collections.Generic;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory
{
    class FamilyFactory
    {

        public static List<Family> GenerateComplexProductionFor(List<Machine> allMachines, int quantity)
        {
            return GenerateFor(allMachines, quantity, true);
        }

        public static List<Family> GenerateSmallScaleProductionFor(List<Machine> allMachines, int quantity)
        {
            return GenerateFor(allMachines, quantity, false);
        }

        private static List<Family> GenerateFor(List<Machine> allMachines, int quantity, bool isComplexProduction)
        {
            List<Family> AllFamilies = new List<Family>();
            for (int index = 0; index < quantity; index++)
            {
                AllFamilies.Add(new Family(index, "name" + index, null)); // no setup times yet
            }

            foreach (Family CurrentFamily in AllFamilies)
            {
                List<SetupForFamily> SetupsForCurrentFamily = new List<SetupForFamily>();
                foreach (Family FamilyForSetup in AllFamilies)
                {
                    foreach (Machine CurrentMachineForSetup in allMachines)
                    {
                        if (isComplexProduction) // add setups
                        {
                            SetupsForCurrentFamily.Add(SetupFactory.GenerateComplexProductionFor(CurrentMachineForSetup, FamilyForSetup));
                        }
                        else
                        {
                            SetupsForCurrentFamily.Add(SetupFactory.GenerateSmallScaleProductionFor(CurrentMachineForSetup, FamilyForSetup));
                        }
                    }
                }
                CurrentFamily.SetupTimes = SetupsForCurrentFamily;
            }
            return AllFamilies;
        }
    }
}
