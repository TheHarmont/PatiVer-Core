using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Common.Result
{
    public enum ErrorType
    {
        NotFound = 0,
        MultipleFound = 1,
        Unexpected = 2,
        Invalid = 3,
        TimeOut = 4
    }
}
