using Rhetos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRhetosHost((serviceProvider, rhetosHostBuilder) => rhetosHostBuilder
.ConfigureRhetosAppDefaults()
.UseBuilderLogProviderFromHost(serviceProvider).ConfigureConfiguration(cfg => cfg.MapNetCoreConfiguration(builder.Configuration)))
.AddAspNetCoreIdentityUser()
.AddHostLogging()
.AddDashboard()
.AddRestApi(o =>
{
    o.BaseRoute = "rest";
    o.GroupNameMapper = (conceptInfo, controller, oldName) => "v1";
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => o.CustomSchemaIds(type => type.ToString())); // CustomSchemaIds allows multiple entities with the same name in different modules.

var app = builder.Build();

app.UseRhetosRestApi();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapRhetosDashboard();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
