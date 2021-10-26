using System.Threading.Tasks;

namespace Prodest.EOuv.Dominio.Modelo.Interfaces.DAL
{
    public interface ISetorRepository
    {
        Task<SetorModel> BuscarSetor(string idSetor);
    }
}