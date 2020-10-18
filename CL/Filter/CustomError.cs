using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Filter
{
    public class CustomError
    {
        public string Error { get; }
        public string Code { get; }

        public CustomError(string message, string code = "")
        {
            Error = message;
            Code = code;
        }
    }
}
