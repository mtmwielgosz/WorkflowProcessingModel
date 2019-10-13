using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace WorkflowProcessingModel.Factory
{
    class RandomGenerator
    {
        private static Random Rand = new Random();
        private static readonly Dictionary<string, string> Dict = ReadDictionaryFile("C:\\Users\\Mateusz\\source\\repos\\WorkflowProcessingModel\\WorkflowProcessingModel\\Properties\\Parameters.properties");

        private static Dictionary<string, string> ReadDictionaryFile(string fileName)
        {
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (string Line in File.ReadAllLines(fileName))
            {
                if ((!string.IsNullOrEmpty(Line)) &&
                    (!Line.StartsWith(";")) &&
                    (!Line.StartsWith("#")) &&
                    (!Line.StartsWith("'")) &&
                    (Line.Contains('=')))
                {
                    int Index = Line.IndexOf('=');
                    string Key = Line.Substring(0, Index).Trim();
                    string Value = Line.Substring(Index + 1).Trim();

                    if ((Value.StartsWith("\"") && Value.EndsWith("\"")) ||
                        (Value.StartsWith("'") && Value.EndsWith("'")))
                    {
                        Value = Value.Substring(1, Value.Length - 2);
                    }
                    Dictionary.Add(Key, Value);
                }
            }
            return Dictionary;
        }


        public static int MachineTimeLeftTillMaintenanceForComplexProduction()
        {
            return RandomBetween("MachineTimeLeftTillMaintenanceForComplexProduction");
        }

        public static int MachineTimeLeftTillMaintenanceForSmallScaleProduction()
        {
            return RandomBetween("MachineTimeLeftTillMaintenanceForSmallScaleProduction");
        }

        public static int MachineTimeOfMaintenanceForComplexProduction()
        {
            return RandomBetween("MachineTimeOfMaintenanceForComplexProduction");
        }

        public static int MachineTimeOfMaintenanceForSmallScaleProduction()
        {
            return RandomBetween("MachineTimeOfMaintenanceForSmallScaleProduction");
        }

        public static int TimeNeededToMoveBetweenMachines()
        {
            return RandomBetween("TimeNeededToMoveBetweenMachines");
        }

        public static int SetupTimeForComplexProduction()
        {
            return RandomBetween("SetupTimeForComplexProduction");
        }

        public static int SetupTimeForSmallScaleProduction()
        {
            return RandomBetween("SetupTimeForSmallScaleProduction");
        }

        public static int NumberOfAvailableMaterials()
        {
            return RandomBetween("NumberOfAvailableMaterials");
        }

        public static int TimeNeededToTransportProductsToProductionHall()
        {
            return RandomBetween("TimeNeededToTransportProductsToProductionHall");
        }

        public static int MaterialsInOperation()
        {
            return RandomBetween("MaterialsInOperation");
        }

        public static int MaterialsDemandInOperation()
        {
            return RandomBetween("MaterialsDemandInOperation");
        }

        public static int MachinesInOperation()
        {
            return RandomBetween("MachinesInOperation");
        }

        public static int ProductionTimeForMachinesInOperation()
        {
            return RandomBetween("ProductionTimeForMachinesInOperation");
        }

        public static int OperationsInJobForSmallScaleProduction()
        {
            return RandomBetween("OperationsInJobForSmallScaleProduction");
        }

        public static int OperationsInJobForComplexProduction()
        {
            return RandomBetween("OperationsInJobForComplexProduction");
        }

        public static DateTime DueDate(DateTime startProcessingDate)
        {
            return startProcessingDate.AddDays(RandomBetween("DaysToProcessBatch"));
        }

        public static int PunishmentPerDay()
        {
            return RandomBetween("PunishmentPerDay");
        }

        public static int JobsInBatch()
        {
            return RandomBetween("JobsInBatch");
        }

        public static T RandomElement<T>(List<T> list)
        {
            return list[Rand.Next(list.Count)];
        }

        public static Color ColorForChart()
        {
            return Color.FromArgb(Rand.Next(0, 255), Rand.Next(0, 255), Rand.Next(0, 255));
        }

        private static int RandomBetween(string CurrentKey)
        {
            string CurrentValue = Dict[CurrentKey];
            int Index = CurrentValue.IndexOf(',');
            int StartValue = GetValueFromProperty(CurrentValue.Substring(0, Index).Trim());
            int EndValue = GetValueFromProperty(CurrentValue.Substring(Index + 1).Trim());
            return Rand.Next(StartValue, EndValue);
        }

        private static int GetValueFromProperty(string CurrentValue)
        {
            if (int.TryParse(CurrentValue, out int OutValue))
            {
                return OutValue;
            }
            return int.Parse(CurrentValue.Substring(0, CurrentValue.Length - 1)) * TimeUtils.SecIn(CurrentValue.Substring(CurrentValue.Length - 1));
        }
    }
}
