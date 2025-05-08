using AppBanco.AccessData.Context;
using AppBanco.AccessData.Repository;

var builder = WebApplication.CreateBuilder(args);

// Sql server conecction
builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

// Add services to the container.
builder.Services.AddScoped<ICuentaRepository, CuentaRepository>();


builder.Services.AddControllers();
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
