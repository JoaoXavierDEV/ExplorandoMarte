using ExplorandoMarte.Interfaces;
using ExplorandoMarte.Models;
using ExplorandoMarte.Repository;
using ExplorandoMarte.Services;

namespace ExplorandoMarte.Controllers
{
    public class Controller : MainController
    {
        public RoverService RoverService { get; private set; }

        private static readonly object _lock = new object();

        public Controller(ILogger logger) : base(logger)
        {
            RoverService = new RoverService();
        }

        public bool PosicaoOcupada(Planalto planalto, int x, int y)
        {
            return planalto.PosicaoOcupada(x, y);
        }
    }

}
