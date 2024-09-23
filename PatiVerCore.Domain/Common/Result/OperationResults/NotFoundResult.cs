using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Common.Result.OperationResults
{
    /// <summary>
    /// Запись не найдена
    /// </summary>
    public sealed class NotFoundResult<T> : Result<T>
    {
        private readonly string? _error;

        public NotFoundResult()
        {
        }

        public NotFoundResult(string error)
        {
            _error = error;
        }

        public override ResultType ResultType => ResultType.NotFound;

        public override string ErrorMessage => _error ?? "Запись не найдена";

        public override T Data => default;
    }
}
