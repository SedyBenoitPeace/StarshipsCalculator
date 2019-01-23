using StarshipDistanceCalculator.Constants;
using StarshipDistanceCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StarshipDistanceCalculator
{
    public class Logger : ILogger
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);

        }

        public void LogException(OperationResult<string> exception)
        {
            Console.WriteLine(exception.NonSuccessMessage);
            Console.WriteLine(Messages.PRESSTOEXIT);
            Console.ReadLine();
        }
    }
}
