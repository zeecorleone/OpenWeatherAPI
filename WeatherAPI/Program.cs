using WeatherAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

//configure named HttpClient
builder.Services.AddHttpClient("WeatherClient", client =>
{
	client.BaseAddress = new Uri("https://api.openweathermap.org/");
	client.DefaultRequestHeaders.Add("Accept", "application/json");

});

//Configure Typed HttpClient
builder.Services.AddHttpClient<IWeatherService, WeatherService>()
	.ConfigureHttpClient((serviceProvider, client) =>
	{
		client.BaseAddress = new Uri("https://api.openweathermap.org/");
		client.DefaultRequestHeaders.Add("Accept", "application/json");
	});

//OR:
//builder.Services.AddHttpClient<IWeatherService, WeatherService>(client =>
//{
//	client.BaseAddress = new Uri("https://api.openweathermap.org/");
//	client.DefaultRequestHeaders.Add("Accept", "application/json");
//});

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
