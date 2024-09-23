using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Common.Result.OperationResults
{
    /// <summary>
    /// Ошибка валидации
    /// </summary>
    public sealed class InvalidResult<T> : Result<T>
    {
        private readonly string? _error;

        public InvalidResult()
        {
        }

        public InvalidResult(string error)
        {
            _error = error;
        }

        public override ResultType ResultType => ResultType.Invalid;

        public override string ErrorMessage => _error ?? "Ошибка валидации";

        public override T Data => default;
    }
}
