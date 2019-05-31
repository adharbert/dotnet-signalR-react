using System;
using System.Collections.Generic;
using System.Text;
using TimeManagement.Data;

namespace TimeManagement.Booking
{
    public interface ITimeBookingProcessor
    {
        bool BookTime(Employee employee, DateTime date, decimal duration);
    }
}
