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
                UntillDate = DateTime.Now.AddYears(2),
                DaysOfWeek = "MO,TU,WE",
                isEndDateDefined = true,
                frequency=Helper.Frequency.Monthly,
                Occurance=5,
                DayName= "ss",
                DayFormat= "third",
				//Day number say this is friday
                WeekDay=0,
				//This is for weekday option
                isWeekDay=true
            };
            Console.WriteLine("-------------Input-----------------");
            Console.WriteLine("start time:"+ dateInput.StartDateTime);
            Console.WriteLine("end time:" + dateInput.StartDateTime);
            Console.WriteLine("untill date:" + dateInput.UntillDate);
            Console.WriteLine("days of week:" + dateInput.DaysOfWeek);
            Console.WriteLine("End date:" + dateInput.isEndDateDefined);
            Console.WriteLine("Occurance:" + dateInput.Occurance);
            Console.WriteLine("day name:" + dateInput.DayName);
            Console.WriteLine("WeekDay:" + dateInput.WeekDay);
			Console.WriteLine("day format:" + dateInput.DayFormat);
			Console.WriteLine("isWeekDay:" + dateInput.isWeekDay);
			Console.WriteLine("-------------Input-----------------");
			//var output = Helper.DateTimeHelper.FindDateRangeDailyAndWeekly(dateInput.isEndDateDefined, dateInput.StartDateTime, dateInput.EndDateTime, dateInput.Occurance, dateInput.UntillDate, dateInput.frequency, dateInput.DaysOfWeek, 3);
			//var output = Helper.DateTimeHelper.FindDateRange_Monthly(dateInput.isEndDateDefined, dateInput.StartDateTime, dateInput.EndDateTime, dateInput.Occurance, dateInput.UntillDate, dateInput.frequency, dateInput.DaysOfWeek,24,false,dateInput.DayFormat, dateInput.DayName, dateInput.isWeekDay, dateInput.WeekDay);
			var outPut = Helper.DateTimeHelper.FindDateRange_Yearly(true, dateInput.StartDateTime, dateInput.EndDateTime, 5, dateInput.UntillDate, Helper.Frequency.Yearly, "February", 20);

			Console.WriteLine("-------------OutPut-----------------");
            foreach (var item in outPut)
            {
                Console.WriteLine("----"+item.StartDate+"-------"+item.EndDate+"----");
            }
            Console.WriteLine("--------------end-------------------");
            Console.Read();
        }
    }
    public class DateInput
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime UntillDate { get; set; }
        public string DaysOfWeek { get; set; }
        public Helper.Frequency frequency { get; set; }
        public bool isEndDateDefined { get; set; }
        public int Occurance { get; set; }
        public string DayName { get; set; }
        public string DayFormat { get; set; }
        public int WeekDay { get; set; }
        public bool isWeekDay { get; set; }
    }
}
