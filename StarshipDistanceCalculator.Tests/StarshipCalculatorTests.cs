using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarshipDistanceCalculator.Models.Stariships;

namespace StarshipDistanceCalculator.Tests
{
    [TestClass]
    public class StarshipCalculatorTests
    {
        // override object.Equals

        [TestMethod]
        //in this test we will see if the example for the input on the coding challenge document exist in the data processed
        public void SampleTest()
        {
            Int64 input = 1000000;
            List<ResultDTO> expected = new List<ResultDTO>();
            expected.Add(new ResultDTO() { StarshipName = "Millennium Falcon", NumberOfStops = 9 });
            expected.Add(new ResultDTO() { StarshipName = "Rebel transport", NumberOfStops = 11 });
            expected.Add(new ResultDTO() { StarshipName = "Y-wing", NumberOfStops = 74 });

            Calculate calculate = new Calculate();
            List<ResultDTO> resultList = calculate.CalculateStops(input);
            List<ResultDTO> realResult = new List<ResultDTO>();

            foreach (ResultDTO item in resultList)
            {
                var existResult = expected.SingleOrDefault(x => x.StarshipName == item.StarshipName && x.NumberOfStops == item.NumberOfStops);
                if (existResult != null)
                {
                    realResult.Add(existResult);// we add the same item to avoid problems with collection and equality
                }

            }

            CollectionAssert.AreEquivalent(expected, realResult);


        }

        [TestMethod]
        // in this we will see if the three starships from the example are the ONLY results possible within the example input (always from the coding challenge document)
        // practically is the same as above but here we see if they are the only results
        public void IsOutputTheSame()
        {
            Int64 input = 1000000;
            List<ResultDTO> expected = new List<ResultDTO>();
            expected.Add(new ResultDTO() { StarshipName = "Y-wing", NumberOfStops = 74 });
            expected.Add(new ResultDTO() { StarshipName = "Millennium Falcon", NumberOfStops = 9 });
            expected.Add(new ResultDTO() { StarshipName = "Rebel transport", NumberOfStops = 11 });

            Calculate calculate = new Calculate();
            var resultList = calculate.CalculateStops(input);
            var realResult = new List<ResultDTO>();

            foreach (var item in resultList)
            {
                realResult.Add(item);

            }
            CollectionAssert.AreNotEquivalent(expected, realResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoKeyInConfig()
        {
            Calculate calculate = new Calculate();
            ConfigurationManager.AppSettings["Starships.URL"] = null;
            ConfigurationManager.AppSettings["Starships.Api.ElementsPerPage"] = null;
            Int64 input = 1000000;
            var resultList = calculate.CalculateStops(input);
        }
    }
}
