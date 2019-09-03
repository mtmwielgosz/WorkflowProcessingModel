using System.Collections.Generic;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory
{
    class FamilyFactory
    {
        public static List<Family> Generate(int quantity, List<Machine> allMachines)
        {
            List<Family> AllFamilies = new List<Family>();
            for (int index = 0; index < quantity; index++)
            {
                AllFamilies.Add(new Family(index, "name" + index, null));
            }

            foreach (Family CurrentFamily in AllFamilies)
            {
                List<SetupForFamily> SetupsForCurrentFamily = new List<SetupForFamily>();
                foreach (Family FamilyForSetup in AllFamilies)
                {
                    foreach (Machine CurrentMachineForSetup in allMachines)
                    {
                        SetupsForCurrentFamily.Add(SetupFactory.GenerateFor(CurrentMachineForSetup, FamilyForSetup));
                    }
                }
                CurrentFamily.SetupTimes = SetupsForCurrentFamily;
            }
            return AllFamilies;
        }
    }
}
