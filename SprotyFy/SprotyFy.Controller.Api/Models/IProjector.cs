using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStore.ClientAPI;

namespace SprotyFy.Controller.Api.Models
{
    public interface IProjector
    {
        void Project(IEnumerable<ResolvedEvent> eves);
    }
}
