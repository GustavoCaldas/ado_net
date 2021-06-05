using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> GetAllFuncionarios();
        Task AddFuncionario(Funcionario funcionario);
        Task UpdateFuncionario(Funcionario funcionario);
        Task<Funcionario> GetFuncionarioById(int id);
        Task RemoveFuncionario(int? id);
    }
}