//using DMS.Core.Models.LogStashModel;
using DMS.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VNPT.Framework.Logger;

namespace DMS.RestApi
{
    public class GlobalExceptionHandler : ExceptionFilterAttribute
    {
        public GlobalExceptionHandler()
        {
        }

        public override void OnException(ExceptionContext context)     
        {

            //var jsonlog = new LogError
            //{
            //    Id = Guid.NewGuid(),
            //    application = "sohoa",
            //    className = "internal-server-error",
            //    CreatedOn = DateTime.UtcNow,
            //    UserName = "",
            //    message = Newtonsoft.Json.JsonConvert.SerializeObject(context.Exception.Message)
            //};


            //string stringLog = Newtonsoft.Json.JsonConvert.SerializeObject(jsonlog);
            //CommonUntil.SendTcpLogStash(stringLog);

            var result = new ObjectResult("InternalServerError - Unhandle Exception")
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
            };

            context.Result = result;
        }
    }

}
