using FreightTrack.API.Extensions;
using FreightTrack.API.JWTConffig;
using FreightTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FreightTrackDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));
builder.Services.RegisterServices();
builder.Services.AddJwtAuthentication(builder.Configuration);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication(); // ADD THIS
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// 👇 THIS LINE FIXES YOUR ISSUE
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();