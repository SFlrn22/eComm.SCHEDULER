using eComm.APPLICATION.Contracts;
using eComm.APPLICATION.Implementations;
using eComm.PERSISTENCE.Helpers;
using eComm.PERSISTENCE.Implementations;
using eComm.SCHEDULER;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var columnOptions = new ColumnOptions
{
    AdditionalColumns = new Collection<SqlColumn>()
    {
        new SqlColumn("ProductsCount", SqlDbType.Int),
        new SqlColumn("UsersCount", SqlDbType.Int),
        new SqlColumn("RatingsCount", SqlDbType.Int)
    }
};

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(AesDecryptHelper.Decrypt("supersecretKEYThatIsHardToGuesSS", config.GetSection("ConnectionStrings:DefaultConnection").Value!),
        new MSSqlServerSinkOptions
        {
            TableName = "tbl_SchedulerLogs",
            SchemaName = "dbo",
            AutoCreateSqlTable = true,
        }, columnOptions: columnOptions)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddSingleton<IDataRepository, DataRepository>();
builder.Services.AddSingleton<IOrchestrationService, OrchestrationService>();

var host = builder.Build();
host.Run();
