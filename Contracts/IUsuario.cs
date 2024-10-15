using ExamAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExamAPI.Contracts
{
    public interface IUsuario
    {
        public  Task<List<Usuario>> GetUsersAsync();
        public  Task<Usuario> GetUserById(int id);
        public  Task<bool> CreateUserAsync(Usuario usuario);
        public  Task<bool> UpdateUserAsync(Usuario usuario);
        public  Task<bool> DeleteUserAsync(int id);

    }
}
