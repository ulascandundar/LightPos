using LightPos.Application.Services;
using LightPos.Infrastructure.Mapping;
using LightPos.Infrastructure.Persistence;
using LightPos.Shared.Services;
using LightPos.Web.Components;
using LightPos.Web.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the LightPos.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.RegisterDb("");
builder.Services.RegisterMapping();
builder.Services.RegisterService();
builder.Services.AddMudServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(
        typeof(LightPos.Shared._Imports).Assembly,
        typeof(LightPos.Web.Client._Imports).Assembly);
using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<LightPosDbContext>();
	context.Database.EnsureCreated();
	SeedService.InitializeData(context).GetAwaiter().GetResult();
}
app.Run();
