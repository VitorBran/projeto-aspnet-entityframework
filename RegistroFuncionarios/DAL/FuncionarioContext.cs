using RegistroFuncionarios.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace RegistroFuncionarios.DAL
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext() : base("FuncionarioContext")
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}