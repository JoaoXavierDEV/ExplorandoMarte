namespace ExplorandoMarte.Models
{
    public abstract class Terreno
    {
        public int CoordenadaX { get; }
        public int CoordenadaY { get; }

        protected Terreno(int coordenadaX, int coordenadaY)
        {
            CoordenadaX = coordenadaX;
            CoordenadaY = coordenadaY;
        }

        /// <summary>
        /// Obtém as coordenadas superiores do planalto.
        /// </summary>
        /// <returns>Coordenadas no formato "X Y".</returns>
        public string ObterTamanhoDoTerreno()
        {
            return $"{CoordenadaX} {CoordenadaY}";
        }
    }
}