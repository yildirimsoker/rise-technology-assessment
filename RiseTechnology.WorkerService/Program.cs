using RiseTechnology.Application.DI;
using RiseTechnology.Infrastructure.DI;
using RiseTechnology.WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
      .ConfigureServices((hostContext, services) =>
      {
          IConfiguration configuration = hostContext.Configuration;
          services.AddInfrastructure(configuration);
          services.AddApplication();
          services.AddHostedService<Worker>();
      })
    .Build();

await host.RunAsync();
