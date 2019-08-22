using System;
using System.Collections.Generic;

namespace WorkflowProcessingModel.Model.SubElements
{
    class Family
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public List<SetupForFamily> SetupTimes { get; set; }

        public Family(int index, string name, List<SetupForFamily> setupTimes)
        {
            Index = index;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            SetupTimes = setupTimes ?? throw new ArgumentNullException(nameof(setupTimes));
        }
    }
}
