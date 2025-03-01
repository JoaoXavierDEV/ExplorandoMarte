using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Controllers
{
    public abstract class MainController
    {
        public static void RegistrarLog(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}


