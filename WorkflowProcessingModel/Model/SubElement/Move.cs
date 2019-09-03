using System;

namespace WorkflowProcessingModel.Model
{
    class Move
    {
        public Machine FromMachine { get; set; }
        public Machine ToMachine { get; set; }
        public int TimeNeededToMove { get; set; }

        public Move(Machine fromMachine, Machine toMachine, int timeNeededToMove)
        {
            FromMachine = fromMachine ?? throw new ArgumentNullException(nameof(fromMachine));
            ToMachine = toMachine ?? throw new ArgumentNullException(nameof(toMachine));
            TimeNeededToMove = timeNeededToMove;
        }
    }
}