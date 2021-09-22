using System;

namespace DetailResearchOfLinq
{
    public static class LogUtility
    {
        public const int ALL = 0;

        public const int EXCLUDE_DETAIL = 1;

        public static int LogLevel = ALL;
        
        public static void Log(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void LogDetail(string msg)
        {
            if (LogLevel > ALL)
            {
                return;
            }
            Console.WriteLine(msg);
        }
    }
}