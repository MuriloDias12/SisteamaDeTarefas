using Microsoft.EntityFrameworkCore;

namespace SisteamaDeTarefas.Data
{
    public class SistemaDeTarefasDBContex : DbContext
    {
      public SistemaDeTarefasDBContex(DbContextOptions<SistemaDeTarefasDBContex> options)
            : base(options)
        {

        }
        public DbSet<Models.UsuarioModel> Usuarios  { get; set; }
        public DbSet<Models.TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
