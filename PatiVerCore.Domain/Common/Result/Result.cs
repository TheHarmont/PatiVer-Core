using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Common.Result
{
    public abstract class Result<T>
    {
        public abstract T Data { get; }
        public abstract ResultType ResultType { get; }
        public abstract string ErrorMessage { get; }
    }
}
