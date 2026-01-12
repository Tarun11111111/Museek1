using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Museek.Components;
using Museek.Components.Account;
using Museek.Data;
using Museek.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<MuseekContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MuseekContext")
        ?? throw new InvalidOperationException("Connection string 'MuseekContext' not found.")
    )
);

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Auth
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();

builder.Services.AddIdentityCore<MuseekUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<MuseekContext>()
.AddSignInManager()
.AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<MuseekUser>, IdentityNoOpEmailSender>();

// Last.fm config + client
builder.Services.Configure<LastFmOptions>(builder.Configuration.GetSection("LastFm"));
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<LastFmClient>();

// Controllers (for /api/lastfm/...)
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Map API controllers
app.MapControllers();

// Map Blazor
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Identity endpoints
app.MapAdditionalIdentityEndpoints();

app.Run();
