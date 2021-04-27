using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T Data) :base(false,Data)
        {
        }


        public ErrorDataResult(string Message,T Data):base(false,Message,Data)
        {
        }


    }
}
