using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class DataResult<T> : Result,IDataResult<T>
    {
        public T Data { get; }
        public DataResult(bool Success,string Message,T Data) : base(Success,Message)
        {
            this.Data = Data;
        }
        public DataResult(bool Success,T Data):base(Success)
        {            
            this.Data = Data;
        }

        public DataResult(bool Success, string Message) : base(Success, Message)
        {
        }
    }
}
