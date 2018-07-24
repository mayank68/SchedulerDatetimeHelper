using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeRangeFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            DateInput dateInput = new DateInput()
            {
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(2),
                UntillDate = DateTime.Now.AddYears(3).AddDays(1),              
                isEndDateDefined = true
            };

            //Every day 
            //DailyInput(dateInput);
            //Selected week days check box options
            //WeekOptionsInput(dateInput);
            YearlyOptionsInput(dateInput);
            //DateInput dateInput = new DateInput()
            //{
            //    StartDateTime = DateTime.Now,
            //    EndDateTime = DateTime.Now.AddHours(2),
            //    UntillDate = DateTime.Now.AddYears(2),
            //    DaysOfWeek = "MO,TU,WE",
            //    isEndDateDefined = true,

            //    frequency = Helper.Frequency.Monthly,
            //    Occurance = 5,
            //    DayName = "ss",
            //    DayFormat = "third",
            //    //Day number say this is friday
            //    WeekDay = 0,
            //    isDayOfMonth = true,
            //    //This is for weekday option like mon,tue,we,we,thu
            //    isWeekDay = true,
            //    YearlyMonthDay = 10,
            //    YearlyMonth = "February",

            //    //yearly: like fourth Sunday of April to december
            //    isMonthlyWeekName = true,
            //    MonthlyName = "April",
            //    MonthlyWeekDay = "Sunday",
            //    MonthlyWeekDayNumber = "fourth"


            //};
            //Console.WriteLine("-------------Input-----------------");
            //Console.WriteLine("start time:" + dateInput.StartDateTime);
            //Console.WriteLine("end time:" + dateInput.StartDateTime);
            //Console.WriteLine("untill date:" + dateInput.UntillDate);
            //Console.WriteLine("days of week:" + dateInput.DaysOfWeek);
            //Console.WriteLine("End date:" + dateInput.isEndDateDefined);
            //Console.WriteLine("Occurance:" + dateInput.Occurance);
            //Console.WriteLine("day name:" + dateInput.DayName);
            //Console.WriteLine("WeekDay:" + dateInput.WeekDay);
            //Console.WriteLine("day format:" + dateInput.DayFormat);
            //Console.WriteLine("isWeekDay:" + dateInput.isWeekDay);
            //Console.WriteLine("MonthlyName:" + dateInput.MonthlyName);
            //Console.WriteLine("MonthlyWeekDay:" + dateInput.MonthlyWeekDay);
            //Console.WriteLine("MonthlyWeekDayNumber:" + dateInput.MonthlyWeekDayNumber);
            //Console.WriteLine("-------------Input-----------------");

            //var outPut = Helper.DateTimeHelper.FindDateRangeDailyAndWeekly(dateInput.isEndDateDefined, dateInput.StartDateTime, dateInput.EndDateTime, dateInput.Occurance, dateInput.UntillDate, dateInput.frequency, dateInput.DaysOfWeek, dateInput.dayOfMonth);
            ////var outPut = Helper.DateTimeHelper.FindDateRange_Monthly(dateInput.isEndDateDefined, dateInput.StartDateTime, dateInput.EndDateTime, dateInput.Occurance, dateInput.UntillDate, dateInput.frequency, dateInput.DaysOfWeek, 24, dateInput.isDayOfMonth, dateInput.DayFormat, dateInput.DayName, dateInput.isWeekDay, dateInput.WeekDay);
            ////var outPut = Helper.DateTimeHelper.FindDateRange_Yearly(true, dateInput.StartDateTime, dateInput.EndDateTime, 5, dateInput.UntillDate, dateInput.frequency, dateInput.YearlyMonth,dateInput.YearlyMonthDay,true,dateInput.MonthlyName,dateInput.MonthlyWeekDay,dateInput.MonthlyWeekDayNumber);

            //Console.WriteLine("-------------OutPut-----------------");
            //foreach (var item in outPut)
            //{
            //    Console.WriteLine("----" + item.StartDate + "-------" + item.EndDate + "----");
            //}
            //Console.WriteLine("--------------end-------------------");
            //Console.Read();
        }

        private static void DailyInput(DateInput dailyDateInput)
        {
            dailyDateInput.frequency = Helper.Frequency.EveryDay;


            Console.WriteLine("-------------daily Input-----------------");
            Console.WriteLine("-------StartDateTime--" + dailyDateInput.StartDateTime + "-----------------");
            Console.WriteLine("-------EndDateTime--" + dailyDateInput.EndDateTime + "-----------------");
            Console.WriteLine("-------UntillDate--" + dailyDateInput.UntillDate + "-----------------");
            Console.WriteLine("-------frequency--" + dailyDateInput.frequency.ToString() + "-----------------");
            Console.WriteLine("-------dayOfMonth--" + dailyDateInput.dayOfMonth.ToString() + "-----------------");
            Console.WriteLine("-------Is day of month--" + dailyDateInput.isDayOfMonth + "-----------------");
            Console.WriteLine("-------Is enddate defined--" + dailyDateInput.isEndDateDefined + "-----------------");            
            Console.WriteLine("-------------daily Input-----------------");
            OutputDailyWeekly(dailyDateInput);
        }

        private static void WeekOptionsInput(DateInput DateInput)
        {
            DateInput.frequency = Helper.Frequency.Weekly;
            DateInput.DaysOfWeek = "MO,TU";
            //This will return selected days like su,mo,tu between specific date range.

            Console.WriteLine("-------------daily Input-----------------");
            Console.WriteLine("-------StartDateTime--" + DateInput.StartDateTime + "-----------------");
            Console.WriteLine("-------EndDateTime--" + DateInput.EndDateTime + "-----------------");
            Console.WriteLine("-------UntillDate--" + DateInput.UntillDate + "-----------------");
            Console.WriteLine("-------frequency--" + DateInput.frequency.ToString() + "-----------------");
            Console.WriteLine("-------dayOfMonth--" + DateInput.dayOfMonth.ToString() + "-----------------");
            Console.WriteLine("-------Is day of month--" + DateInput.isDayOfMonth + "-----------------");
            Console.WriteLine("-------Is enddate defined--" + DateInput.isEndDateDefined + "-----------------");
            Console.WriteLine("-------Days of week--" + DateInput.DaysOfWeek + "-----------------");
            Console.WriteLine("-------------daily Input-----------------");
            OutputDailyWeekly(DateInput);
        }
        private static void MonthlyOptionsInput(DateInput DateInput)
        {
            DateInput.frequency = Helper.Frequency.Monthly;
            //this is for 31 date of every month
            //DateInput.dayOfMonth = 8;
            //DateInput.isDayOfMonth = true;//if want set repeat on specific day of month say 5th day of months etc.

            //this is getting first,second etc sunday,monday of month.
            //DateInput.isDayOfMonth = false;//like first monday of month etc.            
            //DateInput.DayName = "Sunday";
            //DateInput.DayFormat = "second";


            Console.WriteLine("-------------daily Input-----------------");
            Console.WriteLine("-------StartDateTime--" + DateInput.StartDateTime + "-----------------");
            Console.WriteLine("-------EndDateTime--" + DateInput.EndDateTime + "-----------------");
            Console.WriteLine("-------UntillDate--" + DateInput.UntillDate + "-----------------");
            Console.WriteLine("-------frequency--" + DateInput.frequency.ToString() + "-----------------");
            Console.WriteLine("-------dayOfMonth--" + DateInput.dayOfMonth.ToString() + "-----------------");
            Console.WriteLine("-------Is day of month--" + DateInput.isDayOfMonth + "-----------------");
            Console.WriteLine("-------Is enddate defined--" + DateInput.isEndDateDefined + "-----------------");
            Console.WriteLine("-------------daily Input-----------------");
            OutputMonthly(DateInput);
        }

        private static void YearlyOptionsInput(DateInput DateInput)
        {
            DateInput.frequency = Helper.Frequency.Yearly;

            //this is for 31 date of every month
            //DateInput.dayOfMonth = 8;
            //DateInput.isDayOfMonth = true;//if want set repeat on specific day of month say 5th day of months etc.

            //this is getting first,second etc sunday,monday of month.
            //DateInput.isDayOfMonth = false;//like first monday of month etc.            
            //DateInput.DayName = "Sunday";
            //DateInput.DayFormat = "second";

            DateInput.isMonthlyWeekName = true;
            DateInput.MonthlyWeekDay = "Tuesday";
            DateInput.MonthlyName = "March";
            DateInput.MonthlyWeekDayNumber = "third";

            Console.WriteLine("-------------daily Input-----------------");
            Console.WriteLine("-------StartDateTime--" + DateInput.StartDateTime + "-----------------");
            Console.WriteLine("-------EndDateTime--" + DateInput.EndDateTime + "-----------------");
            Console.WriteLine("-------UntillDate--" + DateInput.UntillDate + "-----------------");
            Console.WriteLine("-------frequency--" + DateInput.frequency.ToString() + "-----------------");
            Console.WriteLine("-------dayOfMonth--" + DateInput.dayOfMonth.ToString() + "-----------------");
            Console.WriteLine("-------Is day of month--" + DateInput.isDayOfMonth + "-----------------");
            Console.WriteLine("-------Is enddate defined--" + DateInput.isEndDateDefined + "-----------------");
            Console.WriteLine("-------------daily Input-----------------");
            OutputYearly(DateInput);
        }

        private static void OutputDailyWeekly(DateInput dailyDateInput)
        {
            var outPut = Helper.DateTimeHelper.FindDateRangeDailyAndWeekly(dailyDateInput.isEndDateDefined, dailyDateInput.StartDateTime, dailyDateInput.EndDateTime, dailyDateInput.Occurance, dailyDateInput.UntillDate, dailyDateInput.frequency, dailyDateInput.DaysOfWeek, dailyDateInput.dayOfMonth);
            Console.WriteLine("-------------output-----------------");
            foreach (var item in outPut)
            {
                Console.WriteLine("----" + item.StartDate + "-------" + item.EndDate + "----");
            }
            Console.WriteLine("-------------output-----------------");
            Console.Read();
        }

        private static void OutputYearly(DateInput dateInput)
        {
            var outPut = Helper.DateTimeHelper.FindDateRange_Yearly(true, dateInput.StartDateTime, dateInput.EndDateTime, 5, dateInput.UntillDate, dateInput.frequency, dateInput.YearlyMonth, dateInput.YearlyMonthDay, dateInput.isMonthlyWeekName, dateInput.MonthlyName, dateInput.MonthlyWeekDay, dateInput.MonthlyWeekDayNumber);
            Console.WriteLine("-------------output-----------------");
            foreach (var item in outPut)
            {
                Console.WriteLine("----" + item.StartDate + "-------" + item.EndDate + "----");
            }
            Console.WriteLine("-------------output-----------------");
            Console.Read();
        }
        private static void OutputMonthly(DateInput dateInput)
        {
            var outPut = Helper.DateTimeHelper.FindDateRange_Monthly(dateInput.isEndDateDefined, dateInput.StartDateTime, dateInput.EndDateTime, dateInput.Occurance, dateInput.UntillDate, dateInput.frequency, dateInput.DaysOfWeek, dateInput.dayOfMonth, dateInput.isDayOfMonth, dateInput.DayFormat, dateInput.DayName, dateInput.isWeekDay, dateInput.WeekDay);
            Console.WriteLine("-------------output-----------------");
            foreach (var item in outPut)
            {
                Console.WriteLine("----" + item.StartDate + "-------" + item.EndDate + "----");
            }
            Console.WriteLine("-------------output-----------------");
            Console.Read();
        }
    }
    public class DateInput
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime UntillDate { get; set; }
        public string DaysOfWeek { get; set; }//Comma seprated set of week days like MO,TU,WE
        public Helper.Frequency frequency { get; set; }
        public bool isEndDateDefined { get; set; }//If end date is defined.
        public int Occurance { get; set; }//if end date is not defined then check no of occurance.
        public string DayName { get; set; }
        public string DayFormat { get; set; }
        public int WeekDay { get; set; }        
        public bool isWeekDay { get; set; }//Set true whene frequecy monthly and weekday option. eg: secondy weekday not working
        public string YearlyMonth { get; set; }
        public int YearlyMonthDay { get; set; }
        public bool isMonthlyWeekName { get; set; }//Yearly: set 
        public string MonthlyName { get; set; }//Yearly eg:January
        public string MonthlyWeekDay { get; set; }//Yearly eg:Monday
        public string MonthlyWeekDayNumber { get; set; }//eg:first
        public bool isDayOfMonth { get; set; }
        public int dayOfMonth { get; set; }

    }
}
