using System.Collections.Generic;
using WorkflowProcessingModel.Model;

namespace WorkflowProcessingModel.Factory
{
    class MoveFactory
    {
        public static List<Move> GenerateFor(List<Machine> allMachines)
        {
            List<Move> AllMoves = new List<Move>();
            foreach (Machine FirstMachine in allMachines)
            {
                foreach (Machine SecondMachine in allMachines)
                {
                    int TimeNeededToMove = 0;
                    if (!FirstMachine.Equals(SecondMachine))
                    {
                        TimeNeededToMove = RandomGenerator.MoveTimeNeededToMove();
                    }
                    AllMoves.Add(new Move(FirstMachine, SecondMachine, TimeNeededToMove));
                    AllMoves.Add(new Move(SecondMachine, FirstMachine, TimeNeededToMove));
                }
            }
            return AllMoves;
        }
    }
}
