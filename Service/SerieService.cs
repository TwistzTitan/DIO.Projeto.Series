using DIO.Projeto.Series.Domain.Series;
using DIO.Projeto.Series.Repository;
using System;
using System.Collections.Generic;
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
            serieRepositorio.Alterar(serie);
        }

        public void CadastrarSerie(Serie serie)
        {
            serieRepositorio.Inserir(serie);
        }

        public List<Serie> ListarSeries()
        {
            return serieRepositorio.Listar();
        }
    }
}
