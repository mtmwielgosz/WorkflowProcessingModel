using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
