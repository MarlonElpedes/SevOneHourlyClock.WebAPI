using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SevOneHourlyClock.WebAPI.Commmon
{
    public static class clsExtension
    {
        public static int ToRemainSeconds(this DateTime startdate)
        {
            int hourInSeconds = 3600;

            DateTime currentUTCDate = DateTime.UtcNow;
            TimeSpan diffInSeconds = currentUTCDate - startdate;
            int minToSeconds = diffInSeconds.Minutes * 60;
            return hourInSeconds - (minToSeconds + diffInSeconds.Seconds);
        }


        public static DateTime ToEST(this DateTime utcStartDate)
        {       
        
            var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");    
            return TimeZoneInfo.ConvertTimeFromUtc(utcStartDate, easternZone);
        }
    }
}