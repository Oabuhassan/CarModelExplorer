using CarModelExplorer.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelExplorer.Core.Interfaces
{
    public interface ICarMake
    {
        Task<CarMakeReadDto> GetModels(int modelYear,string make);
    }
}
