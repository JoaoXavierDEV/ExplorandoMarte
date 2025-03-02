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
            try
            {
                Controller.Instance.LimparLog();

                Controller.Instance.RegistrarLog("Iniciando a exploração de Marte...");

                Controller.Instance.RegistrarLog("Informe as Coordenadas do Planalto: ");

                int upperRightX, upperRightY = 0;

                var plateauCoordinates = Console.ReadLine().Split(' ');

                try
                {
                    upperRightX = int.Parse(plateauCoordinates[0]);
                    upperRightY = int.Parse(plateauCoordinates[1]);
                }
                catch (Exception)
                {
                    throw new Exception("Coordenadas Inválidas");
                }


                var planalto = new Planalto(upperRightX, upperRightY);

                Controller.Instance.RegistrarLog("Coordenadas do Planalto: " + planalto.ObterCoordenadasSuperiores());

                List<Rover> rovers = new List<Rover>();

                while (true)
                {
                    Controller.Instance.RegistrarLog("Informe a posição inicial do Rover: ");

                    Console.WriteLine("Exemplo de posição inicial válida: ");
                    Console.WriteLine("1 2 N");
                    Console.WriteLine("X = 1, Y = 2, Direção = Norte");
                    Console.WriteLine("Direções válidas: N, S, E, W");

                    var initialPosition = Console.ReadLine();

                    if (string.IsNullOrEmpty(initialPosition) || string.IsNullOrWhiteSpace(initialPosition))
                    {
                        Controller.Instance.RegistrarErro("Posição Inválida para o Rover.");
                    }

                    var positionParts = initialPosition.Split(' ');


                    int x = int.Parse(positionParts[0]);
                    int y = int.Parse(positionParts[1]);
                    char direction = char.Parse(positionParts[2].ToUpperInvariant());

                    var rover = new Rover(x, y, direction);

                    rover.SetPlanalto(planalto);

                    planalto.AdicionarRover(rover);

                    Controller.Instance.RegistrarLog("Posição Inicial do Rover: " + rover.GetPosition());

                    Controller.Instance.RegistrarLog("Informe a sequência de instruções para o Rover: ");

                    var instructions = Console.ReadLine();

                    Controller.Instance.RegistrarLog("Instruções: " + instructions);

                    foreach (var instruction in instructions)
                    {
                        try
                        {
                            rover.ExecutarInstrucao(instruction);
                            Controller.Instance.RegistrarLog("Instrução executada: " + instruction);
                        }
                        catch (Exception ex)
                        {
                            Controller.Instance.RegistrarErro(ex.Message);
                        }
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
                Controller.Instance.RegistrarErro(ex.Message);
            }
            finally
            {
                Controller.Instance.RegistrarLog("Exploração de Marte finalizada.");
            }
        }
    }
}