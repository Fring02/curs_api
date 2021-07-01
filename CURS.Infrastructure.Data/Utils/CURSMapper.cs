using AutoMapper;
using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CURS.Infrastructure.Data.Utils
{
    public class CURSMapper : Profile
    {
        public CURSMapper()
        {
            CreateMap<Name, NameDto>();
        }
    }
}
