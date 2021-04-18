using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows.DanhMucTinhThanhPhoWorkflows
{
    public class DanhMucTinhThanhPhoGetObjectByIdWorkflows : BaseWorkflow
    {
        public DanhMucTinhThanhPhoGetObjectByIdWorkflows(string pathApi, string token,Guid id)
        {
            //AddHandler(new TokenValidateStepHandler(pathApi,token));
            AddHandler(new DanhMucTinhThanhPhoGetObjectByIdStepHandler(id));
        }
    }
}
