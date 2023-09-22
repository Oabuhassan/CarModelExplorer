using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarModelExplorer.Core.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Options;

namespace CarModelExplorer.Infra.Data
{
    public class CarDbContext: DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> opt) : base(opt)
        {
            Database.EnsureCreated();
        }
        public DbSet<CarMake> CarMakes { get; set; }
        public void InitializeFromCsvFile(string csvFilePath)
        {
            if (!CarMakes.Any())
            {
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    var records = csv.GetRecords<CarMake>().ToList();
                    CarMakes.AddRange(records);
                    SaveChanges();
                }
            }
        }
    }
}
