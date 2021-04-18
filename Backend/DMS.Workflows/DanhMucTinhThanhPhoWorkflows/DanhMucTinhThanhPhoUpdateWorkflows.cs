using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows.DanhMucTinhThanhPhoWorkflows
{
    public class DanhMucTinhThanhPhoUpdateWorkflows : BaseWorkflow
    {
        public DanhMucTinhThanhPhoUpdateWorkflows(string pathApi, string token, DMS.Core.Models.DanhMucTinhThanhPho danhmuctinhthanhpho)
        {
            //AddHandler(new TokenValidateStepHandler(pathApi,token));
            AddHandler(new DanhMucTinhThanhPhoUpdateStepHandler(danhmuctinhthanhpho));
        }
    }
}
