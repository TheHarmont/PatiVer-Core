using PatiVerCore.Application.DTOs;
using PatiVerCore.Domain.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Application.Interfaces
{
    public interface IFomsService
    {
        public Task<Result<PersonResponse>> GetPatientInfo<T>(T personData) where T : class;
    }
}
