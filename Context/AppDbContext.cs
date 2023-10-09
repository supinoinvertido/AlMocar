using AlMocar.Models;
using Microsoft.EntityFrameworkCore;
namespace AlMocar.Context
{
public class AppDbContext : DbContext
{
public AppDbContext(DbContextOptions<AppDbContext> options):
base(options){
}
public DbSet<Categoria> Categorias{get;set;}
public DbSet<Comanda> Comandas{get;set;}
}
}