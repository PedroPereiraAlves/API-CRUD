using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel UsuarioPorId = await BuscarPorId(id);

            if(UsuarioPorId is null)
            {
                throw new Exception($"Usario de ID: {id} não foi encontado");
            }

            UsuarioPorId.Nome = usuario.Nome;

            UsuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(UsuarioPorId);
            await _dbContext.SaveChangesAsync();

            return UsuarioPorId;

        }
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel UsuarioPorId = await BuscarPorId(id);

            if (UsuarioPorId is null)
            {
                throw new Exception($"Usario de ID: {id} não foi encontado");
            }

            _dbContext.Usuarios.Remove(UsuarioPorId);
           await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
