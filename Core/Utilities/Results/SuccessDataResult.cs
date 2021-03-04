using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T Data,string Message):base(true,Message,Data)
        {
        }

        public SuccessDataResult(T Data):base(true,Data)
        {
        }
    }
}
