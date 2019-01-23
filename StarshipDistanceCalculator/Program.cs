using StarshipDistanceCalculator.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipDistanceCalculator
{
    class Program
    {
        public static Logger logger = new Logger(); // will be avalaible class wide, of course the best is to have dependency injection with inferface
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Hi, please enter distance to cover in mega lights (MGLT) e.g. 1000000: ");
                var input = Console.ReadLine();
                input = ParseInput(input); // function defined below
                Int64 distanceToCover = Int64.Parse(input);
                Console.WriteLine($"The distance that you want to cover is: {distanceToCover}");
                Calculate calculate = new Calculate();
                var starshipsWithDistance = calculate.CalculateStops(distanceToCover);
                Console.Write("Everything is done, check it out: \r\n");
                foreach (var item in starshipsWithDistance)
                {
                    if(item.Unknown)
                    {
                        Console.WriteLine(string.Format("Sorry the speed for {0} is unknown, basically the calculation will give you {1} stops", item.StarshipName, item.NumberOfStops));
                        continue;
                    }
                    Console.WriteLine("{0} {1} stops", item.StarshipName, item.NumberOfStops);
                }
                Console.WriteLine("Press a button to exit");
                Console.ReadLine();

            }
            catch (Exception e)
            {
                //for the sake of simpleness the logger will write to console but of course it's not a good practice to show the user the exception, 
                //then in the logger we need to create a file or store in db or something like that
                OperationResult<string> error = OperationResult<string>.CreateFailure(e);
                logger.LogException(error);
            }
        }

        //before parsing the number in int64 we check if the input is indeed a valid number, if not we will keep asking for a new input until valid
        // in this way we will totally avoid wrong input (this is also why I didn't make a proper test about it)
        private static string ParseInput(string input)
        {
            int number = 0;
            bool isNumber = false;
            while (!isNumber)
            {
                isNumber = int.TryParse(input, out number);
                if (!isNumber)
                {
                    logger.DisplayMessage(Messages.INVALIDINPUT);
                    input = Console.ReadLine();
                }
            }
            return input;
        }
    }

}
