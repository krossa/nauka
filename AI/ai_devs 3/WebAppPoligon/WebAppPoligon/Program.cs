using WebAppPoligon.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
//builder.Services.AddTransient<HttpClientLoggingHandler>();
//builder.Services.AddHttpClient<PoligonClient>(client =>
//{
//    client.BaseAddress = new Uri("https://poligon.aidevs.pl");
//    client.DefaultRequestHeaders.Add("Accept", "application/json");
//    //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
//}).AddHttpMessageHandler<HttpClientLoggingHandler>();
//builder.Services.AddTransient<IPoligonService, PoligonService>();

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
