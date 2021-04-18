using DMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows.ModelsWorkflows
{
    public class ModelInsertWorkflows : BaseWorkflow
    {
        public ModelInsertWorkflows(Model model)
        {
            //AddHandler(new TokenValidateStepHandler(pathApi,token));
            AddHandler(new ModelInsertStepHandler(model));
        }
    }
}
