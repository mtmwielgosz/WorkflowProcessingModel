using System.Collections.Generic;
using WorkflowProcessingModel.Factory.SubFactory;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory
{
    class ModelAssociationFactory
    {
        public static ModelAssociation GenerateComplexProductionWithFamiliesFor(int materialsQuantity, int machinesQuantity, int jobsQuantity, int operatiosnQuantity, int familiesQuantity)
        {
            return GenerateFor(materialsQuantity, machinesQuantity, jobsQuantity, operatiosnQuantity, familiesQuantity, true);
        }

        public static ModelAssociation GenerateSmallScaleProductionWithFamiliesFor(int materialsQuantity, int machinesQuantity, int jobsQuantity, int operatiosnQuantity, int familiesQuantity)
        {
            return GenerateFor(materialsQuantity, machinesQuantity, jobsQuantity, operatiosnQuantity, familiesQuantity, false);
        }

        public static ModelAssociation GenerateComplexProductionWithoutFamiliesFor(int materialsQuantity, int machinesQuantity, int jobsQuantity, int operatiosnQuantity)
        {
            return GenerateFor(materialsQuantity, machinesQuantity, jobsQuantity, operatiosnQuantity, 0, true);
        }

        public static ModelAssociation GenerateSmallScaleProductionWithoutFamiliesFor(int materialsQuantity, int machinesQuantity, int jobsQuantity, int operatiosnQuantity)
        {
            return GenerateFor(materialsQuantity, machinesQuantity, jobsQuantity, operatiosnQuantity, 0, false);
        }

        /// <summary>
        /// operationsQuantity should be greater than jobsQuantity
        /// familiesQuantity can be 0 -> then no families scheduling
        /// isComplexProduction - complex production, else small scale production
        /// </summary>
        private static ModelAssociation GenerateFor(int materialsQuantity, int machinesQuantity, int jobsQuantity, int operatiosnQuantity, int familiesQuantity, bool isComplexProduction)
        {
            List<Material> CurrentMaterials = MaterialFactory.GenerateFor(materialsQuantity);
            Storehouse CurrentStorehouse = StorehouseFactory.GenerateFor(CurrentMaterials);
            List<Machine> CurrentMachines;
            List<Operation> CurrentOperations;
            List<Job> CurrentJobs;
            if (isComplexProduction)
            {
                CurrentMachines = MachineFactory.GenerateComplexProductionFor(machinesQuantity);
                CurrentOperations = OperationFactory.GenerateComplexProductionFor(CurrentMachines, CurrentMaterials, operatiosnQuantity);
                CurrentJobs = JobFactory.GenerateComplexProductionFor(CurrentOperations, operatiosnQuantity);
            }
            else
            {
                CurrentMachines = MachineFactory.GenerateComplexProductionFor(machinesQuantity);
                CurrentOperations = OperationFactory.GenerateComplexProductionFor(CurrentMachines, CurrentMaterials, operatiosnQuantity);
                CurrentJobs = JobFactory.GenerateSmallScaleProductionFor(CurrentOperations, operatiosnQuantity);
            }
            List<Batch> CurrentBatches;
            if (familiesQuantity > 0)
            {
                List<Family> CurrentFamilies;
                if (isComplexProduction)
                {
                    CurrentFamilies = FamilyFactory.GenerateComplexProductionFor(CurrentMachines, familiesQuantity);
                }
                else
                {
                    CurrentFamilies = FamilyFactory.GenerateSmallScaleProductionFor(CurrentMachines, familiesQuantity);
                }
                CurrentBatches = BatchFactory.GenerateWithFamiliesFor(CurrentJobs, CurrentFamilies);
            }
            else
            {
                CurrentBatches = BatchFactory.GenerateWithoutFamiliesFor(CurrentJobs);
            }

            return new ModelAssociation(CurrentBatches, CurrentMachines, CurrentStorehouse);
        }
    }
}
