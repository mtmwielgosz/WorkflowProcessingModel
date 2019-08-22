using System.Collections.Generic;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory
{
    class FamilyFactory : IFactory<Family>
    {
        public List<Family> Generate(int quantity)
        {
            List<Family> AllFamilies = new List<Family>();
            for (int index = 0; index < quantity; index++)
            {


            }



            return AllFamilies;
        }
    }
}
