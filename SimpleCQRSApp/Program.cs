using SimpleCQRSApp.Application;
using SimpleCQRSApp.BL;
using SimpleCQRSApp.Infra.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddUnitOfWorkFactory();
builder.Services.AddProductService();
builder.Services.AddValidator();

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
