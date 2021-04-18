using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows.TokenWorkflows
{
    public class TokenValidateWorkflows : BaseWorkflow
    {
        public TokenValidateWorkflows(string pathApi, string token)
        {
            AddHandler(new TokenValidateStepHandler(pathApi, token));
        }
    }
}
