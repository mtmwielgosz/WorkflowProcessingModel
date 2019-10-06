using System;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Algorithm.Results
{
    public class MaintenanceOccurence
    {
        public Machine MaintainedMachines { get; set; }
        public DateTime StartMaintenanceTime { get; set; }
        public DateTime EndMaintenanceTime { get; set; }

        public MaintenanceOccurence(Machine maintainedMachines, DateTime startMaintenanceTime, DateTime endMaintenanceTime)
        {
            if (startMaintenanceTime >= endMaintenanceTime)
            {
                throw new InvalidOperationException(String.Format("startMaintenanceTime ({0}) can't be later than endMaintenanceTime ({1}).", startMaintenanceTime, endMaintenanceTime));
            }

            MaintainedMachines = maintainedMachines ?? throw new ArgumentNullException(nameof(maintainedMachines));
            StartMaintenanceTime = startMaintenanceTime;
            EndMaintenanceTime = endMaintenanceTime;
        }
    }
}
