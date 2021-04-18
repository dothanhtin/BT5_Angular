using Microsoft.AspNetCore.Http;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudDinary_BaseUsing.Models
{
    public class Utils
    {
        public static async Task Log(string s)
        {
            try
            {
                Task.Run(() =>
                {
                    Logger log = LogManager.GetCurrentClassLogger();
                    log.Info(s);
                });
            }
            catch (Exception)
            {

            }
        }
    }
}
