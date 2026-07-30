
using _29july.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Controllers to the container
builder.Services.AddControllers();

// 2. Register IEmployeeService with Dependency Injection
// Using AddSingleton because your employees list is in-memory (static list)
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();

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

// 3. Map Controller routes
app.MapControllers();

app.Run();