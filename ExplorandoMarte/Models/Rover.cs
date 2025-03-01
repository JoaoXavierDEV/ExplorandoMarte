namespace ExplorandoMarte.Models
{
    public class Rover
    {
        public string Nome { get; private set; }
        private int x;
        private int y;
        private char direction;

        private static readonly List<char> directions = new List<char> { 'N', 'E', 'S', 'W' };

        public Rover(int x, int y, char direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
        }

        public void ExecutarInstrucao(char instruction)
        {
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
            }
        }

        private void TurnLeft()
        {
            int currentIndex = directions.IndexOf(direction);
            int newIndex = (currentIndex - 1 + directions.Count) % directions.Count;
            direction = directions[newIndex];
        }

        private void TurnRight()
        {
            int currentIndex = directions.IndexOf(direction);
            int newIndex = (currentIndex + 1) % directions.Count;
            direction = directions[newIndex];
        }

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
            return $"{x} {y} {direction}";
        }

        public override string ToString()
        {
            return this.GetPosition();
        }
    }
}