using TwilioWhatsAppTriviaApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(40);
    options.Cookie.IsEssential = true;
});
builder.Services.AddScoped<TriviaService>();

var app = builder.Build();

app.UseSession();

app.MapControllers();

app.Run();