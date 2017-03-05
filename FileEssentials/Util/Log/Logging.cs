using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEssentials.Util.Log
{
    public static class Logging
    {
        public delegate void LogEventCallback(LogEventData logevent);
        public static event LogEventCallback LogEvent;

        private static object _lockLogging = new object();
        private static DirectoryInfo pathToLog = null;
        public static int _maxlogLevel { get; set; }
        public static LoggingCache Cache { get; private set; }

        public static void Log(string message, string source, LoggingType type, int level)
        {
            Log(message, source, type, level, false);
        }

        public static void Log(string message, object source, LoggingType type, int level)
        {
            string _source = source.GetType().ToString();
            Log(message, _source, type, level, false);
        }

        public static void Log(string message, object source, int instance, LoggingType type, int level)
        {
            string _source = source.GetType().ToString() + "_" + instance;
            Log(message, _source, type, level, false);
        }

        public static void Log(string message, string source, LoggingType type, int level, bool FileOnly)
        {
            //Update Paths to logfile
            FileInfo fileLOG = null;
            FileInfo fileSource = null;
            FileInfo fileCritical = null;

            DateTime now = DateTime.Now;

            lock (_lockLogging)
            {
                try
                {
                    LogEventData logevent = new LogEventData { Source = source, Message = message, Time = now, Type = type, Level = level };


                    if (level <= _maxlogLevel && pathToLog != null)
                    {
                        DirectoryInfo tempPath = new DirectoryInfo(pathToLog.FullName + "\\" + String.Format("{0:00}", DateTime.Now.Year) + String.Format("{0:00}", DateTime.Now.Month) + String.Format("{0:00}", DateTime.Now.Day) + "\\");
                        if (!tempPath.Exists)
                        {
                            Directory.CreateDirectory(tempPath.FullName);
                        }
                    
                        fileLOG = new FileInfo(tempPath.FullName + "!LOG!.txt");
                        fileSource = new FileInfo(tempPath.FullName + source + ".txt");
                        fileCritical = new FileInfo(tempPath.FullName + "!!!   CRITICAL  !!!.txt");
                    }

                    if (fileLOG != null)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileLOG.FullName, true))
                        {
                            switch (type)
                            {
                                case LoggingType.Error: file.WriteLine(FormatDate(DateTime.Now) + ": ERROR: " + source + " [" + level + "]: " + message); break;
                                case LoggingType.Status: file.WriteLine(FormatDate(DateTime.Now) + ": " + source + " [" + level + "]: " + message); break;
                                case LoggingType.Critical: file.WriteLine(FormatDate(DateTime.Now) + ": CRITICAL: " + source + " [" + level + "]: " + message); break;
                            }
                        }
                    }

                    if (fileSource != null)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileSource.FullName, true))
                        {
                            switch (type)
                            {
                                case LoggingType.Error: file.WriteLine(FormatDate(DateTime.Now) + ": ERROR: " + source + " [" + level + "]: " + message); break;
                                case LoggingType.Status: file.WriteLine(FormatDate(DateTime.Now) + ": " + source + " [" + level + "]: " + message); break;
                                case LoggingType.Critical: file.WriteLine(FormatDate(DateTime.Now) + ": CRITICAL: " + source + " [" + level + "]: " + message); break;
                            }
                        }
                    }

                    if (fileCritical != null)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileCritical.FullName, true))
                        {
                            if (type == LoggingType.Critical)
                                file.WriteLine(FormatDate(DateTime.Now) + ": CRITICAL: " + source + " [" + level + "]: " + message);
                        }
                    }

                    //Write to console
                    if (level <= _maxlogLevel)
                        Console.WriteLine(now.ToString() + ":\t" + source + "\t" + message);


                    //Fire log event
                    if (LogEvent != null)
                        LogEvent(logevent);
                }
                catch (Exception ex) { Console.WriteLine("Error while logging to file! " + ex.Message); }
            }
        }

        public static void InitLogger(string path, int maxLogLevel)
        {
            pathToLog = new DirectoryInfo(path);
            _maxlogLevel = maxLogLevel;
            Cache = new LoggingCache(500);
            Logging.LogEvent += Cache.LogEventHandler;
        }

        private static string FormatDate(DateTime date)
        {
            return String.Format("{0:00}", date.Hour) + ":" + String.Format("{0:00}", date.Minute) + ":" + String.Format("{0:00}", date.Second);
        }
    }
}
