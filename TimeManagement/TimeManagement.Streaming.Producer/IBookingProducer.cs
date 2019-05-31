namespace TimeManagement.Streaming.Producer
{
    public interface IBookingProducer
    {
        void Produce(string message);
    }
}
