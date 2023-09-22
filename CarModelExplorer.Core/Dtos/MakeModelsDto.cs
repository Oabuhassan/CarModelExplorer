using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarModelExplorer.Core.Dtos
{

    public class MakeModel
    {
        public int Make_ID { get; set; }
        public string Make_Name { get; set; }
        public int Model_ID { get; set; }
        public string Model_Name { get; set; }
    }
    [XmlRoot("Response")]
    public class ApiResponse
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }

        // If there's an additional layer of nesting:
        [XmlElement("Results")]
        public ResultsContainer Results { get; set; }
    }

    public class ResultsContainer
    {
        [XmlElement("MakeModels")]
        public List<MakeModel> MakeModels { get; set; }
    }
}
