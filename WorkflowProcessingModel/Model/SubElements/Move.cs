using System;

namespace WorkflowProcessingModel.Model
{
    class Move
    {
        public Machine FromMachine { get; set; }
        public Machine ToMachine { get; set; }
        public double TimeNeededInSec { get; set; }

        public Move(Machine fromMachine, Machine toMachine, double timeNeededInSec)
        {
            FromMachine = fromMachine ?? throw new ArgumentNullException(nameof(fromMachine));
            ToMachine = toMachine ?? throw new ArgumentNullException(nameof(toMachine));
            TimeNeededInSec = timeNeededInSec;
        }
    }
}