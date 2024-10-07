using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.SoundWave.Data;
using Model.SoundWave.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

// Add DbContext with connection string
string connection = builder.Configuration.GetConnectionString("SoundWaveDBConnectionString");
builder.Services.AddDbContext<SoundWaveDBContext>(options => options.UseSqlServer(connection));

// Add Identity services
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<SoundWaveDBContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();
app.MapRazorPages();
app.Run();
