using LojaAPi.Entites;
using Microsoft.EntityFrameworkCore;

namespace LojaAPi.Repositores
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; } // toda vez que for declarada uma varialvel public no c++ por padrão coloca esse { get; set; } // aqui esta sendo declarado a variavel usuarios do tipo usuario, e o DbSet é como se fose um tipo de lista de banco DbSet é quem vai no banco e trás os dados pro backend mas o c# não consegue manipular os dados do DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder) // essa função é para representar a tabela do banco, os daods não seram trabalhados ddentro dela , ela só serve para fazer o "de para" para referenciar as tabelas do banco
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios","dbo");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.Password)
                      .HasColumnName("password")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Tipo)
                      .HasColumnName("tipo")
                      .IsRequired();

                entity.Property(e => e.Email)
                      .HasColumnName("email")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.DataCadastro)
                      .HasColumnName("data_cadastro");
                      
            });
        }

    }
}
