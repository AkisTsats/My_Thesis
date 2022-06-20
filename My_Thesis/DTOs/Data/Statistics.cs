using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Data
{
    public class StatisticsDTO
    {
        public int TotalAnnouncements { get; set; }
        public int TotalUsers { get; set; }
        public int TodayAnnouncements { get; set; }
        public int TodayPeakUsers { get; set; }

    }
}
