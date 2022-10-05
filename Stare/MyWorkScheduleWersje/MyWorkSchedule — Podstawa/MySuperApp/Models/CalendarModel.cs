
namespace MySuperApp.Pages.Calendar
{
    public class CalendarModel
    {
        public string ShiftName { get; set; }
        public string ShiftDate { get; set;  }

        public System.DateTime ShiftStart { get; set; }
        public System.DateTime ShiftEnd { get; set; }

        public double OverHours { get; set; }






        public double ObliczGodzinyPracy()
        {
           
            int hours = (ShiftEnd - ShiftStart).Hours;
            int minutes = (ShiftEnd - ShiftStart).Minutes;

           double workHours = hours + (minutes/60);

           return workHours;
        }



    }
}