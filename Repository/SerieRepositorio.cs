using DIO.Projeto.Series.Domain.Series;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DIO.Projeto.Series.Repository
{
    public class SerieRepositorio : IRepository<Serie>
    {


        public SerieRepositorio() { }

        public bool Inserir(Serie item)
        {
            bool retorno = true;
            
            using (var ctx = new SerieContext())
            {
                try
                {
                    ctx.Series.Add(item);
                    ctx.SaveChanges();
                }
                catch(Exception)
                {
                    retorno = false;
                }
                
            }

            return retorno;
        }

        public List<Serie> Listar()
        {

            using (SerieContext ctx = new SerieContext())
            {
                return ctx.Series.ToList();
            }
            
        }

        public Serie ObterPorId(int i)
        {
            Serie s;

            using (SerieContext ctx = new SerieContext())
            {
                s = ctx.Series.Find(i);
            }
            return s;
        }
        
        public bool Alterar(Serie item)
        {
            bool retorno = true;
            using(SerieContext ctx = new SerieContext())
            {
                try
                {
                    Serie oldS = ctx.Series.Find(item.SerieID);
                    oldS = item;
                    ctx.SaveChanges();
                }
                catch (Exception)
                {
                    retorno = false;
                }
            }
            return retorno;
        }

        public bool Remover(Serie item)
        {
            throw new NotImplementedException();
        }

        public Serie ObterPorNome(string n)
        {
            Serie s;

            using(SerieContext ctx = new SerieContext())
            {
                s = ctx.Series.Find(n);
            }
            return s;
        }
    }
}
