using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Interfaces
{
    public interface ILogger
    {
        public void LogMessage(string message);
        public void LogError(string message);
        public void ClearLog();
    }
}
