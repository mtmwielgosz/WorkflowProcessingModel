using System;

namespace WorkflowProcessingModel.Model
{
    class Batch
    {
        int Index { get; set; }
        DateTime DueDate { get; set; }
        Double PunishmentPetDay { get; set; }
        Job JobInBatch { get; set; }
        int NumerOfJobs { get; set; }
    }
}
