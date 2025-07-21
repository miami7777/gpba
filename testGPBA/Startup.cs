using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
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
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });
        services.AddControllersWithViews();
        services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "ClientApp/build";
        });
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

        app.UseCors("AllowAll");
        app.UseStaticFiles();
        app.UseSpaStaticFiles();
        app.UseRouting();      
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
        });
        // Initialize database
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();
        }
        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";

            if (env.IsDevelopment())
            {
                spa.UseReactDevelopmentServer(npmScript: "start");
            }
        });
    }
}
