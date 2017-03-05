using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEssentials.Util.Log
{
    public class LogEventData
    {
        public string Source { get; internal set; }
        public string Message { get; internal set; }
        public DateTime Time { get; internal set; }
        public LoggingType Type { get; internal set; }
        public int Level { get; internal set; }
    }
}
