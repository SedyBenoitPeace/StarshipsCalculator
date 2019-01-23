using StarshipDistanceCalculator.Interfaces;
using StarshipDistanceCalculator.Models;
using StarshipDistanceCalculator.Models.Stariships;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipDistanceCalculator.Services
{
    public class StarshipService : IStarshipService
    {

        public List<StarshipDTO> GetAllStarships()
        {
            ApiService apiService = new ApiService();
            var result = new List<StarshipDTO>();
            var starshipsList = new StarshipsListDTO();
            var url = ConfigurationManager.AppSettings["Starships.URL"];
            var elementsPerPage = Convert.ToInt32(ConfigurationManager.AppSettings["Starships.Api.ElementsPerPage"]);
            var starshipsDownload = apiService.MakeApiRequest(url);
            if (starshipsDownload.Success)
            {
                starshipsList = apiService.Deserialize<StarshipsListDTO>(starshipsDownload.Result);
                foreach (var item in starshipsList.Results)
                {
                    result.Add(item);
                }
                for (int i = 0; i < starshipsList.Count / elementsPerPage; i++) // we will make the additional calls only if the elements per page are defined
                {
                    if (!string.IsNullOrEmpty(starshipsList.Next))
                    {
                        var otherStarships = apiService.MakeApiRequest(starshipsList.Next);
                        starshipsList = apiService.Deserialize<StarshipsListDTO>(otherStarships.Result);
                        if (starshipsList != null && starshipsList.Results.Count() > 0)
                        {
                            foreach (var item in starshipsList.Results)
                            {
                                result.Add(item);
                            }
                        }
                    }
                }
                //result= apiService.Deserialize<List<StarshipDTO>>(starshipsDownload.Result);
            }
            return result;
        }

    }
}
