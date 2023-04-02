using E_Commerce.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class LoggerService : ILoggerService
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public void Error(string message)
        {
            Logger.Error(message);
        }

        public void Info(string message)
        {
            Logger.Error(message);
        }

        public void Trance(string message)
        {
            Logger.Error(message);
        }

        public void Warning(string message)
        {
            Logger.Error(message);
        }
        public void Debug(string message)
        {
            Logger.Debug(message);
        }
    }
}
