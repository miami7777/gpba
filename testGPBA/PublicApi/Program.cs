CreateHostBuilder(args).Build().Run();
static IHostBuilder CreateHostBuilder(string[] args) =>

        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {                
                webBuilder                
                .UseIISIntegration()
                .UseIIS()
                .UseStartup<Startup>();
            });
