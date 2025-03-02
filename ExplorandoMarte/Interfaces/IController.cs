using ExplorandoMarte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Interfaces
{
    public interface IController
    {
        public void RegistrarLog(string mensagem);

        public void RegistrarErro(string mensagem);

        public void LimparLog();
    }
}
