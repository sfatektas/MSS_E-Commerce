using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces
{
    public interface ILoggerService
    {
        void Warning(string message);

        void Error(string message);
        void Info(string message);
        void Trace(string message);
        void Debug(string message);

    }
}
