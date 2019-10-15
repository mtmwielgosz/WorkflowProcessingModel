using System;
using System.Drawing;

namespace WorkflowProcessingModel.Model.SubElement
{
    public class Maintenance : Operation
    {
        public Maintenance() : base(0, "Maintenance", DateTime.MinValue, null, null,
            null, null, null, null, Color.Black)
        { }

    }
}
