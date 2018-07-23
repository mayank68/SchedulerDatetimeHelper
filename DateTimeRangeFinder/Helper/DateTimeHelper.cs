using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public enum Frequency
    {
        [Description("Everyday")]
        EveryDay = 0,
        [Description("Weekly")]
        Weekly = 1,
        [Description("Monthly")]
        Monthly = 4,
        [Description("Yearly")]
        Yearly = 5
    }

    public class DateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public static class DateTimeHelper
    {
        //Scheduler Add format as follow :
        //FREQ = WEEKLY; COUNT = 5; BYDAY = MO,TU,WE,TH,FR

        #region Daily and weekly
        //covered daily weeekly
        public static List<DateRange> FindDateRangeDailyAndWeekly(bool isEndDate, DateTime startDate, DateTime endDate, int noOfOccurance, DateTime utnillDate, Frequency frequency, string days, int dayofMonth)
        {
            try
            {
                List<DateRange> lstDateRange = new List<DateRange>();
                List<DateRange> lstFinalDateRange = new List<DateRange>();
                TimeSpan timeSpan = endDate - startDate;
                List<DateTime> StartdateTimeRange = new List<DateTime>();
                List<DateTime> EnddateTimeRange = new List<DateTime>();
                if (!isEndDate)
                {
                    if (frequency == Frequency.EveryDay)
                    {
                        utnillDate = startDate.AddDays(noOfOccurance - 1);
                    }
                    if (frequency == Frequency.Weekly)
                    {
                        utnillDate = startDate.AddDays((noOfOccurance * 7) - 1);
                    }
                    if (frequency == Frequency.Monthly)
                    {
                        utnillDate = startDate.AddMonths(noOfOccurance);
                    }
                }
                for (DateTime date = startDate; date.Date <= utnillDate.Date; date = date.AddDays(1))
                {
                    DateRange dateRange = new DateRange();
                    dateRange.StartDate = date;
                    dateRange.EndDate = date.AddDays(timeSpan.Days).AddHours(timeSpan.Hours).AddMinutes(timeSpan.Minutes);
                    lstDateRange.Add(dateRange);
                }
                lstFinalDateRange = FilterFrequnecy_WeeklyAndDaily(lstDateRange, frequency, days, dayofMonth);
                return lstFinalDateRange;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public static List<DateRange> FilterFrequnecy_WeeklyAndDaily(List<DateRange> list, Frequency frequency, string days, int dayOfMonth)
        {
            List<DateRange> lstDateTimeRange = new List<DateRange>();
            foreach (var item in list)
            {
                List<string> strNewList = new List<string>();
                string[] split = days.Split(',');
                if (frequency == Frequency.Weekly)
                {
                    foreach (var itemDays in split)
                    {
                        string Newitem;
                        if (itemDays.Equals("SU"))
                        {
                            Newitem = "Sunday";
                            strNewList.Add(Newitem);
                        }
                        if (itemDays.Equals("MO"))
                        {
                            Newitem = "Monday";
                            strNewList.Add(Newitem);
                        }
                        if (itemDays.Equals("TU"))
                        {
                            Newitem = "Tuesday";
                            strNewList.Add(Newitem);
                        }
                        if (itemDays.Equals("WE"))
                        {
                            Newitem = "Wednesday";
                            strNewList.Add(Newitem);
                        }
                        if (itemDays.Equals("TH"))
                        {
                            Newitem = "Thursday";
                            strNewList.Add(Newitem);
                        }
                        if (itemDays.Equals("FR"))
                        {
                            Newitem = "Friday";
                            strNewList.Add(Newitem);
                        }
                        if (itemDays.Equals("SA"))
                        {
                            Newitem = "Saturday";
                            strNewList.Add(Newitem);
                        }
                    }
                    foreach (var itemLst in strNewList)
                    {
                        if (item.StartDate.DayOfWeek.ToString() == itemLst.ToString())
                        {
                            lstDateTimeRange.Add(item);
                        }
                    }
                }
                if (frequency == Frequency.EveryDay)
                {
                    lstDateTimeRange = list;
                }
            }
            return lstDateTimeRange;
        }

        #region monthly

        public static bool NthDayOfMonthNumber(DateTime date, int dayNumber, string dayName)
        {
            int n = 0;
            if (dayName.ToLower().ToLower() == "first")
                n = 1;
            else if (dayName.ToLower().ToLower() == "second")
                n = 2;
            else if (dayName.ToLower().ToLower() == "third")
                n = 3;
            else if (dayName.ToLower().ToLower() == "fourth")
                n = 4;
            int d = date.Day;
            return (int)date.DayOfWeek == dayNumber && (d - 1) / 7 == (n - 1);
        }
        public static bool NthDayOfMonth(DateTime date, DayOfWeek dow, string dayName)
        {
            int n = 0;
            if (dayName.ToLower().ToLower() == "first")
                n = 1;
            else if (dayName.ToLower().ToLower() == "second")
                n = 2;
            else if (dayName.ToLower().ToLower() == "third")
                n = 3;
            else if (dayName.ToLower().ToLower() == "fourth")
                n = 4;
            int d = date.Day;
            return date.DayOfWeek == dow && (d - 1) / 7 == (n - 1);
        }
        public static List<DateRange> FindDateRange_Monthly(bool isEndDate, DateTime startDate, DateTime? endDate, int noOfOccurance, DateTime utnillDate, Frequency frequency, string days, int dayofMonth, bool isDayOfMonth, string weekNumber, string dayName,bool isWeekDay,int weekDay)
        {
            try
            {
                List<DateRange> lstDateRange = new List<DateRange>();
                List<DateRange> lstFinalDateRange = new List<DateRange>();
                TimeSpan timeSpan = endDate.Value - startDate;
                List<DateTime> StartdateTimeRange = new List<DateTime>();
                List<DateTime> EnddateTimeRange = new List<DateTime>();
                if (!isEndDate)
                {
                    if (frequency == Frequency.Monthly)
                    {
                        utnillDate = startDate.AddMonths(noOfOccurance);
                    }
                }
                for (DateTime date = startDate; date.Date <= utnillDate.Date; date = date.AddDays(1))
                {
                    DateRange dateRange = new DateRange();
                    dateRange.StartDate = date;
                    dateRange.EndDate = date.AddDays(timeSpan.Days).AddHours(timeSpan.Hours).AddMinutes(timeSpan.Minutes);
                    lstDateRange.Add(dateRange);
                }
                lstFinalDateRange = FilterFrequnecy_Monthly(lstDateRange, frequency, days, dayofMonth, isDayOfMonth, weekNumber, dayName,isWeekDay,weekDay);
                return lstFinalDateRange;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<DateRange> FilterFrequnecy_Monthly(List<DateRange> list, Frequency frequency, string days, int dayOfMonth, bool isDayOfMonth, string weekNumber, string dayName,bool isWeekDay,int weekDay)
        {
            List<DateRange> lstDateRange = new List<DateRange>();
            List<DateRange> FirstlstDateRange = new List<DateRange>();


            if (frequency == Frequency.Monthly)
            {
                foreach (var item in list)
                {
                    if (isDayOfMonth)
                    {
                        if (dayOfMonth <= 31)
                        {
                            if (item.StartDate.Day == dayOfMonth)
                            {
                                lstDateRange.Add(item);
                            }
                        }
                        else
                        {
                            //Todo exception message.
                        }

                    }
                    else
                    {
                        if (item.StartDate.DayOfWeek.ToString() == dayName)
                        {
                            CheckWeekDay(weekNumber, dayName, lstDateRange, item,isWeekDay, weekDay);

                        }

                    }
                }
            }
            return lstDateRange;
        }
        private static void CheckWeekDay(string weekNumber, string dayName, List<DateRange> lstDateRange, DateRange item,bool isWeekDay,int weekDay)
        {
            if(isWeekDay)
            {
                if (dayName.ToString().ToLower() == "monday")
                {
                    if (NthDayOfMonthNumber(item.StartDate, weekDay, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "tuesday")
                {
                    if (NthDayOfMonthNumber(item.StartDate, weekDay, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "wednesday")
                {
                    if (NthDayOfMonthNumber(item.StartDate, weekDay, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "thursday")
                {
                    if (NthDayOfMonthNumber(item.StartDate, weekDay, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "friday")
                {
                    if (NthDayOfMonthNumber(item.StartDate, weekDay, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "saturday")
                {
                    if (NthDayOfMonthNumber(item.StartDate, weekDay, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "sunday")
                {
                    if (NthDayOfMonthNumber(item.StartDate, weekDay, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
            }
            else
            {
                if (dayName.ToString().ToLower() == "monday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Monday, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "tuesday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Tuesday, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "wednesday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Wednesday, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "thursday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Thursday, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "friday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Friday, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "saturday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Saturday, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "sunday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Sunday, weekNumber))
                    {
                        lstDateRange.Add(item);
                    }
                }
            }
           
        }

        #endregion
    }
}