using DM.Module.Users.Extensions;
using DM.Modules.Tasks.Extensions;
using DM.Shared.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddUsersModule(builder.Configuration);
builder.Services.AddTasksModule(builder.Configuration);
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

app.UseSharedInfrastructure();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
