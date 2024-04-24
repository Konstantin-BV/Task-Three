using NLog;

namespace Task3.Framework
{
    public static class Logger
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public static void Info(string info)
        {
            logger.Info(info);
        }

        public static void Error(string info)
        {
            logger.Error(info);
        }
    }
}
