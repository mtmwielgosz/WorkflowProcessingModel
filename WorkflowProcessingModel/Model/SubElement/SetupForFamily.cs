namespace WorkflowProcessingModel.Model.SubElements
{
    class SetupForFamily : Setup
    {
        public Family PreviousFamily { get; set; }

        public SetupForFamily(Machine currentMachine, Family previousFamily, int setupTime) : base(currentMachine, setupTime)
        {
            PreviousFamily = previousFamily;
        }
    }
}
