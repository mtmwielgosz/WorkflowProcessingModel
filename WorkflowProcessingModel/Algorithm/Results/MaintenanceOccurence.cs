using System;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm.Results
{
    class MaintenanceOccurence
    {
        Machine MaintainedMachines { get; set; }
        DateTime StartMaintenanceTime { get; set; }
        DateTime EndMaintenanceTime { get; set; }
    }
}
