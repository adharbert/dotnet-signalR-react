using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TimeManagement.Booking;
using Moq;

namespace TimeManagement.UnitTest
{
    public class TimeBookingProcessorUnitTest
    {
        [Fact]
        public void Test_Invalid_EmployeeId()
        {
            var bookingProcessor = new Mock<ITimeBookingProcessor>();
            var timeBookingProcessor = new TimeBookingProcessor(bookingProcessor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => timeBookingProcessor.BookTime(new Data.Employee(), DateTime.Today, 8));
        }

        [Fact]
        public void Test_Invalid_Date()
        {
            var bookingProcessor = new Mock<ITimeBookingProcessor>();
            var timeBookingProcessor = new TimeBookingProcessor(bookingProcessor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => timeBookingProcessor.BookTime(new Data.Employee { Id = 2 }, DateTime.Today.AddDays(1), 8));
        }

        [Fact]
        public void Test_Invalid_Duration()
        {
            var bookingProcessor = new Mock<ITimeBookingProcessor>();
            var timeBookingProcessor = new TimeBookingProcessor(bookingProcessor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => timeBookingProcessor.BookTime(new Data.Employee { Id = 2 }, DateTime.Today.AddDays(-1), 10));
        }


        [Fact]
        public void Test_Valid_Arguments()
        {
            var bookingProcessor = new Mock<ITimeBookingProcessor>();
            var timeBookingProcessor = new TimeBookingProcessor(bookingProcessor.Object);

            Assert.True(timeBookingProcessor.BookTime(new Data.Employee { Id = 2 }, DateTime.Today.AddDays(-1), 8));
        }
    }
}
