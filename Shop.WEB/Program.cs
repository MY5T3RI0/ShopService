using Microsoft.Extensions.Configuration;
using ShopApi.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var configuration = builder.Configuration;

builder.Services.AddHttpClient();
builder.Services.AddSingleton<Client>(sp =>
{
    var fact = sp.GetRequiredService<IHttpClientFactory>();
    var clnt = fact.CreateClient();
    return new Client(configuration.GetSection("ServiceAddress").Value, clnt);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
