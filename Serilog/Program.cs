using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSerilog();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Debug(Serilog.Events.LogEventLevel.Information)
    .WriteTo.Console()
    .WriteTo.File("logs.txt")
    .CreateLogger();

//builder.Services.AddLogging();

//builder.Logging.ClearProviders().SetMinimumLevel(LogLevel.Information)/*.AddDebug()*/.AddConsole().AddProvider(new MyCusgtomLoggerFactory());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseMiddleware<RequestLogContextMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
