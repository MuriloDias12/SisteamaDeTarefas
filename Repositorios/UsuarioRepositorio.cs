using SisteamaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;
namespace SisteamaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : Interfaces.IUsuarioRepositorio
    {
        private readonly Data.SistemaDeTarefasDBContex _dbContex;      
            public UsuarioRepositorio(Data.SistemaDeTarefasDBContex sistemaDeTarefasDBContex)
        {
            _dbContex = sistemaDeTarefasDBContex;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContex.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContex.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
           await _dbContex.Usuarios.AddAsync(usuario);
           await _dbContex.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
           Models.UsuarioModel usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null)
            {
                throw new Exception("Usuário para o ID "+ id + " : não foi encontrado");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContex.Usuarios.Update(usuarioPorId);
           await _dbContex.SaveChangesAsync();
            return usuarioPorId;
        }


        public async Task<bool> Apagar(int id)
        {
            Models.UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception("Usuário para o ID " + id + " : não foi encontrado");
            }

            _dbContex.Usuarios.Remove(usuarioPorId);
           await _dbContex.SaveChangesAsync();
            return true;
        }

       

       
    }
}
