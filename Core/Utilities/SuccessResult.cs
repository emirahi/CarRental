using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class SuccessResult : Result
    {
        public SuccessResult(string Message):base(true,Message)
        {
        }

        public SuccessResult():base(true)
        {

        }
    }
}
