using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitTests.BetweenDates.Response
{
    public class getInterval
    {
        public int days { get; set; }
        public int weekdays { get; set; }
        public int completeWeeks { get; set; }
        public String? weekdaysInSeconds { get; set; }
        public String? completeWeeksInSeconds { get; set; }
        public String? daysInSeconds { get; set; }
        public String? weekdaysInMinutes { get; set; }
        public String? completeWeeksInMinutes { get; set; }
        public String? daysInMinutes { get; set; }
        public String? weekdaysInHours { get; set; }
        public String? completeWeeksInHours { get; set; }
        public String? daysInHours { get; set; }
        public String? weekdaysInYears { get; set; }
        public String? completeWeeksInYears { get; set; }
        public String? daysInYears { get; set; }
        public String? message { get; set; }
    }
}