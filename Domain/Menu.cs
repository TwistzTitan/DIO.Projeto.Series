using DIO.Projeto.Series.Domain.Series;
using DIO.Projeto.Series.Repository;
using DIO.Projeto.Series.Service;
using System;
using System.Configuration;
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
            bool chaveMenu = true;
            while (chaveMenu)
            {

                Roteador(ApresentaOpcoesMenu(),out chaveMenu);
            }


            
        }

        public static int ApresentaOpcoesMenu()
        {
            
            int opcao;
            while (true)
            {
                Thread.Sleep(2000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t Escolha uma das opções do DIO Menu \n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\t [1] - Adicionar Série");
                Console.WriteLine("\n\t [2] - Listar Séries");
                Console.WriteLine("\n\t [3] - Editar Série");
                Console.WriteLine("\n\t [4] - Avaliar Série");
                Console.WriteLine("\n\t [5] - Abrir Série");
                Console.WriteLine("\n\t [6] - Sair");
                Console.ResetColor();
                opcao = int.Parse(Console.ReadLine());

                if (!opcao.Equals(null) && (opcao > 0 && opcao < 7)) break;
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Escolha um opção válida por favor! \n");
                    Thread.Sleep(3000);
                    Console.Clear();
                } 
            }

            return opcao;
        }

        public static void Roteador(int opcao, out bool menu)
        {
            menu = false;

            switch (opcao)
            {

                case 1:
                    String nome, desc, url;
                    while (true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\t Preencha as informações da série para que possamos cadastrá-la com sucesso! \n");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n Nome da série :");
                        Console.ResetColor();
                        nome = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n Descrição da série :");
                        Console.ResetColor();
                        desc = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n URL para série :");
                        Console.ResetColor();
                        url = Console.ReadLine();
                        if (!String.IsNullOrEmpty(nome) && !String.IsNullOrEmpty(desc)) break;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O Nome e a Descrição da série são necessários!");
                        Thread.Sleep(3000);
                    }
                    try
                    {
                        serieService.CadastrarSerie(new Serie() { SerieNome = nome , SerieDescricao = desc, SerieURL = url});
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Não foi possível realizar essa operação devido a: {0}", e.Message);
                    }
                    finally
                    {

                        Console.WriteLine("\n\tDeseja retornar ao menu?(S/N)");
                        var retorno = Console.ReadLine().ToLower() ;
                        menu = retorno.Contains('s') ? true : false;
                    }
                    break;
                case 2:
                    try
                    {

                        if (serieService.TemSeries())
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\t ### DIO Series ###");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\n\tID | Nome da Série | Avaliação | URL");
                            
                            foreach (Serie i in serieService.ListarSeries())
                            {
                                Console.WriteLine("\n\t {0} | {1} | {2} | {3} |", i.SerieID, i.SerieNome, i.SerieAvaliacao, i.SerieURL);
                            }
                            Console.ResetColor();
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
                        Console.WriteLine("\n\tDeseja retornar ao menu?(S/N)");
                        var retorno = Console.ReadLine();
                        menu = retorno.Contains('S') ? true : false;
                    }
                    
                    break;
                case 3:

                    Console.Clear();
                    if (serieService.TemSeries())
                    {


                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Informe o numero da serie que você deseja editar\n");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        foreach (Serie i in serieService.ListarSeries())
                        {
                            Console.WriteLine("\n\t {0} | {1} | {2} | {3} |", i.SerieID, i.SerieNome, i.SerieAvaliacao, i.SerieURL);
                        }
                        Console.ResetColor();
                        int id = int.Parse(Console.ReadLine());
                        try
                        {
                            Serie s = serieService.BuscarSerie(id);
                            serieService.EditarSerie(s);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Edição concluída com sucesso.");
                            Console.ResetColor();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Não foi possível realizar essa operação devido a: {0}", e.Message);
                        }
                        finally
                        {

                            Console.WriteLine("\n\tDeseja retornar ao menu?(S/N)");
                            var retorno = Console.ReadLine().ToLower();
                            menu = retorno.Contains('s') ? true : false;
                        }
                    }
                    else
                    {

                        Console.WriteLine("\n\tDeseja retornar ao menu?(S/N)");
                        var retorno = Console.ReadLine().ToLower();
                        menu = retorno.Contains('s') ? true : false;
                    }
                    break;
                case 4:
                    Console.Clear();
                    if (serieService.TemSeries())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Informe o numero da serie que você deseja avaliar");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        foreach (Serie i in serieService.ListarSeries())
                        {
                            Console.WriteLine("\n\t {0} | {1} | {2} | {3} |", i.SerieID, i.SerieNome, i.SerieAvaliacao, i.SerieURL);
                        }

                        int id = int.Parse(Console.ReadLine());
                        try
                        {
                            Serie serie = serieService.BuscarSerie(id);
                            Console.WriteLine("Informe qual a nota de avaliação:\n");
                            double nota = double.Parse(Console.ReadLine());
                            serieService.AvaliarSerie(serie, nota);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Avaliação realizada concluída.");
                            Console.ResetColor();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Não foi possível realizar essa operação devido a: {0}", e.Message);
                        }
                        finally
                        {

                            Console.WriteLine("\n\tDeseja retornar ao menu?(S/N)");
                            var retorno = Console.ReadLine();
                            menu = retorno.Contains('S') ? true : false;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t Você ainda não possui séries cadastradas!");
                        Console.ResetColor();
                        Console.WriteLine("\n\tDeseja retornar ao menu?(S/N)");
                        var retorno = Console.ReadLine().ToLower();
                        menu = retorno.Contains('s') ? true : false;
                    }
                    break;
                case 5:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Informe o numero da serie que você deseja abrir\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (serieService.TemSeries())
                    {
                        foreach (Serie i in serieService.ListarSeries())
                        {
                            Console.WriteLine("\n\t {0} | {1} | {2} | {3} |", i.SerieID, i.SerieNome, i.SerieAvaliacao, i.SerieURL);
                        }


                        Console.ResetColor();
                        int id = int.Parse(Console.ReadLine());
                        try
                        {
                            Serie s = serieService.BuscarSerie(id);
                            if (s.TemURL)
                            {

                                Process.Start(fileName: ConfigurationManager.AppSettings["SerieNavegador"], s.SerieURL);
                                Thread.Sleep(3000);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\nAproveite sua série, até mais!");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Thread.Sleep(2000);
                                Console.WriteLine("\t\n ### DIO Series ###");
                                Console.ResetColor();
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("Volte ao menu e adicione uma URL(link) para a série!");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Não foi possível realizar essa operação devido a: {0}", e.Message);
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t Você ainda não possui séries cadastradas!");
                        Console.ResetColor();
                        Console.WriteLine("\n\tDeseja retornar ao menu?(S/N)");
                        var retorno = Console.ReadLine().ToLower();
                        menu = retorno.Contains('s') ? true : false;
                    }

                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t### Obrigado por utilizar a DIO Series ###");
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;
            }
        }

    }
}