using System.Collections.Generic;

namespace WorkflowProcessingModel.Factory
{
    interface IFactory<T> where T : class
    {
        List<T> Generate(int quantity);
    }
}
