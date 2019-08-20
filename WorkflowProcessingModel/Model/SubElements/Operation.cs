﻿using System;
using System.Collections.Generic;

namespace WorkflowProcessingModel.Model
{
    class Operation
    {
        public int Index { get; set; }
        public Dictionary<Material, int> MaterialsDemand { get; set; }
        public Dictionary<Machine, int> CapableMachinesWithProductionTime { get; set; }
        public List<Setup> SetupTimes { get; set; }
        public List<Move> TimesOfMovingSemiproducts { get; set; }

        public Operation(int index, Dictionary<Material, int> materialsDemand, Dictionary<Machine, int> capableMachinesWithProductionTime, List<Setup> setupTimes, List<Move> timesOfMovingSemiproducts)
        {
            Index = index;
            MaterialsDemand = materialsDemand ?? throw new ArgumentNullException(nameof(materialsDemand));
            CapableMachinesWithProductionTime = capableMachinesWithProductionTime ?? throw new ArgumentNullException(nameof(capableMachinesWithProductionTime));
            SetupTimes = setupTimes ?? throw new ArgumentNullException(nameof(setupTimes));
            TimesOfMovingSemiproducts = timesOfMovingSemiproducts ?? throw new ArgumentNullException(nameof(timesOfMovingSemiproducts));

            if (setupTimes.Exists(setup => setup.PreviousFamily != null))
            {
                Console.WriteLine("The setup time for operations depend on previous operation, not previous family.");

            }
        }
    }
}