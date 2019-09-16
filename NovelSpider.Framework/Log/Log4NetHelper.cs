using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSpider.Framework.Log
{
    public class Log4NetHelper
    {
        static Log4NetHelper()
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ConfigFiles\\log4net.cfg.xml")));
            ILog Log = LogManager.GetLogger(typeof(Log4NetHelper));
            Log.Info("系统初始化Log4NetHelper模块");
        }

        private ILog loger = null;
        public Log4NetHelper(Type type)
        {
            loger = LogManager.GetLogger(type);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public void Error(string msg = "出现异常", Exception ex = null)
        {
            loger.Error(msg, ex);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        public void Warn(string msg)
        {
            loger.Warn(msg);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        public void Info(string msg)
        {
            loger.Info(msg);
        }

        /// <summary>
        /// Log4日志
        /// </summary>
        /// <param name="msg"></param>
        public void Debug(string msg)
        {
            loger.Debug(msg);
        }
    }
}
