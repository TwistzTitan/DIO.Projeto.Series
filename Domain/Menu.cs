using DIO.Projeto.Series.Domain.Series;
using DIO.Projeto.Series.Repository;
using DIO.Projeto.Series.Service;
using System;
using System.Threading;

namespace DIO.Projeto.Series.Domain
{
    public static class Menu
    {
        private static SerieService serieService 
        {
            get { return serieService ?? new SerieService(new SerieRepositorio()); }
            set { serieService = value; }
        } 

        public static void Iniciar()
        {
            Console.WriteLine("\t#### Bem vindo a DIO Series ####\n");
            ApresentaOpcoesMenu();
            
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
                    Console.WriteLine("\n Escolha um opção válida por favor! \n");
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
                        Console.WriteLine("O Nome e a Descrição da série é necessário!");
                        Thread.Sleep(3000);
                    }
                    serieService.CadastrarSerie(new Serie(nome, desc, url));

                    break;
                case 2:
                    var listaSeries = serieService.ListarSeries();
                    
                    if(listaSeries.Count > 0)
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
                    break;
                case 3:

                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
        }

    }
}