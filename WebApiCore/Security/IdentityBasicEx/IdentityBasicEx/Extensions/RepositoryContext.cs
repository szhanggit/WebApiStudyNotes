using IdentityBasicEx.Configuration;
using IdentityBasicEx.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityBasicEx.Extensions
{
    public class RepositoryContext : IdentityDbContext<User>
    {
		public RepositoryContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new RoleConfiguration());
		}

		//public DbSet<Company>? Companies { get; set; }
		//public DbSet<Employee>? Employees { get; set; }
	}
}
