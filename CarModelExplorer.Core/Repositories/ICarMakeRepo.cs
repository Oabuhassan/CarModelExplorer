using CarModelExplorer.Core.Dtos;
using CarModelExplorer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelExplorer.Infra.Data
{
    public interface ICarMakeRepo
    {
        Task<CarMake> GetModels(string make);
    }
}
