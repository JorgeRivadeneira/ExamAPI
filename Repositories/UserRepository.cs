using ExamAPI.Contracts;
using ExamAPI.Data;
using ExamAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ExamAPI.Repositories
{
    public class UserRepository : IUsuario
    {
        private readonly ApplicationDbContext _appDbContext;

        public UserRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Usuario>> GetUsersAsync()
        {

                var usuarios = await _appDbContext
                                        .Usuarios
                                        .ToListAsync();

                return usuarios;
        }

        public async Task<Usuario> GetUserById(int id)
        {
            var usuario = await _appDbContext.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<bool> CreateUserAsync(Usuario usuario)
        {
            try
            {
                _appDbContext.Usuarios.Add(usuario);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(Usuario usuario)
        {
            try
            {
                var existingUser = await _appDbContext.Usuarios.Where(x => x.Id == usuario.Id).FirstOrDefaultAsync();
                if (existingUser is null)
                {
                    return false;
                }
                _appDbContext.Usuarios.Add(usuario);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var existingUser = await _appDbContext.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existingUser is null)
                {
                    return false;
                }
                _appDbContext.Usuarios.Remove(existingUser);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Usuario>> GetUsersByDomain(string domain)
        {
            var matchedUsers = await _appDbContext.Usuarios.Where(x => x.Email.EndsWith(domain)).ToListAsync();
            return matchedUsers;
        }
    }
}
