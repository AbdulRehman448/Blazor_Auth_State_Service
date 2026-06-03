using Greeting_App.Components;
using Greeting_App.Services; // Ensure the correct namespace is imported

var builder = WebApplication.CreateBuilder(args);

// Add services for Server-Side rendering and Interactivity
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Register the AuthenticationStateService as a Singleton
builder.Services.AddSingleton<AuthenticationStateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
