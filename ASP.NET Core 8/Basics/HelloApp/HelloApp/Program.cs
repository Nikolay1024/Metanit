using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.UseWelcomePage();   // подключение WelcomePageMiddleware

//app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));

//app.Run(HandleRequst);

//int x = 2;
//app.Run(async (context) =>
//{
//    x = x * 2;  //  2 * 2 = 4
//    await context.Response.WriteAsync($"Result: {x}");
//});

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.Headers.ContentLanguage = "ru-RU";
//    response.Headers.ContentType = "text/plain; charset=utf-8";
//    response.Headers.Append("secret-id", "256");    // добавление кастомного заголовка
//    await response.WriteAsync("Привет METANIT.COM");
//});

//app.Run(async (context) =>
//{
//    context.Response.StatusCode = 404;
//    await context.Response.WriteAsync("Resource Not Found");
//});

app.Run(async (context) =>
{
    var response = context.Response;
    response.ContentType = "text/html; charset=utf-8";
    await response.WriteAsync("<h2>Hello METANIT.COM</h2><h3>Welcome to ASP.NET Core</h3>");
}); 

app.Run();


//async Task HandleRequst(HttpContext context)
//{
//    await context.Response.WriteAsync("Hello METANIT.COM 2", Encoding.Default);
//}
