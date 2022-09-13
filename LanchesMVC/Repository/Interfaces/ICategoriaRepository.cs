using LanchesMVC.Models;

namespace LanchesMVC.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        //Definir o contrato
        IEnumerable<Categoria> Categorias { get; }
    }
}
