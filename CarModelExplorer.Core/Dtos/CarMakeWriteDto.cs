using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelExplorer.Core.Dtos
{
    public class CarMakeWriteDto
    {
        public int MakeId { get; set; }
        public string? MakeName { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
