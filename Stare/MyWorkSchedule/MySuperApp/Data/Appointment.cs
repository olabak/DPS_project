using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySuperApp.Data
{
    public class Appointment
    {
        public Guid UID { get; set; }
        public DateTime START { get; set; }
        public DateTime STOP { get; set; }
        public DateTime DATE_ENTERED { get; set; }
    }
}
