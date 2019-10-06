using System.Collections.Generic;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm.Results
{
    public class ResultAssociation
    {
        /// <summary> main output (optimisation result) </summary>
        public List<OperationMachineAssignment> OperationMachineAssignmentResult { get; set; }
        /// <summary> extra output </summary>
        public List<MaintenanceOccurence> MaintenanceOccurencesResult { get; set; }
        /// <summary> extra output </summary>
        public Dictionary<Material, int> ExtraNeededMaterialsResult { get; set; }

        public ResultAssociation(List<OperationMachineAssignment> operationMachineAssignmentResult,
            List<MaintenanceOccurence> maintenanceOccurencesResult, Dictionary<Material, int> extraNeededMaterialsResult)
        {
            OperationMachineAssignmentResult = operationMachineAssignmentResult;
            MaintenanceOccurencesResult = maintenanceOccurencesResult;
            ExtraNeededMaterialsResult = extraNeededMaterialsResult;
        }
    }
}
