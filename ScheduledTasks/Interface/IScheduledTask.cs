using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduledTasks.Interface
{
    public interface IScheduledTask
    {
        string Schedule { get; }
    }
}
