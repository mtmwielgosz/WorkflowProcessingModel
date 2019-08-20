using System;
using System.Collections.Generic;

namespace WorkflowProcessingModel.Model.SubElements
{
    class Family
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public List<Setup> SetupTimes { get; set; }

        public Family(int index, string name, List<Setup> setupTimes)
        {
            Index = index;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            SetupTimes = setupTimes ?? throw new ArgumentNullException(nameof(setupTimes));

            if (setupTimes.Exists(setup => setup.PreviousOperation != null))
            {
                Console.WriteLine("The setup time for families depend on previous family, not previous operation.");

            }
        }
    }
}
