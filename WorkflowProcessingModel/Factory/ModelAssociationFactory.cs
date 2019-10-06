using System;
using System.Collections.Generic;
using WorkflowProcessingModel.Factory.SubFactory;
using WorkflowProcessingModel.Model;
using WorkflowProcessingModel.Model.SubElements;

namespace WorkflowProcessingModel.Factory
{
    class ModelAssociationFactory
    {
        public static ModelAssociation GenerateComplexProductionWithFamiliesFor(DateTime startProcessingDate, int materialsQuantity, int machinesQuantity, int jobsQuantity, int operatiosnQuantity, int familiesQuantity)
        {
            return GenerateFor(startProcessingDate, materialsQuantity, machinesQuantity, jobsQuantity, operatiosnQuantity, familiesQuantity, true);
        }

        public static ModelAssociation GenerateSmallScaleProductionWithFamiliesFor(DateTime startProcessingDate, int materialsQuantity, int machinesQuantity, int jobsQuantity, int operatiosnQuantity, int familiesQuantity)
        {
            return GenerateFor(startProcessingDate, materialsQuantity, machinesQuantity, jobsQuantity, operatiosnQuantity, familiesQuantity, false);
        }

        public static ModelAssociation GenerateComplexProductionWithoutFamiliesFor(DateTime startProcessingDate, int materialsQuantity, int machinesQuantity, int jobsQuantity, int operatiosnQuantity)
        {
            return GenerateFor(startProcessingDate, materialsQuantity, machinesQuantity, jobsQuantity, operatiosnQuantity, 0, true);
        }

        public static ModelAssociation GenerateSmallScaleProductionWithoutFamiliesFor(DateTime startProcessingDate, int materialsQuantity, int machinesQuantity, int jobsQuantity, int operatiosnQuantity)
        {
            return GenerateFor(startProcessingDate, materialsQuantity, machinesQuantity, jobsQuantity, operatiosnQuantity, 0, false);
        }

        /// <summary>
        /// operationsQuantity should be greater than jobsQuantity
        /// familiesQuantity can be 0 -> then no families scheduling
        /// isComplexProduction - complex production, else small scale production
        /// </summary>
        private static ModelAssociation GenerateFor(DateTime startProcessingDate, int materialsQuantity, int machinesQuantity, int jobsQuantity, int operatiosnQuantity, int familiesQuantity, bool isComplexProduction)
        {
            List<Material> CurrentMaterials = MaterialFactory.GenerateFor(materialsQuantity);
            Storehouse CurrentStorehouse = StorehouseFactory.GenerateFor(CurrentMaterials);
            List<Machine> CurrentMachines;
            List<Operation> CurrentOperations;
            List<Job> CurrentJobs;
            if (isComplexProduction)
            {
                CurrentMachines = MachineFactory.GenerateComplexProductionFor(startProcessingDate, machinesQuantity);
                CurrentOperations = OperationFactory.GenerateComplexProductionFor(CurrentMachines, CurrentMaterials, null, null, operatiosnQuantity);
                CurrentJobs = JobFactory.GenerateComplexProductionFor(CurrentOperations, null, operatiosnQuantity);
            }
            else
            {
                CurrentMachines = MachineFactory.GenerateComplexProductionFor(startProcessingDate, machinesQuantity);
                CurrentOperations = OperationFactory.GenerateComplexProductionFor(CurrentMachines, CurrentMaterials, null, null, operatiosnQuantity);
                CurrentJobs = JobFactory.GenerateSmallScaleProductionFor(CurrentOperations, null, operatiosnQuantity);
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
                CurrentBatches = BatchFactory.GenerateWithFamiliesFor(startProcessingDate, CurrentJobs, CurrentFamilies);
            }
            else
            {
                CurrentBatches = BatchFactory.GenerateWithoutFamiliesFor(startProcessingDate, CurrentJobs);
            }

            return new ModelAssociation(CurrentBatches, CurrentMachines, CurrentStorehouse);
        }
    }
}
