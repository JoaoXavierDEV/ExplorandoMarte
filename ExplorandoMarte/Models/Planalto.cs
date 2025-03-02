using System;
using System.Collections.Generic;

namespace ExplorandoMarte.Models
{
    public class Planalto : Terreno
    {
        public List<Rover> Rovers { get; private set; }

        public Planalto(int coordenadaX, int coordenadaY) : base(coordenadaX, coordenadaY)
        {
            Rovers = new List<Rover>();
        }

        public Planalto() : base(100, 200)
        {
            Rovers = new List<Rover>();
        }

        public void AdicionarRovers(List<Rover> rovers)
        {
            rovers.ForEach(rover => AdicionarRover(rover));
        }

        public void AdicionarRover(Rover rover)
        {
            if(Rovers.Exists(x => x.Nome == rover.Nome))
            {
                throw new Exception("Já existe um Rover com este nome.");
            }
            Rovers.Add(rover);
        }

        public void RemoverRover(Rover rover)
        {
            if (Rovers.Exists(x => x == rover))
            {
                Rovers.Remove(rover);
            }
        }

        public bool PosicaoOcupada(int x, int y)
        {
            return Rovers.Any(r => r.PosicaoX == x && r.PosicaoY == y);
        }

        public Rover ObterRoverPorLocalizacao(int x, int y)
        {
            return Rovers.Find(r => r.PosicaoX == x && r.PosicaoY == y);
        }


        public List<string> InformarPosicaoRover()
        {
            return Rovers.Select(rover => rover.GetPosition()).ToList();
        }


        /// <summary>
        /// Obtém as coordenadas superiores do planalto.
        /// </summary>
        /// <returns>Coordenadas no formato "X Y".</returns>
        public string ObterCoordenadasSuperiores()
        {
            return $"{CoordenadaX} {CoordenadaY}";
        }

        /// <summary>
        /// Exibe no console as coordenadas e direções dos rovers.
        /// </summary>
        public void ExibirCoordenadasRovers()
        {
            foreach (var rover in Rovers)
            {
                Console.WriteLine(rover.ToString());
            }
        }

        #region Overrides 
        public override string ToString()
        {
            return this.ObterCoordenadasSuperiores();
        } 
        #endregion
    }
}