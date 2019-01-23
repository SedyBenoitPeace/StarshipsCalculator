using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipDistanceCalculator.Interfaces
{
    public interface IApiService
    {
        T Deserialize<T>(string input);
        //string MakeApiRequest(string url);
        OperationResult<string> MakeApiRequest(string url);
    }
}
