namespace FileThing {

	using Microsoft.AspNet.Identity.EntityFramework;
	using Microsoft.Data.Entity;
	using FileThing.Domain;


	public class ApplicationDbContext : IdentityDbContext {

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

			optionsBuilder.UseNpgsql(@"Server=localhost;Database=filething;Username=filething;Password=filething;");

		}

	}

}
