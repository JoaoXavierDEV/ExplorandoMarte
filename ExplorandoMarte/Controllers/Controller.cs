using ExplorandoMarte.Interfaces;
using ExplorandoMarte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Controllers
{
    public class Controller : MainController
    {
        private static Controller _instance;

        private static readonly object _lock = new object();

        public Controller(ILogger logger) : base(logger)
        {
        }

        public static Controller Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Controller(logger: Logger.Instance);
                    }
                    return _instance;
                }
            }
        }
    }

}
