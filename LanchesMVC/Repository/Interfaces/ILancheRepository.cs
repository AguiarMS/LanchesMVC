using LanchesMVC.Models;

namespace LanchesMVC.Repository.Interfaces
{
    public interface ILancheRepository
    {
        //Retornar todos os lanhes em uma lista de lanches / retornando em um Obj
        IEnumerable<Lanche> Lanches { get; }

        IEnumerable<Lanche> LanchesPreferidos { get; }

        Lanche GetLancheById(int lancheId);
    }
}
