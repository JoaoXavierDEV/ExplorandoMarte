using ExplorandoMarte.Commands;
using ExplorandoMarte.Interfaces;
using ExplorandoMarte.Invokers;
using ExplorandoMarte.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ExplorandoMarte.View
{
    public class Application : IApplication
    {
        private readonly IController Controller;
        private readonly IServiceProvider ServiceProvider;

        public Application(IController controller, IServiceProvider serviceProvider)
        {
            Controller = controller;
            ServiceProvider = serviceProvider;
        }
        private T Resolve<T>() => ServiceProvider.GetRequiredService<T>();

        //Resolve<IController>().RegistrarLog("Explorando Marte");
        //ServiceProvider.GetRequiredService<IController>().RegistrarLog("Explorando Marte");

        public void Run()
        {
            try
            {
                Controller.InicializarLog();

                Controller.RegistrarLog("Iniciando a exploração de Marte...");

                Controller.RegistrarLog("Informe as Coordenadas do Planalto: ");

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

                Controller.RegistrarLog("Coordenadas do Planalto: " + planalto.ObterCoordenadasSuperiores());

                List<Rover> rovers = new List<Rover>();

                while (rovers.Count < 2)
                {
                    Controller.RegistrarLog("Informe a posição inicial do Rover: ");

                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("Exemplo de posição inicial válida: ");
                    Console.WriteLine("1 2 N");
                    Console.WriteLine("X = 1, Y = 2, Direção = Norte");
                    Console.WriteLine("Direções válidas: N, S, E, W");

                    var initialPosition = Console.ReadLine();

                    if (string.IsNullOrEmpty(initialPosition) || string.IsNullOrWhiteSpace(initialPosition))
                    {
                        throw new ArgumentException("Posição Inválida para o Rover.", initialPosition);
                    }

                    var positionParts = initialPosition.Split(' ');

                    int x = int.Parse(positionParts[0]);
                    int y = int.Parse(positionParts[1]);

                    if (planalto.PosicaoOcupada(x: x, y: y))
                    {
                        throw new InvalidOperationException(string.Format("Posição já ocupada por outra sonda Rover {0}.", planalto.ObterRoverPorLocalizacao(x, y).Nome));
                    }

                    char direction = char.Parse(positionParts[2].ToUpperInvariant());

                    var rover = new Rover(x, y, direction);

                    rover.SetPlanalto(planalto);

                    planalto.AdicionarRover(rover);

                    Controller.RegistrarLog("Posição Inicial do Rover: " + rover.GetPosition());

                    Controller.RegistrarLog("Informe a sequência de instruções para o Rover: ");

                    var instructions = Console.ReadLine();

                    Controller.RegistrarLog("Instruções: " + instructions);

                    var invoker = new CommandInvoker();

                    foreach (var instruction in instructions)
                    {
                        try
                        {
                            ICommand command = instruction switch
                            {
                                'L' => new TurnLeftCommand(rover),
                                'R' => new TurnRightCommand(rover),
                                'M' => new MoveCommand(rover),
                                _ => throw new ArgumentException("Instrução inválida. As instruções válidas são: L, R, M.")
                            };

                            invoker.AddCommand(command);

                            invoker.ExecuteCommands();

                            Controller.RegistrarLog("Instrução executada: " + instruction);
                        }
                        catch (Exception ex)
                        {
                            Controller.RegistrarErro(ex.Message);
                        }
                    }

                    rovers.Add(rover);
                }

            }
            catch (Exception ex)
            {
                Controller.RegistrarErro(ex.Message);
            }
            finally
            {
                Controller.RegistrarLog("Exploração de Marte finalizada.");
            }

        }
    }
}
