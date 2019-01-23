using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipDistanceCalculator.Models.Stariships
{
    public class StarshipsListDTO
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<StarshipDTO> Results { get; set; }
    }
}
