using System.Reflection.Emit;
using System.Reflection.Metadata;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ComexAPI.Data;

public class ProdutoContext : DbContext
{
    public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts)
    {
        
    }
	protected override void OnModelCreating(ModelBuilder builder)
	{
		/* builder.Entity<Sessao>()
			.HasOne(sessao => sessao.Filme)
			.WithMany(filme => filme.Sessoes)
			.HasForeignKey(sessao => sessao.FilmeId); */
	}
	public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}
