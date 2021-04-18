using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Workflows.DanhMucTinhThanhPhoWorkflows
{
    public class DanhMucTinhThanhPhoCreateNewWorkflows : BaseWorkflow
    {
        public DanhMucTinhThanhPhoCreateNewWorkflows(string pathApi, DMS.Core.Models.DanhMucTinhThanhPho _danhmuctinhthanhpho, String token)
        {
            //AddHandler(new TokenValidateStepHandler(pathApi,token));
            AddHandler(new DanhMucTinhThanhPhoCreateNewStepHandler(_danhmuctinhthanhpho));
        }
    }
}
