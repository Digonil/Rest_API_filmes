using FilmesApiRest.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Pega os dados de conex�o no appsettings.json para criar o connectionstring
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

//Add context of DB connection
builder.Services.AddDbContext<FilmeContext>(opts => 
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//Add Automapper on the project
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container
//builder.Services.AddControllers();

// Add services to the container (Adicionado posteriormente o Newtonsoft Json para mudan�as parciais no json).
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
