using ERP.Context;
using ERP.Models;
using ERP.Repositories.Interfaces;
using ERP.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DBcontext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//repozitorijumi
builder.Services.AddScoped<IKorisnik, KorisnikRepo>();
builder.Services.AddScoped<IArtikal, ArtikalRepository>();
builder.Services.AddScoped<IKategorija, KategorijaRepo>();
builder.Services.AddScoped<IPorudzbina, PorudzbinaRepo>();
builder.Services.AddScoped<IZaposleni,ZaposleniRepo >();
builder.Services.AddScoped<IReview, ReviewRepository>();
builder.Services.AddScoped<IDostupneVelicine, DostupneVelicineRepo>();
builder.Services.AddScoped<IVelicine,VelicineRepository>();
builder.Services.AddScoped<IAP,APRepository>();






var app = builder.Build();



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
