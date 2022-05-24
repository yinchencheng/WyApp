using System;
using System.IO;
using System.Reflection;
using static WY_App.Utility.Parameter;

namespace WY_App.Utility
{
    /// <summary>
    /// Fatal级别的日志由系统全局抓取
    /// </summary>
    public class LogHelper
    {       
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("loginfo");

        public static void Debug(object messsage)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Debug)
            {
                log.Debug(messsage);
            }
        }

        public static void DebugFormatted(string format, params object[] args)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Debug)
            {
                log.DebugFormat(format, args);
            }
        }

        public static void Info(object message)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Info)
            {
                log.Info(message);
            }
        }

        public static void InfoFormatted(string format, params object[] args)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Info)
            {
                log.InfoFormat(format, args);
            }
        }

        public static void Warn(object message)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Warn)
            {
                log.Warn(message);
            }
        }

        public static void WarnFormatted(string format, params object[] args)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Warn)
            {
                log.WarnFormat(format, args);
            }
        }

        public static void Error(object message)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Error)
            {
                log.Error(message);
            }
        }

        public static void Error(object message, Exception exception)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Error)
            {
                log.Error(message, exception);
            }
        }

        public static void ErrorFormatted(string format, params object[] args)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Error)
            {
                log.ErrorFormat(format, args);
            }
        }

        public static void Fatal(object message)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Fatal)
            {
                log.Fatal(message);
            }
        }

        public static void Fatal(object message, Exception exception)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Fatal)
            {
                log.Fatal(message, exception);
            }
        }

        public static void FatalFormatted(string format, params object[] args)
        {
            if ((int)Parameter.commministion.LogLevel <= (int)LogLevelEnum.Fatal)
            {
                log.FatalFormat(format, args);
            }
        }
    }
}