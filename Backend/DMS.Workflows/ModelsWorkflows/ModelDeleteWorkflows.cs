using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows.ModelsWorkflows
{
    public class ModelDeleteWorkflows : BaseWorkflow
    {
        public ModelDeleteWorkflows(Guid id)
        {
            AddHandler(new ModelDeleteStepHandler(id));
        }

    }
}
