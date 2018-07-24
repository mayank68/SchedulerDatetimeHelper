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
        public static List<DateRange> FilterFrequnecy_WeeklyAndDaily(List<DateRange> list, Frequency frequency, string days, int dayOfMonth)
        {
            List<DateRange> lstDateTimeRange = new List<DateRange>();
            string[] split;
            foreach (var item in list)
            {
                List<string> strNewList = new List<string>();
                if(!string.IsNullOrEmpty(days))
                {
                    split = days.Split(',');
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
                }
                if (frequency == Frequency.EveryDay)
                {
                    lstDateTimeRange = list;
                }
            }
            return lstDateTimeRange;
        }
        #endregion

        #region Monthly
        public static bool NthDayOfMonthNumber(DateTime date, int dayNumber, string dayName)
        {
            int n = 0;
            if (dayName.ToLower() == "first")
                n = 1;
            else if (dayName.ToLower() == "second")
                n = 2;
            else if (dayName.ToLower() == "third")
                n = 3;
            else if (dayName.ToLower() == "fourth")
                n = 4;
            
            return (int)date.DayOfWeek == dayNumber && (dayNumber - 1) / 7 == (n - 1);
        }
        public static bool NthDayOfMonthNumberWithMonth(DateTime date, string dayNumber,int WeekNumber ,int month )
        {
            int n=0;
            if (dayNumber.ToLower() == "first")
                n = 1;
            else if (dayNumber.ToLower() == "second")
                n = 2;
            else if (dayNumber.ToLower() == "third")
                n = 3;
            else if (dayNumber.ToLower() == "fourth")
                n = 4;
            int d = date.Day;
            return (int)date.DayOfWeek == WeekNumber && (int)date.Month == month && (d - 1) / 7 == (n - 1);
        }
        public static bool NthDayOfMonth(DateTime date, DayOfWeek dow, string dayName)
        {
            int n = 0;
            if (dayName.ToLower() == "first")
                n = 1;
            else if (dayName.ToLower() == "second")
                n = 2;
            else if (dayName.ToLower() == "third")
                n = 3;
            else if (dayName.ToLower() == "fourth")
                n = 4;
            int d = date.Day;
            return date.DayOfWeek == dow && (d - 1) / 7 == (n - 1);
        }
        public static List<DateRange> FindDateRange_Monthly(bool isEndDate, DateTime startDate, DateTime? endDate, int noOfOccurance, DateTime utnillDate, Frequency frequency, string days, int dayofMonth, bool isDayOfMonth, string dayFormat, string dayName, bool isWeekDay, int weekDay)
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
                lstFinalDateRange = FilterFrequnecy_Monthly(lstDateRange, frequency, days, dayofMonth, isDayOfMonth, dayFormat, dayName, isWeekDay, weekDay);
                return lstFinalDateRange;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<DateRange> FilterFrequnecy_Monthly(List<DateRange> list, Frequency frequency, string days, int dayOfMonth, bool isDayOfMonth, string dayFormat, string dayName, bool isWeekDay, int weekDay)
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
                        CheckWeekDay(dayFormat, dayName, lstDateRange, item, isWeekDay, weekDay);
                    }
                }
            }
            return lstDateRange;
        }
        private static void CheckWeekDay(string dayFormat, string dayName, List<DateRange> lstDateRange, DateRange item, bool isWeekDay, int weekDay)
        {
            if (isWeekDay)
            {
                //if (NthDayOfMonthNumber(item.StartDate, weekDay, dayName))
                //{
                //    lstDateRange.Add(item);
                //}
            }
            else
            {
                if (dayName.ToString().ToLower() == "monday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Monday, dayFormat))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "tuesday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Tuesday, dayFormat))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "wednesday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Wednesday, dayFormat))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "thursday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Thursday, dayFormat))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "friday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Friday, dayFormat))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "saturday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Saturday, dayFormat))
                    {
                        lstDateRange.Add(item);
                    }
                }
                if (dayName.ToString().ToLower() == "sunday")
                {
                    if (NthDayOfMonth(item.StartDate, DayOfWeek.Sunday, dayFormat))
                    {
                        lstDateRange.Add(item);
                    }
                }
            }

        }
        #endregion

        #region Yearly
        public static List<DateRange> FindDateRange_Yearly(bool isEndDate, DateTime startDate, DateTime? endDate, int noOfOccurance, DateTime utnillDate, Frequency frequency, string Month, int MonthDay, bool isMonthlyWeekName, string MonthlyName, string MonthlyWeekDay, string MonthlyWeekDayNumber)
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
                    if (frequency == Frequency.Yearly)
                    {
                        utnillDate = startDate.AddYears(noOfOccurance);
                    }
                }
                for (DateTime date = startDate; date.Date <= utnillDate.Date; date = date.AddDays(1))
                {
                    DateRange dateRange = new DateRange();
                    dateRange.StartDate = date;
                    dateRange.EndDate = date.AddDays(timeSpan.Days).AddHours(timeSpan.Hours).AddMinutes(timeSpan.Minutes);
                    lstDateRange.Add(dateRange);
                }
                lstFinalDateRange = FilterFrequnecy_Yearly(lstDateRange, frequency, Month, MonthDay, isMonthlyWeekName, MonthlyName, MonthlyWeekDay, MonthlyWeekDayNumber);
                return lstFinalDateRange;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DateRange> FilterFrequnecy_Yearly(List<DateRange> list, Frequency frequency, string Month, int MonthDay, bool isMonthlyWeekName, string MonthlyName, string MonthlyWeekDay, string MonthlyWeekDayNumber)
        {
            List<DateRange> lstFinalDateRange = new List<DateRange>();
            if (!isMonthlyWeekName)
            {
                int monthNumber = 0;
                if (Month.ToString().ToLower() == "january")
                    monthNumber = 1;
                else if (Month.ToString().ToLower() == "february")
                    monthNumber = 2;
                else if (Month.ToString().ToLower() == "march")
                    monthNumber = 3;
                else if (Month.ToString().ToLower() == "april")
                    monthNumber = 4;
                else if (Month.ToString().ToLower() == "may")
                    monthNumber = 5;
                else if (Month.ToString().ToLower() == "june")
                    monthNumber = 6;
                else if (Month.ToString().ToLower() == "july")
                    monthNumber = 7;
                else if (Month.ToString().ToLower() == "august")
                    monthNumber = 8;
                else if (Month.ToString().ToLower() == "suptember")
                    monthNumber = 9;
                else if (Month.ToString().ToLower() == "october")
                    monthNumber = 10;
                else if (Month.ToString().ToLower() == "november")
                    monthNumber = 11;
                else if (Month.ToString().ToLower() == "december")
                    monthNumber = 12;
                foreach (var item in list)
                {
                    if (item.StartDate.Day == MonthDay && item.StartDate.Month == monthNumber)
                    {
                        lstFinalDateRange.Add(item);
                    }
                }
            }
            else
            {
                int monthNumber = 0;
                if (MonthlyName.ToLower() == "january")
                    monthNumber = 1;
                else if (MonthlyName.ToLower() == "february")
                    monthNumber = 2;
                else if (MonthlyName.ToString().ToLower() == "march")
                    monthNumber = 3;
                else if (MonthlyName.ToString().ToLower() == "april")
                    monthNumber = 4;
                else if (MonthlyName.ToString().ToLower() == "may")
                    monthNumber = 5;
                else if (MonthlyName.ToString().ToLower() == "june")
                    monthNumber = 6;
                else if (MonthlyName.ToString().ToLower() == "july")
                    monthNumber = 7;
                else if (MonthlyName.ToString().ToLower() == "august")
                    monthNumber = 8;
                else if (MonthlyName.ToString().ToLower() == "suptember")
                    monthNumber = 9;
                else if (MonthlyName.ToString().ToLower() == "october")
                    monthNumber = 10;
                else if (MonthlyName.ToString().ToLower() == "november")
                    monthNumber = 11;
                else if (MonthlyName.ToString().ToLower() == "december")
                    monthNumber = 12;

                int WeekNumber = 0;
                if (MonthlyWeekDay.ToLower() == "monday")
                    WeekNumber = 1;
                else if (MonthlyWeekDay.ToLower() == "tuesday")
                    WeekNumber = 2;
                else if (MonthlyWeekDay.ToLower() == "wednesday")
                    WeekNumber = 3;
                else if (MonthlyWeekDay.ToLower() == "thursday")
                    WeekNumber = 4;
                else if (MonthlyWeekDay.ToLower() == "friday")
                    WeekNumber = 5;
                else if (MonthlyWeekDay.ToLower() == "saturday")
                    WeekNumber = 6;
                else if (MonthlyWeekDay.ToLower() == "sunday")
                    WeekNumber = 0;

                foreach (var item in list)
                {
                    if (NthDayOfMonthNumberWithMonth(item.StartDate, MonthlyWeekDayNumber, WeekNumber, monthNumber))
                    {
                        lstFinalDateRange.Add(item);
                    }
                }

            }
            return lstFinalDateRange;
        }
        #endregion
    }
}