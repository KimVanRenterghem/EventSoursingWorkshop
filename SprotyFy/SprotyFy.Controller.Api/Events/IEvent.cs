using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SprotyFy.Controller.Api.Events
{
    public interface IEvent
    {
        string Stream();
        string EventName();
    }
}
