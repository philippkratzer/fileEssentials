using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEssentials.Util.Log
{
    /// <summary>
    /// This class caches a given number of LoggingEvents, for example to replay them in the GUI
    /// </summary>
    public class LoggingCache
    {
        private int _size;

        private List<LogEventData> _list;

        public LoggingCache(int size)
        {
            _size = size;
            _list = new List<LogEventData>();
        }

        internal void LogEventHandler(LogEventData logevent)
        {
            lock (_list)
            {
                if (_list.Count > _size)
                    _list.RemoveAt(0);

                _list.Add(logevent);
            }
        }

        public List<LogEventData> ReadCache()
        {
            return new List<LogEventData>(_list);
        }
    }
}
