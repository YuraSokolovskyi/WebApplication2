var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Привіт користувач NET 6.0");

app.MapGet("/info", (HttpContext context) =>
{
    string queryString = context.Request.QueryString.ToString();
    if (queryString.Length > 0) queryString = queryString.Substring(1);
    return $"Host = {context.Request.Host.Host}:{context.Request.Host.Port}\n" +
        $"Path = {context.Request.Path.ToString().Substring(1)}\n" +
        $"QueryString = {queryString}";
});

app.MapGet("/time", (HttpContext context) =>
{
    return DateTime.Now.ToString();
});

app.MapGet("/key", (IConfiguration configuration) =>
{
    string keyValue = configuration["Key"];
    return $"Значення ключа: {keyValue}";
});

app.Run();
