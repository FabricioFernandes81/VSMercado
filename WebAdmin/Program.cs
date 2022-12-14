using WebAdmin.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ILocalidadeService,LocalidadeService>();
builder.Services.AddHttpClient("ServerClient", c=>
{
    c.BaseAddress = new Uri(builder.Configuration["ServiceUri:ServerClient"]);
    c.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
    c.DefaultRequestHeaders.Add("Keep-Alive", "3600");
    c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-ServerClient");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
