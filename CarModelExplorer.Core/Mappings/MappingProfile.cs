using CarModelExplorer.Core.Dtos;
using CarModelExplorer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelExplorer.Core.Mappings
{
    internal class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<CarMake, CarMakeReadDto>();
            CreateMap<CarMakeWriteDto, CarMake>();
        }
    }
}
