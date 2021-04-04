using System.Collections.Generic;

namespace DIO.Projeto.Series.Repository
{
    public interface IRepository<T>
    {
         List<T> Listar();    
                 
         T ObterPorId(int i);

        T ObterPorNome(string n);

         bool Alterar(T i);
         
         bool Remover(T item);

         bool Inserir(T item);
    }
}