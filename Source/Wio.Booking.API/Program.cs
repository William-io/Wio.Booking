using Wio.Booking.API.Configuration;
using Wio.Booking.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<DataContext>(builder.Configuration["ConnectionStrings:DefaultConnection"]);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.ResolveDependencies();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
