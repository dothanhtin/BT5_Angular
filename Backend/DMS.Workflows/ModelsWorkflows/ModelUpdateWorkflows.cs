using DMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows.ModelsWorkflows
{
    public class ModelUpdateWorkflows : BaseWorkflow
    {
        public ModelUpdateWorkflows(Model employee)
        {
            //AddHandler(new TokenValidateStepHandler(pathApi,token));
            AddHandler(new ModelUpdateStepHandler(employee));
        }
    }
}
