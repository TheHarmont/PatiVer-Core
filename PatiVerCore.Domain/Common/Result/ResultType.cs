using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Common.Result
{
    public enum ResultType
    {
        Ok = 0,
        NotFound = 1,
        MultipleFound = 2,
        Unexpected = 3,
        Invalid = 4
    }
}
