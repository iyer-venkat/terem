using System;
namespace WeatherAggregator.Models
{
    public class MonthlyAggregates
    {
        public string Month { get; set; }
        public string FirstRecordedDate { get; set; }
        public string LastRecordedDate { get; set; }
        public decimal TotalRainfall { get; set; }
        public decimal AverageDailyRainfall { get; set; }
        public decimal MedianDailyRainfall { get; set; }
        public int DaysWithNoRainfall { get; set; }
        public int DaysWithRainfall { get; set; }
    }
}
