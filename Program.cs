var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("LibraryAPI",
        new ()
        {
            Title = "Library API",
            Version = "1"
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(setupAction =>
{
    setupAction.SwaggerEndpoint(
        "/swagger/LibraryAPI/swagger.json",
        "Library API");
    setupAction.RoutePrefix = "";
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
