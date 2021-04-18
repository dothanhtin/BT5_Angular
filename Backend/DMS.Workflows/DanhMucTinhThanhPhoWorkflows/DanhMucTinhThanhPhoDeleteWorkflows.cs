using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows.DanhMucTinhThanhPhoWorkflows
{
    public class DanhMucTinhThanhPhoDeleteWorkflows : BaseWorkflow
    {
        public DanhMucTinhThanhPhoDeleteWorkflows(string pathApi, string token, Guid id)
        {
            //AddHandler(new TokenValidateStepHandler(pathApi,token));
            AddHandler(new DanhMucTinhThanhPhoDeleteStepHandler(id));
        }
    }
}
