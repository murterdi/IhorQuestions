using AnimalManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//for cors if working in Local without s 
builder.Services.AddCors(option => option.AddPolicy(name: "FarmManagementUI",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }
    ));
builder.Services.AddMemoryCache();

//in-memory usage
builder.Services.AddSingleton<AnimalService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("FarmManagementUI");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
