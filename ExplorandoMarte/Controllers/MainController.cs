using ExplorandoMarte.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Controllers
{
    public abstract class MainController
    {
        private readonly ILogger _logger;

        public MainController(ILogger logger)
        {
            _logger = logger;
        }

        public static void RegistrarLog(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}


