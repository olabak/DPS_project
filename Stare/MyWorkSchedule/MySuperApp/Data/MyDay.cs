using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySuperApp.Data
{
    public class MyDay
    {
        public DateTime AptDay { get; set; }
        public bool IsOccupied { get; set; }

        public string GetNumber()
        {
            string ret = string.Empty;

            if (AptDay == null || AptDay == DateTime.MinValue)
                ret = string.Empty;
            else
                ret = AptDay.Day.ToString();

            return ret;
        }
    }
}
