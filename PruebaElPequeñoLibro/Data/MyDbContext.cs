using Microsoft.EntityFrameworkCore;
using PruebaElPequeñoLibro.Models;

namespace PruebaElPequeñoLibro.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<TodoItem> Items { get; set; }
    }
}
