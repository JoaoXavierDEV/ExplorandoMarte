using System.Diagnostics;

namespace ExplorandoMarte.Models
{
    [DebuggerDisplay("Rover {Nome} - Posição: ({PosicaoX}, {PosicaoY}) - Direção: {Direction}")]
    public class Rover : EntityBase
    {
        #region Propriedades
        public string Nome { get; private set; }
        public int PosicaoX { get; private set; }
        public int PosicaoY { get; private set; }

        public Planalto Planalto { get; private set; }

        public char Direction;

        private static readonly List<char> directions = new List<char> { 'N', 'E', 'S', 'W' }; 
        #endregion

        public Rover(int x, int y, char direction)
        {
            ValidateCoordinates(x, y);
            ValidateDirection(direction);

            this.Nome = Guid.NewGuid().ToString().Substring(0,6).ToUpperInvariant();
            this.PosicaoX = x;
            this.PosicaoY = y;
            this.Direction = direction;
        }

        #region Validações
        private void ValidateCoordinates(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("As coordenadas não podem ser negativas.");
            }
        }

        private void ValidateDirection(char direction)
        {
            if (!directions.Contains(direction))
            {
                throw new ArgumentException("Direção inválida. As direções válidas são: N, E, S, W.");
            }
        }
        private void ValidateInstruction(char instruction)
        {
            if (instruction != 'L' && instruction != 'R' && instruction != 'M')
            {
                throw new ArgumentException("Instrução inválida. As instruções válidas são: L, R, M.");
            }

            if (instruction == 'M')
            {
                int newX = PosicaoX;
                int newY = PosicaoY;

                switch (Direction)
                {
                    case 'N':
                        newY += 1;
                        break;
                    case 'E':
                        newX += 1;
                        break;
                    case 'S':
                        newY -= 1;
                        break;
                    case 'W':
                        newX -= 1;
                        break;
                }

                if (newX < 0 || newX > Planalto.CoordenadaX || newY < 0 || newY > Planalto.CoordenadaY)
                {
                    throw new ArgumentException("O Rover está no limite do planalto, instrução não executada.");
                }

                if (Planalto.PosicaoOcupada(newX, newY))
                {
                    throw new InvalidOperationException("Movimento inválido: posição já ocupada por outra sonda.");
                }
            }
        }
        #endregion

        public void ExecutarInstrucao(char instruction)
        {
            ValidateInstruction(instruction);
            switch (instruction)
            {
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'M':
                    MoveForward();
                    break;
                default:
                    throw new ArgumentException("Instrução inválida. As instruções válidas são: L, R, M.");
            }
        }

        /// <summary>
        /// Gira o Rover para a esquerda.
        /// </summary>
        public void TurnLeft()
        {
            int currentIndex = directions.IndexOf(Direction);
            int newIndex = (currentIndex - 1 + directions.Count) % directions.Count;
            Direction = directions[newIndex];
        }

        /// <summary>
        /// Gira o Rover para a direita.
        /// </summary>
        public void TurnRight()
        {
            int currentIndex = directions.IndexOf(Direction);
            int newIndex = (currentIndex + 1) % directions.Count;
            Direction = directions[newIndex];
        }

        /// <summary>
        /// Move o Rover para frente.
        /// </summary>
        public void MoveForward()
        {
            ValidateInstruction('M');

            switch (Direction)
            {
                case 'N':
                    PosicaoY += 1;
                    break;
                case 'E':
                    PosicaoX += 1;
                    break;
                case 'S':
                    PosicaoY -= 1;
                    break;
                case 'W':
                    PosicaoX -= 1;
                    break;
            }
        }

        public string GetPosition()
        {
            return $" Nome: {Nome} | X: {PosicaoX} | Y: {PosicaoY} | DIREÇÃO: {Direction} ";
        }

        public override string ToString()
        {
            return this.GetPosition();
        }

        public void SetPlanalto(Planalto planalto)
        {
            Planalto = planalto;
        }

        public bool PosicaoOcupada(int x, int y)
        {
            return Planalto.Rovers.Exists(rover => rover.PosicaoY == y && rover.PosicaoX == x);
        }
    }
}