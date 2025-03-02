using ExplorandoMarte.Interfaces;
using ExplorandoMarte.Models;
using ExplorandoMarte.Repository;
using ExplorandoMarte.Services;

namespace ExplorandoMarte.Controllers
{
    public class Controller : MainController
    {
        private static Controller _instance;

        public RoverService RoverService { get; private set; }

        private static readonly object _lock = new object();

        public Controller(ILogger logger) : base(logger)
        {
            RoverService = new RoverService();
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

        public bool PosicaoOcupada(Planalto planalto, int x, int y)
        {
            return planalto.PosicaoOcupada(x, y);
        }
    }

}
