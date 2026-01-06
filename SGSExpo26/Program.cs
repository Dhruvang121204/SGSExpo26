using SGSExpo26.Services;
using SGSExpo26.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Railway PORT support (CRITICAL)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(
        int.Parse(Environment.GetEnvironmentVariable("PORT") ?? "5000")
    );
});

// 🔹 Services
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddSingleton<Fast2SmsService>();
builder.Services.AddSingleton<WhatsAppService>();
builder.Services.AddSingleton<DatabaseSeeder>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔹 AUTO SEED SLOTS (runs once if DB is empty)
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    seeder.SeedSlots();
}

// 🔹 Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// 🔹 Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Booking}/{action=Index}/{id?}");

app.Run();
