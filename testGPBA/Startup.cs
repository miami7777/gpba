using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using testGPBA.Domain;
using testGPBA.Domain.Repositories.Abstract;
using testGPBA.Domain.Repositories.EntityFramework;
using testGPBA.Models;

public class Startup {
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        BaseConfiguration = new BaseConfiguration();
        Configuration.Bind("Project", new BaseConfiguration());
    }
    public IConfiguration Configuration { get; }
    public BaseConfiguration BaseConfiguration { get; }
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddDbContext<AppDbContext>(x => x.UseSqlServer(BaseConfiguration.projectConnection));
        services.AddControllersWithViews();

        services.AddScoped<IOfferRepositories, OfferRepositories>();

        services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();       
       
        app.UseRouting();      
        app.UseAuthorization();

        app.UseEndpoints(
            endpoints => {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
               
            });
        // Initialize database
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();
        }
    }
}
