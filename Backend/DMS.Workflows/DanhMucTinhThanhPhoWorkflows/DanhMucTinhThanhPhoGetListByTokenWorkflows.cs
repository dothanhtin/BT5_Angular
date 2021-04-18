using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows.DanhMucTinhThanhPhoWorkflows
{
    public class DanhMucTinhThanhPhoGetListByTokenWorkflows : BaseWorkflow
    {
        public DanhMucTinhThanhPhoGetListByTokenWorkflows(string pathApi, string token)
        {
            //AddHandler(new TokenValidateStepHandler(pathApi,token));
            AddHandler(new DanhMucTinhThanhPhoGetListByOrganizationStepHandler(token));
        }
    }
}
