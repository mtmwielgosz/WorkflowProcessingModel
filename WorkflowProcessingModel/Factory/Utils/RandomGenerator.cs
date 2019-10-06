using System; 
using System.Collections.Generic;

namespace WorkflowProcessingModel.Factory
{
    class RandomGenerator   // const dla wartości - plik property
                            // 
    {
        private static Random random = new Random();

        public static int MachineTimeLeftTillMaintenanceForComplexProduction()
        {
            return random.Next(TimeUtils.SecInWorkingDay, 7 * TimeUtils.SecInWorkingDay);
        }

        public static int MachineTimeLeftTillMaintenanceForSmallScaleProduction()
        {
            return random.Next(TimeUtils.SecInWorkingDay, 3 * TimeUtils.SecInWorkingDay);
        }

        public static int MachineTimeOfMaintenanceForComplexProduction()
        {
            return random.Next(10 * TimeUtils.SecInMinute, 30 * TimeUtils.SecInMinute);
        }

        public static int MachineTimeOfMaintenanceForSmallScaleProduction()
        {
            return random.Next(10 * TimeUtils.SecInMinute, 30 * TimeUtils.SecInMinute);
        }

        public static int MoveTimeNeededToMove()
        {
            return random.Next(10, 2 * TimeUtils.SecInMinute);
        }

        public static int SetupTimeForComplexProduction()
        {
            return random.Next(TimeUtils.SecInHour, 4 * TimeUtils.SecInHour);
        }

        public static int SetupTimeForSmallScaleProduction()
        {
            return random.Next(20 * TimeUtils.SecInMinute, 50 * TimeUtils.SecInMinute);
        }

        public static int NumberOfAvailableMaterials()
        {
            return random.Next(100, 10000);
        }

        public static int TimeNeededToTransportProductsToProductionHall()
        {
            return random.Next(30 * TimeUtils.SecInMinute, TimeUtils.SecInWorkingDay);
        }

        public static int MaterialsInOperation()
        {
            return random.Next(1, 5);
        }

        public static int MaterialsDemandInOperation()
        {
            return random.Next(1, 10);
        }

        public static int MachinesInOperation()
        {
            return random.Next(1, 3);
        }

        public static int ProductionTimeForMachinesInOperation()
        {
            return random.Next(5, TimeUtils.SecInMinute);
        }

        public static int OperationsInJobForSmallScaleProduction()
        {
            return random.Next(2, 5);
        }

        public static int OperationsInJobForComplexProduction()
        {
            return random.Next(20, 30);
        }

        public static DateTime DueDate()
        {
            return DateTime.Today.AddDays(random.Next(10, 60));
        }

        public static double PunishmentPerDay()
        {
            return (random.NextDouble() + 0.1) * 5000;
        }

        public static int JobsInBatch()
        {
            return random.Next(1, 250);
        }

        public static T RandomElement<T>(List<T> list)
        {
            return list[random.Next(list.Count)];
        }

    }
}
