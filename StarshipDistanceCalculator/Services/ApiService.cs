using Newtonsoft.Json;
using StarshipDistanceCalculator.Constants;
using StarshipDistanceCalculator.Interfaces;
using StarshipDistanceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarshipDistanceCalculator.Services
{
    //general service to handle the apis
    public class ApiService : IApiService
    {
        public T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public OperationResult<string> MakeApiRequest(string url)
        {
            OperationResult<string> result = null;
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "identity");

            HttpResponseMessage response = new HttpResponseMessage();
            response = httpClient.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                result = OperationResult<string>.CreateSuccessResult(data);
            }
            else
            {
                result = OperationResult<string>.CreateFailure(ApiErrors.ERROR);
            }
            return result;
        }
    }
}
