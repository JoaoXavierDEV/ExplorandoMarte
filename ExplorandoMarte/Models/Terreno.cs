namespace ExplorandoMarte.Models
{
    public abstract class Terreno
    {
        public string Nome { get; private set; }
        public const int CoordenadaMinimaX = 0;
        public const int CoordenadaMinimaY = 0;

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
            return $"X: {CoordenadaX} Y: {CoordenadaY}";
        }
    }
}