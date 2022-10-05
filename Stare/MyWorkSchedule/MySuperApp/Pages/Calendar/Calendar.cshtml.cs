using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySuperApp.Data;

namespace MySuperApp.Pages.Calendar
{
    public class AddCalendarModel : PageModel
    {

        [BindProperty]
        public string CurrentMonth { get; set; }

        public List<string> DayNames { get; set; }

        public DateTime Current { get; set; }

        public MyDay[,] DayCollection { get; set; }
        
        public void OnGet(DateTime tempDate)
        {
            DayNames = new List<string>();
            DayNames.Add("Sun");
            DayNames.Add("Mon");
            DayNames.Add("Tues");
            DayNames.Add("Wed");
            DayNames.Add("Thur");
            DayNames.Add("Fri");
            DayNames.Add("Sat");

            // fresh to the page or from a previous page.
            if (tempDate == null || tempDate == DateTime.MinValue)
                Current = DateTime.Now;// new DateTime(2018, 12, 05);
            else
                Current = tempDate;

            //Setting all the particulars.
            CurrentMonth = Current.ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture);
            int startingDay = (int)new DateTime(Current.Year, Current.Month, 1).DayOfWeek;// so it lines up right.
            int daysInMonth = DateTime.DaysInMonth(Current.Year, Current.Month); // helps stop creating the grid.

            //testing out blocking out things.
            DataAccess _data = new DataAccess();
            //Appointment appt = _data.GetAppointmentAsync().Result;
            List<Appointment> allAppts = _data.GetAppointmentsAsync().Result;


            InitGrid(Current.Year, Current.Month, daysInMonth, startingDay);

            //SetAppointment(current.Year, current.Month, appt);
            SetAppointments(Current.Year, Current.Month, allAppts);
        }
        //Next/previous month are clicked.  This changes the 'current' and must be redrawn.
        public IActionResult OnPostNextMonth(int direction, DateTime curr)
        {
            if (direction == 0)
            {
                curr = curr.AddMonths(-1);
            }
            else
            {
                curr = curr.AddMonths(1);
            }

            return RedirectToAction(" / Index", new { tempDate = curr });
        }

        //Set up the grid
        private void InitGrid(int year, int month, int daysInMonth, int startingDay)
        {
            int lCurrentDay = 0; // Makes sure the arrays do not have more than expected number of days dealt with
            bool end = false;

            DayCollection = new MyDay[6, 7];

            for (int i = 0; i < 6 && !end; i++)
            {
                for (int z = 0; z < 7; z++)
                {
                    if (lCurrentDay > 0 || z == startingDay)
                    {
                        lCurrentDay += 1;
                        if (lCurrentDay > daysInMonth)
                        {
                            end = true;
                            break;
                        }
                        DayCollection[i, z] = new MyDay()
                        {
                            AptDay = new DateTime(year, month, lCurrentDay),
                            IsOccupied = false
                        };
                    }
                }
            }
        }

        //Comapre the array days with the appointment days.
        private void SetAppointment(int year, int month, Appointment temp)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int z = 0; z < 7; z++)
                {
                    if (DayCollection[i, z] != null && (DayCollection[i, z].AptDay >= temp.START && DayCollection[i, z].AptDay <= temp.STOP))
                    {
                        DayCollection[i, z].IsOccupied = true;
                    }
                }
            }
        }
        private void SetAppointments(int year, int month, List<Appointment> temp)
        {
            foreach (Appointment item in temp)
            {
                SetAppointment(year, month, item);
            }
        }
        public void OnPost()
        {

        }
    }
}
