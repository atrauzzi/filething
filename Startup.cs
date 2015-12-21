namespace FileThing {

	using FileThing.Domain;
	using Glimpse;
	using Microsoft.AspNet.Builder;
	using Microsoft.AspNet.Hosting;
	using Microsoft.Extensions.DependencyInjection;
	

	public class Startup {

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services) {

			services.AddGlimpse();

			services.AddCaching();
			services.AddSession(options => {
				options.CookieName = "filething";
			});

			services.AddMvc();

			services
				.AddEntityFramework()
				.AddNpgsql()
			;

			services
				.AddIdentity<User, Role>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
			;

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

			app.UseSession();

			app.UseCookieAuthentication(options => {
				options.AutomaticAuthenticate = true;
			});

			app.UseIISPlatformHandler();

			if (env.IsDevelopment()) {
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
				app.UseGlimpse();
			}

			app.UseMvc(router => {

				router.MapRoute("home", "", new {
					controller = "Home",
					action = "Index"
				});

				router.MapRoute("upload", "upload",	new {
					controller = "Home",
					action = "Upload"
				});

			});
			
		}

		// Entry point for the application.
		public static void Main(string[] args) => WebApplication.Run<Startup>(args);

	}

}
