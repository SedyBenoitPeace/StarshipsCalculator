using StarshipDistanceCalculator.Interfaces;
using StarshipDistanceCalculator.Models.Enumerators;
using StarshipDistanceCalculator.Models.Stariships;
using StarshipDistanceCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipDistanceCalculator
{

    public class Calculate
    {
        public int getDays(int number, string timeString)
        {
            int timeValue = (int)Enum.Parse(typeof(EnumDaysForString), timeString, true);
            var days = number * timeValue;
            return days;
        }

        public List<ResultDTO> CalculateStops(long distance)
        {
            StarshipService starshipService = new StarshipService();
            var result = new List<ResultDTO>();
            var starships = starshipService.GetAllStarships();
            foreach (var starship in starships)
            {
                var resultToAdd = new ResultDTO();
                int MGLT = 0;
                long stops = 0;
                if (starship.MGLT == "unknown")
                {
                    resultToAdd.Unknown = true;
                }
                else
                {
                    MGLT = Convert.ToInt32(starship.MGLT);
                }
                string[] consumablesParsing = starship.Consumables.Split(' ');
                if (consumablesParsing.Length == 2 && MGLT != 0)
                {
                    int consumableNumber = Convert.ToInt32(consumablesParsing[0]); // get the consumables lemits for the the star ship
                    string strTime = consumablesParsing[1];  // Get the Start time form consumable 
                    int consumablesDays = getDays(consumableNumber, strTime);

                    int movimentInOneDay = MGLT * 24;
                    int distanceUntilNextStop = movimentInOneDay * consumablesDays;
                    stops = distance / distanceUntilNextStop;
                }
                resultToAdd.StarshipName = starship.Name;
                resultToAdd.NumberOfStops = stops;
                result.Add(resultToAdd);

            }
            return result;
        }
    }
}
