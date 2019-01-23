using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipDistanceCalculator.Models.Stariships
{
    public class ResultDTO
    {
        public ResultDTO()
        {
            this.Unknown = false;
        }
        public string StarshipName { get; set; }
        public long NumberOfStops { get; set; }
        public bool Unknown { get; set; }
    }
}
