using ExplorandoMarte.Controllers;
using ExplorandoMarte.Interfaces;
using ExplorandoMarte.Models;
using System;
using System.Collections.Generic;

namespace MarsRovers
{
    public class Program : Controller
    {
        public Program(ILogger logger) : base(logger)
        {
        }

        public static void Main(string[] args)
        {
            //ILogger logger = Logger.Instance;
            IController controller = null;// Controller.Instance;

            try
            {
                Controller.Instance.LimparLog();

                Controller.Instance.RegistrarLog("Iniciando a exploração de Marte...");



                // Read the plateau's upper right coordinates
                var plateauCoordinates = Console.ReadLine().Split(' ');
                int upperRightX = int.Parse(plateauCoordinates[0]);
                int upperRightY = int.Parse(plateauCoordinates[1]);

                List<Rover> rovers = new List<Rover>();

                var plateau = new Planalto(upperRightX, upperRightY);


                while (true)
                {
                    // Read the initial position and direction of the rover
                    var initialPosition = Console.ReadLine();
                    if (string.IsNullOrEmpty(initialPosition)) break;

                    var positionParts = initialPosition.Split(' ');
                    int x = int.Parse(positionParts[0]);
                    int y = int.Parse(positionParts[1]);
                    char direction = char.Parse(positionParts[2]);

                    var rover = new Rover(x, y, direction);

                    // Read the sequence of instructions
                    var instructions = Console.ReadLine();
                    foreach (var instruction in instructions)
                    {
                        rover.ExecutarInstrucao(instruction);
                    }

                    rovers.Add(rover);
                }

                // Output the final position and direction of each rover
                foreach (var rover in rovers)
                {
                    Console.WriteLine(rover.GetPosition());
                }
            }
            catch (Exception ex)
            {
                controller.RegistrarErro(ex.Message);
                //throw;
            }
            finally
            {
                controller.RegistrarLog("Exploração de Marte finalizada.");
            }
        }
    }
}