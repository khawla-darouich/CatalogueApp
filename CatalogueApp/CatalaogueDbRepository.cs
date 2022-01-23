using CatalogueApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogueApp
{
    public class CatalaogueDbRepository:DbContext
    {

        public DbSet<Category> Categories {get;set;}
        public DbSet<Product> Products {get;set;}
        public CatalaogueDbRepository(DbContextOptions options):base(options){

        }
    }
}