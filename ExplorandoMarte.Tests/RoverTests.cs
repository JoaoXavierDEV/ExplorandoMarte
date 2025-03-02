using ExplorandoMarte.Models;
using Xunit;

namespace ExplorandoMarte.Tests
{
    public class RoverTests
    {
        #region Movimenta��o b�sica e mudan�a de dire��o. 

        [Fact]
        public void Rover_TurnLeft_ChangesDirectionCorrectly()
        {
            // Arrange
            var rover = new Rover(0, 0, 'N');

            // Act
            rover.TurnLeft();

            // Assert
            Assert.Equal('W', rover.Direction);
        }

        [Fact]
        public void Rover_TurnRight_ChangesDirectionCorrectly()
        {
            // Arrange
            var rover = new Rover(0, 0, 'N');

            // Act
            rover.TurnRight();

            // Assert
            Assert.Equal('E', rover.Direction);
        }

        [Fact]
        public void Rover_MoveForward_ChangesPositionCorrectly()
        {
            // Arrange
            var rover = new Rover(0, 0, 'N');
            var planalto = new Planalto(5, 5);
            rover.SetPlanalto(planalto);


            // Act
            rover.MoveForward();

            // Assert
            Assert.Equal(0, rover.PosicaoX);
            Assert.Equal(1, rover.PosicaoY);
        }

        [Fact]
        public void Rover_MoveForward_ChangesPositionCorrectly_WhenFacingEast()
        {
            // Arrange
            var rover = new Rover(0, 0, 'E');
            var planalto = new Planalto(5, 5);
            rover.SetPlanalto(planalto);


            // Act
            rover.MoveForward();

            // Assert
            Assert.Equal(1, rover.PosicaoX);
            Assert.Equal(0, rover.PosicaoY);
        }

        [Fact]
        public void Rover_MoveForward_ChangesPositionCorrectly_WhenFacingSouth()
        {
            // Arrange
            var rover = new Rover(0, 1, 'S');
            var planalto = new Planalto(5, 5);
            rover.SetPlanalto(planalto);

            // Act
            rover.MoveForward();

            // Assert
            Assert.Equal(0, rover.PosicaoX);
            Assert.Equal(0, rover.PosicaoY);
        }

        [Fact]
        public void Rover_MoveForward_ChangesPositionCorrectly_WhenFacingWest()
        {
            // Arrange
            var rover = new Rover(1, 0, 'W');
            var planalto = new Planalto(5, 5);
            rover.SetPlanalto(planalto);


            // Act
            rover.MoveForward();

            // Assert
            Assert.Equal(0, rover.PosicaoX);
            Assert.Equal(0, rover.PosicaoY);
        }

        #endregion

        #region Limites do Planalto

        [Fact]
        public void Rover_MoveForward_ThrowsException_WhenMovingBeyondNorthBoundary()
        {
            // Arrange
            var planalto = new Planalto(5, 5);
            var rover = new Rover(0, 5, 'N');
            rover.SetPlanalto(planalto);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => rover.MoveForward());
            Assert.Equal("O Rover est� no limite do planalto, instru��o n�o executada.", exception.Message);
        }

        [Fact]
        public void Rover_MoveForward_ThrowsException_WhenMovingBeyondEastBoundary()
        {
            // Arrange
            var planalto = new Planalto(5, 5);
            var rover = new Rover(5, 0, 'E');
            rover.SetPlanalto(planalto);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => rover.MoveForward());
            Assert.Equal("O Rover est� no limite do planalto, instru��o n�o executada.", exception.Message);
        }

        [Fact]
        public void Rover_MoveForward_ThrowsException_WhenMovingBeyondSouthBoundary()
        {
            // Arrange
            var planalto = new Planalto(5, 5);
            var rover = new Rover(0, 0, 'S');
            rover.SetPlanalto(planalto);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => rover.MoveForward());
            Assert.Equal("O Rover est� no limite do planalto, instru��o n�o executada.", exception.Message);
        }

        [Fact]
        public void Rover_MoveForward_ThrowsException_WhenMovingBeyondWestBoundary()
        {
            // Arrange
            var planalto = new Planalto(5, 5);
            var rover = new Rover(0, 0, 'W');
            rover.SetPlanalto(planalto);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => rover.MoveForward());
            Assert.Equal("O Rover est� no limite do planalto, instru��o n�o executada.", exception.Message);
        }
        #endregion

        #region Conflito de Posi��o
        [Fact]
        public void Rover_MoveForward_ThrowsException_WhenMovingToOccupiedPosition()
        {
            // Arrange
            var planalto = new Planalto(5, 5);
            var rover1 = new Rover(1, 1, 'N');
            var rover2 = new Rover(1, 2, 'S');
            rover1.SetPlanalto(planalto);
            rover2.SetPlanalto(planalto);
            planalto.AdicionarRover(rover1);
            planalto.AdicionarRover(rover2);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => rover1.MoveForward());
            Assert.Equal("Movimento inv�lido: posi��o j� ocupada por outra sonda.", exception.Message);
        }
        #endregion

        #region Instru��es inv�lidas


        [Fact]
        public void Rover_ThrowsException_WhenCreatedWithInvalidCoordinates()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Rover(-1, 0, 'N'));
            Assert.Equal("As coordenadas n�o podem ser negativas.", exception.Message);
        }

        [Fact]
        public void Rover_ThrowsException_WhenCreatedWithInvalidDirection()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Rover(0, 0, 'A'));
            Assert.Equal("Dire��o inv�lida. As dire��es v�lidas s�o: N, E, S, W.", exception.Message);
        }

        [Fact]
        public void Rover_ThrowsException_WhenExecutingInvalidInstruction()
        {
            // Arrange
            var rover = new Rover(0, 0, 'N');
            var planalto = new Planalto(5, 5);
            rover.SetPlanalto(planalto);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => rover.ExecutarInstrucao('X'));
            Assert.Equal("Instru��o inv�lida. As instru��es v�lidas s�o: L, R, M.", exception.Message);
        }

        #endregion
    }
}