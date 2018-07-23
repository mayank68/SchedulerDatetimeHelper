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
                EndDateTime = DateTime.Now.AddHours(3).AddMinutes(30),
                UntillDate = DateTime.Now.AddDays(230),
                DaysOfWeek = "MO,TU,WE",
                isEndDateDefined = true,
                frequency=Helper.Frequency.Monthly,
                Occurance=5,
                DayName= "Sunday",
                DayFormat= "fourth",
                WeekDay=2,
                isWeekDay=false


            };
            Console.WriteLine("-------------Input-----------------");
            Console.WriteLine("start time:"+ dateInput.StartDateTime);
            Console.WriteLine("end time:" + dateInput.StartDateTime);
            Console.WriteLine("untill date:" + dateInput.UntillDate);
            Console.WriteLine("days of week:" + dateInput.DaysOfWeek);
            Console.WriteLine("End date:" + dateInput.isEndDateDefined);
            Console.WriteLine("Occurance:" + dateInput.Occurance);
            Console.WriteLine("day name:" + dateInput.DayName);
            Console.WriteLine("day format:" + dateInput.DayFormat);
            Console.WriteLine("-------------Input-----------------");
            //var output = Helper.DateTimeHelper.FindDateRangeDailyAndWeekly(dateInput.isEndDateDefined, dateInput.StartDateTime, dateInput.EndDateTime, dateInput.Occurance, dateInput.UntillDate, dateInput.frequency, dateInput.DaysOfWeek, 3);
            var output = Helper.DateTimeHelper.FindDateRange_Monthly(dateInput.isEndDateDefined, dateInput.StartDateTime, dateInput.EndDateTime, dateInput.Occurance, dateInput.UntillDate, dateInput.frequency, dateInput.DaysOfWeek,24,false,dateInput.DayFormat, dateInput.DayName, dateInput.isWeekDay, dateInput.WeekDay);
            Console.WriteLine("-------------OutPut-----------------");
            foreach (var item in output)
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
