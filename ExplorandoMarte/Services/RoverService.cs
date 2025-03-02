using ExplorandoMarte.Interfaces;
using ExplorandoMarte.Models;
using ExplorandoMarte.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorandoMarte.Services
{
    public class RoverService
    {
        public IRepository<Planalto> _planaltoRepository { get; private set; }

        public RoverService()
        {
            _planaltoRepository = new PlanaltoRepository();
        }

        //public bool PosicaoOcupada(Planalto planalto, int x, int y)
        //{
        //    return planalto.Rovers.Exists(rover => rover.PosicaoY == y && rover.PosicaoX == x);
        //}


    }
}
