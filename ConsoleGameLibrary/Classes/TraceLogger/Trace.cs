using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameLibrary.Classes.TraceLogger
{
    public static class Trace
    {
        public static TraceSource ts;

        static Trace()
        {
            ts = new TraceSource("Logger");

            // setting the overall switch
            ts.Switch = new SourceSwitch("Log", "All");

            TraceListener fileLog = new TextWriterTraceListener(new StreamWriter("LogFile.txt"));
            ts.Listeners.Add(fileLog);

        }
    }
}
