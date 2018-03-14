using System;
using System.Net;
using System.Text;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using SprotyFy.Controller.Api.Events;

namespace SprotyFy.Controller.Api
{
    public class EventPublisher
    {
        private readonly IEventStoreConnection _connection;

        public EventPublisher()
        {
            _connection =
                EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
        }
        public async void Publish(IEvent eve)
        {
            await _connection.ConnectAsync();


            var myEvent = new EventData(Guid.NewGuid(),eve.EventName(),true,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eve)),
                null);
            await _connection.AppendToStreamAsync(eve.Stream(), ExpectedVersion.Any, myEvent);

            _connection.Dispose();
        }
    }
}
