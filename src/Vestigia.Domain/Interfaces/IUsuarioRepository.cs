using Vestigia.Domain.Entities;

namespace Vestigia.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(Guid id);
        Task<Usuario> GetByEmailAsync(string email);
        Task<Usuario> GetByUsernameAsync(string username);
        Task<List<Usuario>> GetAllAsync();
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Guid id);

    }
}