using ExplorandoMarte.Models;
using Xunit;

namespace ExplorandoMarte.Tests
{
    public class RoverTests
    {
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

        [Fact]
        public void Rover_MoveForward_ThrowsException_WhenMovingBeyondNorthBoundary()
        {
            // Arrange
            var planalto = new Planalto(5, 5);
            var rover = new Rover(0, 5, 'N');
            rover.SetPlanalto(planalto);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => rover.MoveForward());
            Assert.Equal("O Rover está no limite do planalto, instrução não executada.", exception.Message);
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
            Assert.Equal("O Rover está no limite do planalto, instrução não executada.", exception.Message);
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
            Assert.Equal("O Rover está no limite do planalto, instrução não executada.", exception.Message);
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
            Assert.Equal("O Rover está no limite do planalto, instrução não executada.", exception.Message);
        }
    }
}