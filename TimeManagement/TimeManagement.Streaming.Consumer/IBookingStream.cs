using Confluent.Kafka.Serialization;
using Confluent.Kafka;
using System.Reactive;
using System.Reactive.Linq;
using System;

namespace TimeManagement.Streaming.Consumer
{

    public interface IBookingStream
    {
        //void Publish(BookingMessage bookingMessage);

        //void Subscribe(string subscriberName, Action<BookingMessage> action);
    }
}
