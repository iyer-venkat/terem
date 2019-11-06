using System;
using System.Collections.Generic;

namespace WeatherAggregator.Utils
{
    public static class Dictionaries
    {
        public static Dictionary<int, string> MonthName = new Dictionary<int, string> {
            { 1, "January" },
            { 2, "February" },
            { 3, "March" },
            { 4, "April" },
            { 5, "May" },
            { 6, "June" },
            { 7, "July" },
            { 8, "August" },
            { 9, "September" },
            { 10, "October" },
            { 11, "November" },
            { 12, "December" },
        };

        public static Dictionary<int, int> MonthDays = new Dictionary<int, int>
        {
            {1, 31 },
            {2, 29 },
            {3, 31 },
            {4, 30 },
            {5, 31 },
            {6, 30 },
            {7, 31 },
            {8, 31 },
            {9, 30 },
            {10, 31 },
            {11, 30 },
            {12, 31 },
        };
    }
}
