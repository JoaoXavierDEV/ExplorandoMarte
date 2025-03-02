using System.Diagnostics;

namespace ExplorandoMarte.Models
{
    public class Rover
    {
        #region Propriedades
        public string Nome { get; private set; }
        private int x;
        private int y;

        public Planalto Planalto { get; private set; }

        private char direction;

        private static readonly List<char> directions = new List<char> { 'N', 'E', 'S', 'W' }; 
        #endregion

        public Rover(int x, int y, char direction)
        {
            ValidateCoordinates(x, y);
            ValidateDirection(direction);

            this.Nome = Guid.NewGuid().ToString();
            this.x = x;
            this.y = y;
            this.direction = direction;
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
                int newX = x;
                int newY = y;

                switch (direction)
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
        private void TurnLeft()
        {
            int currentIndex = directions.IndexOf(direction);
            int newIndex = (currentIndex - 1 + directions.Count) % directions.Count;
            direction = directions[newIndex];
        }

        /// <summary>
        /// Gira o Rover para a direita.
        /// </summary>
        private void TurnRight()
        {
            int currentIndex = directions.IndexOf(direction);
            int newIndex = (currentIndex + 1) % directions.Count;
            direction = directions[newIndex];
        }

        /// <summary>
        /// Move o Rover para frente.
        /// </summary>
        private void MoveForward()
        {
            switch (direction)
            {
                case 'N':
                    y += 1;
                    break;
                case 'E':
                    x += 1;
                    break;
                case 'S':
                    y -= 1;
                    break;
                case 'W':
                    x -= 1;
                    break;
            }
        }

        public string GetPosition()
        {
            return $" X:{x} | Y:{y} | DIREÇÃO:{direction} ";
        }

        public override string ToString()
        {
            return this.GetPosition();
        }

        public void SetPlanalto(Planalto planalto)
        {
            Planalto = planalto;
        }
    }
}