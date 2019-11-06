using System;
using System.Collections.Generic;
using System.Linq;
using WeatherAggregator.Utils;

namespace WeatherAggregator.Models
{
    public class Rainfall
    {
        private List<YearlyAggregates> YearlyAggregates { get; set; }
        private List<MonthlyAggregates> MonthlyAggregates { get; set; }
        private List<DailyRainData> DailyRainData { get; set; }
        private const int February = 2;

        public Rainfall()
        {
            YearlyAggregates = new List<YearlyAggregates>();
            MonthlyAggregates = new List<MonthlyAggregates>();
            DailyRainData = new List<DailyRainData>();
        }

        public void CreateYearlyAggregateRecord(int year)
        {
            YearlyAggregates.Add(new YearlyAggregates
            {
                Year = year,
                FirstRecordedDate = MonthlyAggregates[0].FirstRecordedDate,
                LastRecordedDate = MonthlyAggregates[MonthlyAggregates.Count - 1].LastRecordedDate,
                TotalRainfall = Math.Round(MonthlyAggregates.Sum(m => m.TotalRainfall), 2),
                AverageDailyRainfall = Math.Round(MonthlyAggregates.Sum(m => m.AverageDailyRainfall), 2),
                DaysWithNoRainfall = MonthlyAggregates.Sum(m => m.DaysWithNoRainfall),
                DaysWithRainfall = MonthlyAggregates.Sum(m => m.DaysWithRainfall),
                MonthlyAggregates = MonthlyAggregates.ToList()
            });
            MonthlyAggregates.Clear();
        }

        public void CreateMonthlyAggregateRecord(int month, int year)
        {
            MonthlyAggregates.Add(new MonthlyAggregates
            {
                Month = Dictionaries.MonthName[month],
                FirstRecordedDate = DailyRainData[0].DateRecorded,
                LastRecordedDate = DailyRainData[DailyRainData.Count - 1].DateRecorded,
                TotalRainfall = Math.Round(DailyRainData.Sum(d => d.Rainfall), 2),
                AverageDailyRainfall = Math.Round(DailyRainData.Average(d => d.Rainfall), 2),
                DaysWithRainfall = DailyRainData.Count,
                DaysWithNoRainfall = (!IsLeapYear(year) && month == February) ?
                                        Dictionaries.MonthDays[month] - 1 - DailyRainData.Count :
                                        Dictionaries.MonthDays[month] - DailyRainData.Count
            });
            DailyRainData.Clear();
        }

        public void CreateDailyRainfallRecord(string[] rainData)
        {
            if (!string.IsNullOrEmpty(rainData[3]))
                DailyRainData.Add(new DailyRainData
                {
                    DateRecorded = $"{rainData[0]}-{rainData[1]}-{rainData[2]}",
                    Rainfall = Convert.ToDecimal(rainData[3])
                });
        }

        public string GetYearlyAggregatedRainfallAsJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(YearlyAggregates);
        }

        private bool IsLeapYear(int year)
        {
            return (year % 4 == 0);
        }
    }
}
