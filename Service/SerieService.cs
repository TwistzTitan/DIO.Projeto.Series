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
            Debug.Assert(!av.Equals(null) && (av > 0 && av < 10));

            serie.TotalAvaliacao++;

            serie.SerieAvaliacao += av / serie.TotalAvaliacao;

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
            serieRepositorio.Alterar(item);
        }

        public Serie BuscarSerie(string nome)
        {
            return serieRepositorio.ObterPorNome(nome);
        }
    }
}
