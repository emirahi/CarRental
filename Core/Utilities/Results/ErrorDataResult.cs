using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(bool Success, T Data) :base(Success,Data)
        {
        }
        public ErrorDataResult(bool Success,string Message,T Data):base(Success,Message,Data)
        {
        }
        public ErrorDataResult(bool Success,string Message):base(Success,Message)
        {

        }

    }
}
