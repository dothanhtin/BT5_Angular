using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows.ModelsWorkflows
{
    public class ModelGetAllWorkflows : BaseWorkflow
    {
        public ModelGetAllWorkflows()
        {
            //AddHandler(new TokenValidateStepHandler(pathApi,token));
            AddHandler(new ModelGetAllStepHandler());
        }
    }
}
