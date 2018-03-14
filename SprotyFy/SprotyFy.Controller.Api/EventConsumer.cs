using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using SprotyFy.Controller.Api.Models;

namespace SprotyFy.Controller.Api
{
    public class EventConsumer
    {
        private IEventStoreConnection _connection;

        public EventConsumer()
        {
            _connection =
                EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
        }

        public async void Start(string streamName, IProjector projector)
        {
            await _connection.ConnectAsync();
            long pos = 0;
            while (true)
            {
                var slise = await _connection.ReadStreamEventsForwardAsync(streamName, pos, 5, true);
                if (pos < slise.NextEventNumber)
                {
                    pos = slise.NextEventNumber;

                    projector.Project(slise.Events);

                }
                else
                {
                    await Task.Delay(100);
                }
            }
        }
    }
}
