using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp
{
    public class LogItem
    {
        public string Instance { get; set; }
        public DateTime LastAliveTime { get; set; }
        public string State { get; set; }

        public LogItem(string itemName)
        {
            Instance = itemName;
            LastAliveTime = DateTime.Now;
            State = "Active";
        }
    }

    public class Logger
    {
        public List<LogItem> Log { get; private set; }

        public Logger()
        {
            Log = new List<LogItem>();
        }

        public void SetAlive(string instanceName)
        {
            LogItem li = Log.FirstOrDefault(l => l.Instance.Equals(instanceName, StringComparison.InvariantCultureIgnoreCase));
            if (li != null)
            {
                li.LastAliveTime = DateTime.Now;
                return;
            }

            Log.Add(new LogItem(instanceName));
        }

        public void SetDisposed(string instanceName)
        {
            LogItem li = Log.FirstOrDefault(l => l.Instance.Equals(instanceName, StringComparison.InvariantCultureIgnoreCase));
            if (li != null)
            {
                li.LastAliveTime = DateTime.Now;
                li.State = "Disposed";
                return;
            }
        }
    }
}
