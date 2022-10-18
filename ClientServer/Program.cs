using ClientServer.Context;
using ClientServer.Models;
using ClientServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1",new OpenApiInfo { Title = "VSuper.ClienteApi",Version = "v1"});
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Autentica;Integrated Security=True"));

builder.Services.AddIdentity<AppUsers, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<ILocalicadesService, LocalicadesService>();

builder.Services.AddHttpContextAccessor();
var app = builder.Build();


CreateRoles(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void CreateRoles(IApplicationBuilder app) 
{
using(var serviceScope = app.ApplicationServices.CreateScope()) 
    {
        var InitRolesUser = serviceScope.ServiceProvider.GetService<IAccountService>();
        InitRolesUser.InitializeSeedRoles();
    }
}