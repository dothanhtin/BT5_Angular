using System;
using System.Collections.Generic;
using System.Text;


namespace DMS.Shared
{
    public class Error
    {
        public const int CODE_SUCCESS = 1;
        public const int CODE_FAIL = -1;
        public const int CODE_PARAMS_ERROR = -2;
        public const int CODE_FORBIDDEN = 403;
        public const int CODE_NOTFOUND = 404;
        public const int CODE_UNAUTHORIZED = 401;

        public int Code { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }

        public object GetError()
        {

            var res = new 
            {
                Code = CODE_SUCCESS,
                Msg,
                Data
            };
            return res;
        }
        public object GetError(int Code, string Msg)
        {
            var res = new
            {
                Code,
                Msg,
                Data
            };
            return res;
        }
        public object GetError(int Code, string Msg, object Data)
        {
            var res = new
            {
                Code,
                Msg,
                Data
            };
            return res;
        }
    }
}
