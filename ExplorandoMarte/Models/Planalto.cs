using System;
using System.Collections.Generic;

namespace ExplorandoMarte.Models
{
    public class Planalto : Terreno
    {
        public List<Rover> Rovers { get; }

        public Planalto(int coordenadaX, int coordenadaY) : base(coordenadaX, coordenadaY)
        {
            Rovers = new List<Rover>();
        }

        public Planalto() : base(100, 200)
        {
            Rovers = new List<Rover>();
        }

        /// <summary>
        /// Obtém as coordenadas superiores do planalto.
        /// </summary>
        /// <returns>Coordenadas no formato "X Y".</returns>
        public string ObterCoordenadasSuperiores()
        {
            return $"{CoordenadaX} {CoordenadaY}";
        }

        public override string ToString()
        {
            return this.ObterCoordenadasSuperiores();
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
    }
}