using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using SprotyFy.Controller.Api.Models;

namespace SprotyFy.Controller.Api
{
    public delegate IProjector ProjectorFactory();
    public class EventConsumer
    {
        private IEventStoreConnection _connection;

        public EventConsumer()
        {
            _connection =
                EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));

            _connection.ConnectAsync().Wait();

        }

        public async void Start(string streamName, ProjectorFactory projectorFactory, bool ignoreLinks = false)
        {
            var projector = projectorFactory();

            long pos = 0;
            while (true)
            {
                var slise = await _connection.ReadStreamEventsForwardAsync(streamName, pos, 5, true);
                if (pos < slise.NextEventNumber)
                {
                    pos = slise.NextEventNumber;

                    if(!ignoreLinks)
                        //create a stream for all the linked streames
                        foreach (var e in slise.Events
                            .Where(e => e.Link?.EventType == "$>"))
                        {
                            Start(e.Event.EventStreamId, projectorFactory);
                        }

                    var nonlinks = slise.Events
                        .Where(e => e.Link == null || ignoreLinks)
                        .ToList();

                    projector.Project(nonlinks);

                }
                else
                {
                    await Task.Delay(100);
                }
            }
        }
    }
}
