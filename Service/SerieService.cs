using DIO.Projeto.Series.Domain.Series;
using DIO.Projeto.Series.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DIO.Projeto.Series.Service
{
    public class SerieService
    {
        private IRepository<Serie> serieRepositorio;
        public SerieService(IRepository<Serie> repo)
        {
            serieRepositorio = repo;
        }

        public void AvaliarSerie(Serie serie, double av)
        {
            Debug.Assert(!av.Equals(null) && (av > 0 && av <= 10));

            serie.TotalAvaliacao++;

            serie.SerieAvaliacao = (av+serie.SerieAvaliacao) / serie.TotalAvaliacao;

            serieRepositorio.Alterar(serie);
        }

        public void CadastrarSerie(Serie serie)
        {

            if (serieRepositorio.Inserir(serie))
            {
                Console.WriteLine("\nCadastro da série concluido com sucesso!\n");
            }
        }

        public List<Serie> ListarSeries()
        {
            return serieRepositorio.Listar();
        }

        internal void EditarSerie(Serie item)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tInforme o que você deseja editar, por favor.");
            Console.WriteLine("\n\t[1] - Descrição da Série");
            Console.WriteLine("\n\t[2] - URL da Série");
            
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("\n\tColoque a nova descrição\n");
                    var novaDescricao  = Console.ReadLine();
                    item.SerieDescricao = novaDescricao;
                    break;
                
                case 2:
                    Console.WriteLine("\n\tColoque a nova URL\n");
                    var novaURL = Console.ReadLine();
                    item.SerieURL = novaURL;
                    break;

            }

            serieRepositorio.Alterar(item);
        }

        public Serie BuscarSerie(string nome)
        {
            return serieRepositorio.ObterPorNome(nome);
        }

        public Serie BuscarSerie(int i)
        {
            return serieRepositorio.ObterPorId(i);
        }

        public bool TemSeries()
        {
            return (ListarSeries() != null) ? true : false;
            
        }
    }
}
