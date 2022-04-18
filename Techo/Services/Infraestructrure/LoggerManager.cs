using log4net;
using log4net.Config;
using Techo.Contracts;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Techo.Services.Infraestructrure
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(LoggerManager));

        public LoggerManager()
        {
            try
            {
                XmlDocument log4netConfig = new XmlDocument();

                using (var fs = File.OpenRead("log4net.config"))
                {
                    log4netConfig.Load(fs);

                    var repo = LogManager.CreateRepository(
                            Assembly.GetEntryAssembly(),
                            typeof(log4net.Repository.Hierarchy.Hierarchy));
                    string ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    GlobalContext.Properties["FilePath"] = ruta.Substring(6, ruta.Length - 6);
                    XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error", ex);
            }
        }

        public void LogDebug(string msg)
        {
            _logger.Debug(msg);
        }

        public void LogError(string msg)
        {
            _logger.Error(msg);
        }

        public void LogError(string msg, Exception ex)
        {
            _logger.Error(msg, ex);
        }

        public void LogInfo(string msg)
        {
            _logger.Info(msg);
        }

        public void LogWarn(string msg)
        {
            _logger.Warn(msg);
        }
    }
}