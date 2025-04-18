using Microsoft.EntityFrameworkCore;

namespace Post_Office_Management.Models
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Register> register { get; set; }

        public DbSet<Post_Office_Management.Models.Login> login { get; set; } = default!;
    }
}
