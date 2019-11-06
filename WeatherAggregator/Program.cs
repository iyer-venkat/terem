using System;
using System.Collections.Generic;
using System.IO;
using WeatherAggregator.Models;

namespace WeatherAggregator
{
    class Program
    {
        List<YearlyAggregates> rainfallData = new List<YearlyAggregates>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rainfall Aggregator!");

            if(args.Length <= 0)
            {
                Console.WriteLine("Usage: WeatherAggregator.exe <<Path to the .csv file having rainfal data>>");
                return;
            }

            if(args.Length > 0)
            {
                BuildAggregatedRainfallData(args[0]);
            }
        }

        private static void BuildAggregatedRainfallData(string fileName)
        {
            var rainfall = new Rainfall();
            Console.WriteLine($"Working with the file {fileName} now...");
            StreamReader sr = null;
            string line = "";
            string[] rainData;
            string prevYear = "";
            string prevMonth = "";

            try
            {
                sr = new StreamReader(fileName);
                line = sr.ReadLine();   //leave the first line out as it is Header
                while ((line = sr.ReadLine()) != null)
                {
                    rainData = line.Split(',')[2..6];
                    //Console.WriteLine(string.Join(",", rainData));

                    if (prevMonth != "" && prevMonth != rainData[1])
                    {
                        rainfall.CreateMonthlyAggregateRecord(Convert.ToInt32(prevMonth), Convert.ToInt32(prevYear));
                    }
                    if (prevYear != "" && prevYear != rainData[0])
                    {
                        rainfall.CreateYearlyAggregateRecord(Convert.ToInt32(prevYear));
                    }

                    rainfall.CreateDailyRainfallRecord(rainData);
                    prevMonth = rainData[1];
                    prevYear = rainData[0];
                }

                //Add the last Monthly Aggregate
                rainfall.CreateMonthlyAggregateRecord(Convert.ToInt32(prevMonth), Convert.ToInt32(prevYear));
                //Add the last Yearly Aggregate
                rainfall.CreateYearlyAggregateRecord(Convert.ToInt32(prevYear));

                //Get the entire JSON
                Console.WriteLine(rainfall.GetYearlyAggregatedRainfallAsJson());
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing the file. Please check the file & try again.");
                if (sr != null)
                    sr.Close();
            }
        }
    }
}
