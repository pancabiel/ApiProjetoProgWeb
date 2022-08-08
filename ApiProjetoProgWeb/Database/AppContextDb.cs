using ApiProjetoProgWeb.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoProgWeb.Database
{
    public class AppContextDb : IdentityDbContext<Usuario>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=provaProgWeb;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comanda>()
                .HasMany(comanda => comanda.comandaProdutos)
                .WithOne()
                .HasForeignKey(cProduto => cProduto.idComanda);

            builder.Entity<ComandaProduto>()
                .HasOne(comandaProduto => comandaProduto.produto)
                .WithMany()
                .HasForeignKey(comandaProduto => comandaProduto.idProduto);

            builder.Entity<Produto>()
                .HasData(
                new Produto
                {
                    id = 1,
                    nome = "X-Salada",
                    preco = 30
                },
                new Produto
                {
                    id = 2,
                    nome = "X-Bacon",
                    preco = 35
                },
                new Produto
                {
                    id = 3,
                    nome = "X-Galinha",
                    preco = 25
                }
                );

            builder.Entity<Comanda>()
                .HasData(
                new Comanda
                {
                    id = 1,
                    nomeUsuario = "João",
                    telefoneUsuario = "478888888"
                },
                new Comanda
                {
                    id = 2,
                    nomeUsuario = "Pedro",
                    telefoneUsuario = "479999999"
                }
                );

            builder.Entity<ComandaProduto>()
                .HasData(
                new ComandaProduto
                {
                    id = 1,
                    idComanda = 1,
                    idProduto = 1,
                    quantidade = 1
                },
                new ComandaProduto
                {
                    id = 2,
                    idComanda = 1,
                    idProduto = 2,
                    quantidade = 1
                },
                new ComandaProduto
                {
                    id = 3,
                    idComanda = 2,
                    idProduto = 3,
                    quantidade = 1
                }
                );

            base.OnModelCreating(builder);
        }

        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<ComandaProduto> ComandaProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
