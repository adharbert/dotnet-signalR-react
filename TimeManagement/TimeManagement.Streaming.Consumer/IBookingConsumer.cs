using System;
namespace TimeManagement.Streaming.Consumer
{
    public interface IBookingConsumer
    {
        void Listen(Action<string> message);
    }
}
