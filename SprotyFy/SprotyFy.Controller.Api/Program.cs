using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SprotyFy.Controller.Api.Models;

namespace SprotyFy.Controller.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(() =>
            {//consider usning projections of eventstore and only use the playlist stream
               new EventConsumer()
                .Start("PlayList_624dfc95-1fb8-482e-819f-dd51972ed1f7", new PlayListProjector());
            });
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
