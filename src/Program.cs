using OsintApiSearch;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Picsart
builder.Services.AddHttpClient<IPicsartService, PicsartService>(client =>
{
    client.BaseAddress = new Uri("https://api.picsart.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// NetShoes
builder.Services.AddHttpClient<INetShoesService, NetShoesService>(client =>
{
    client.BaseAddress = new Uri("https://www.netshoes.com.br/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Xwitter
builder.Services.AddHttpClient<IXwitterService, XwitterService>(client =>
{
    client.BaseAddress = new Uri("https://api.twitter.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Spotify
builder.Services.AddHttpClient<ISpotifyService, SpotifyService>(client =>
{
    client.BaseAddress = new Uri("https://spclient.wg.spotify.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Chess
builder.Services.AddHttpClient<ISpotifyService, SpotifyService>(client =>
{
    client.BaseAddress = new Uri("https://www.chess.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
