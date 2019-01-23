using StarshipDistanceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipDistanceCalculator.Interfaces
{
    public interface ILogger
    {
        void LogException(OperationResult<string> exception);
        void DisplayMessage(string message);
    }
}
