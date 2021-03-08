using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        void Lista();
        void RetornaPorId(int id);
        void Insere(Genero genero, string titulo, int ano, string descricao, bool excluido);
        void Exclui(int id);
        void Atualiza(int id, Genero genero, string titulo, int ano, string descricao);
        int ProximoId();

    }
}