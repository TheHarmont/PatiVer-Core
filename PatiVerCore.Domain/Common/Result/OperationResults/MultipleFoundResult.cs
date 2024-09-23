using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Common.Result.OperationResults
{
    /// <summary>
    /// Найдено больше одной записи
    /// </summary>
    public sealed class MultipleFoundResult<T> : Result<T>
    {
        private readonly string? _error;

        public MultipleFoundResult()
        {
        }

        public MultipleFoundResult(string error)
        {
            _error = error;
        }

        public override ResultType ResultType => ResultType.MultipleFound;

        public override string ErrorMessage => _error ?? "Было найдено больше одной записи";

        public override T Data => default;
    }
}
