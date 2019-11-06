using System;
using System.Collections.Generic;

namespace WeatherAggregator.Models
{
    public class YearlyAggregates
    {
        public int Year { get; set; }
        public string FirstRecordedDate { get; set; }
        public string LastRecordedDate { get; set; }
        public decimal TotalRainfall { get; set; }
        public decimal AverageDailyRainfall { get; set; }
        public int DaysWithNoRainfall { get; set; }
        public int DaysWithRainfall { get; set; }
        public int LongestNumberOfDaysRaining { get; set; }
        public List<MonthlyAggregates> MonthlyAggregates { get; set; }
    }
}
