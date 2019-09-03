using System;

namespace WorkflowProcessingModel.Factory
{
    class RandomGenerator
    {
        private static Random random = new Random();

        public static int MachineTimeLeftTillMaintenance()
        {
            return random.Next(TimeUtils.SecInWorkingDay, 5 * TimeUtils.SecInWorkingDay);
        }

        public static int MachineTimeOfMaintenance()
        {
            return random.Next(10 * TimeUtils.SecInMinute, 30 * TimeUtils.SecInMinute);
        }

        public static int MoveTimeNeededToMove()
        {
            return random.Next(10, 2 * TimeUtils.SecInMinute);
        }

        public static int SetupTime()
        {
            return random.Next(TimeUtils.SecInHour, 4 * TimeUtils.SecInHour);
        }

        public static int NumberOfAvailableMaterials()
        {
            return random.Next(100, 10000);
        }

        public static int TimeNeededToTransportProductsToProductionHall()
        {
            return random.Next(30 * TimeUtils.SecInMinute, TimeUtils.SecInWorkingDay);
        }

    }
}
