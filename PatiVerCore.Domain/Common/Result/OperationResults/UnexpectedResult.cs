using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Common.Result.OperationResults
{
    /// <summary>
    /// Неизвестная ошибка
    /// </summary>
    public sealed class UnexpectedResult<T> : Result<T>
    {
        private readonly string? _error;

        public UnexpectedResult()
        {
        }

        public UnexpectedResult(string error)
        {
            _error = error;
        }

        public override ResultType ResultType => ResultType.Unexpected;

        public override string ErrorMessage => _error ?? "Произошла непредвиденная ошибка";

        public override T Data => default;
    }
}
