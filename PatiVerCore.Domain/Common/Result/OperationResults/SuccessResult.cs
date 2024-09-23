using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Common.Result.OperationResults
{
    /// <summary>
    /// Успешное выполнение операции
    /// </summary>
    public sealed class SuccessResult<T> : Result<T>
    {
        private readonly T _data;

        public SuccessResult(T data)
        {
            _data = data;
        }

        public override ResultType ResultType => ResultType.Ok;

        public override string? ErrorMessage => default;

        public override T Data => _data;
    }
}
