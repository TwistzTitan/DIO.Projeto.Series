using DIO.Projeto.Series.Domain.Series;
using DIO.Projeto.Series.Repository;
using DIO.Projeto.Series.Service;
using System;
using System.Diagnostics;
using System.Threading;

namespace DIO.Projeto.Series.Domain
{
    public static class Menu
    {
        private static SerieService serieService { get; set; } 

        public static void Iniciar()
        {
            serieService = new SerieService(new SerieRepositorio());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t#### Bem vindo a DIO Series ####\n");
            
            Roteador(ApresentaOpcoesMenu());


            
        }

        public static int ApresentaOpcoesMenu()
        {
            
            int opcao = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\t Escolha uma das opções do DIO Menu \n");
                Console.WriteLine("\n\t [1] - Adicionar Série");
                Console.WriteLine("\n\t [2] - Listar Séries");
                Console.WriteLine("\n\t [3] - Editar Série");
                Console.WriteLine("\n\t [4] - Avaliar Série");
                Console.WriteLine("\n\t [5] - Abrir Série");
                Console.WriteLine("\n\t [6] - Sair");
                opcao = int.Parse(Console.ReadLine());

                if (!opcao.Equals(null) && (opcao > 0 && opcao < 7)) break;
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Escolha um op��o v�lida por favor! \n");
                    Thread.Sleep(3000);
                    Console.Clear();
                } 
            }

            return opcao;
        }

        public static void Roteador(int opcao)
        {
            switch (opcao)
            {

                case 1:
                    String nome, desc, url;
                    while (true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t Preencha as informações da série para que possamos cadastrá-la com sucesso! \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n Nome da série :");
                        nome = Console.ReadLine();
                        Console.WriteLine("\n Descrição da série :");
                        desc = Console.ReadLine();
                        Console.WriteLine("\n URL para série :");
                        url = Console.ReadLine();
                        if (!String.IsNullOrEmpty(nome) && !String.IsNullOrEmpty(desc)) break;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O Nome e a Descrição da série são necessários!");
                        Thread.Sleep(3000);
                    }
                    try
                    {
                        serieService.CadastrarSerie(new Serie(nome, desc, url));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Não foi possível realizar essa operação devido a: {0}", e.Message);
                    }

                    break;
                case 2:
                    try
                    {
                        var listaSeries = serieService.ListarSeries();

                        if (listaSeries != null)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t ### DIO Series disponíveis ###");
                            foreach (Serie i in listaSeries)
                            {
                                Console.WriteLine("\n\t {0} | {1} | {2} | {3} |", i.SerieID, i.SerieNome, i.SerieAvaliacao, i.SerieURL);
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t Ainda não temos séries cadastradas .. :(");
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Não foi possível realizar essa operação devido a: {0}", e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Deseja retornar ao menu?");
                    }
                    
                    break;
                case 3:

                    Console.Clear();
                    Console.WriteLine("Informe o nome da serie que você deseja editar\n");
                    nome = Console.ReadLine();
                    try
                    {
                        Serie s = serieService.BuscarSerie(nome);
                        serieService.EditarSerie(s);
                        Console.WriteLine("Edição concluída com sucesso.");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Não foi possível realizar essa operação devido a: {0}", e.Message);
                    }
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Informe o nome da serie que você deseja avaliar");
                    nome = Console.ReadLine();
                    try
                    {
                        Serie serie = serieService.BuscarSerie(nome);
                        Console.WriteLine("Informe qual a nota de avaliação:\n");
                        double nota = double.Parse(Console.ReadLine());
                        serieService.AvaliarSerie(serie, nota);
                        Console.WriteLine("Avaliação realizada concluída.");
                    }   
                    catch(Exception e)
                    {
                        Console.WriteLine("Não foi possível realizar essa operação devido a: {0}", e.Message);
                    }


                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Informe o nome da serie que você deseja abrir\n");
                    nome = Console.ReadLine();
                    try
                    {
                        Serie s = serieService.BuscarSerie(nome);
                        if (s.TemURL)
                        {
                            Process.Start("IExplore.exe",s.SerieURL);
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Não foi possível realizar essa operação devido a: {0}", e.Message);
                    }
                    break;
                case 6:
                    Console.WriteLine("Obrigado por utilizar a DIO Series");
                    Environment.Exit(0);
                    break;
            }
        }

    }
}