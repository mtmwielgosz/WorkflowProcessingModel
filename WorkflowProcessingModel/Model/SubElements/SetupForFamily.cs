namespace WorkflowProcessingModel.Model.SubElements
{
    class SetupForFamily : Setup
    {
        public Family PreviousFamily { get; set; }

        public SetupForFamily(Family previousFamily, Machine currentMachine, double setupTime) : base(currentMachine, setupTime)
        {
            PreviousFamily = previousFamily;
        }
    }
}
