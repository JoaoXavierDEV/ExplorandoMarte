using ExplorandoMarte.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Controllers
{
    public abstract class MainController : IController
    {
        private readonly ILogger _logger;

        public MainController(ILogger logger)
        {
            _logger = logger;
        }

        public virtual void InicializarLog()
        {
            LimparLog();
        }

        public virtual void RegistrarLog(string mensagem)
        {
            Console.WriteLine(mensagem); _logger.LogMessage(mensagem);
        }

        public virtual void RegistrarErro(string mensagem)
        {
            Console.WriteLine(mensagem); _logger.LogError(mensagem);
        }

        public virtual void LimparLog()
        {
            _logger.ClearLog();
        }
    }
}


