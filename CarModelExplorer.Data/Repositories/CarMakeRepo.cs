using CarModelExplorer.Core.Dtos;
using CarModelExplorer.Core.Entities;
using CarModelExplorer.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelExplorer.Infra.Repositories
{
    public class CarMakeRepo : ICarMakeRepo
    {
        private readonly CarDbContext _carDbContext;

        public CarMakeRepo(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }
        public async Task<CarMake> GetModels(string make)
        {
            return await _carDbContext.CarMakes.Where(c => c.MakeName.Trim() == make.ToUpper()).FirstOrDefaultAsync();
        }
    }
}
