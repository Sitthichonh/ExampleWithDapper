using ExampleWithDapper.ConnectionContext;
using ExampleWithDapper.Interfaces;
using ExampleWithDapper.Models;
using ExampleWithDapper.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IStatus, StatusRepository>();
builder.Services.AddScoped<IUserRoles, UserRoleRepository>();
builder.Services.AddScoped<IThaipost, ThaipostRepository>();
builder.Services.AddSingleton<SqlConnectionContext>();
builder.Services.AddControllers();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
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
app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();