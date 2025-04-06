using Microsoft.Extensions.FileProviders;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new StringBuilder("<table>");

//    foreach (var header in context.Request.Headers)
//    {
//        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

//app.Run(async (context) =>
//{
//    var acceptHeaderValue = context.Request.Headers.Accept;
//    await context.Response.WriteAsync($"Accept: {acceptHeaderValue}");
//});

//app.Run(async (context) =>
//{
//    var acceptHeaderValue = context.Request.Headers["accept"];
//    await context.Response.WriteAsync($"Accept: {acceptHeaderValue}");
//});

//app.Run(async (context) => await context.Response.WriteAsync($"Path: {context.Request.Path}"));

//app.Run(async (context) =>
//{
//    var path = context.Request.Path;
//    var now = DateTime.Now;
//    var response = context.Response;

//    if (path == "/date")
//        await response.WriteAsync($"Date: {now.ToShortDateString()}");
//    else if (path == "/time")
//        await response.WriteAsync($"Time: {now.ToShortTimeString()}");
//    else
//        await response.WriteAsync("Hello METANIT.COM");
//});

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
//        $"<p>QueryString: {context.Request.QueryString}</p>");
//});

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<h3>Параметры строки запроса</h3><table>");
//    stringBuilder.Append("<tr><td>Параметр</td><td>Значение</td></tr>");
//    foreach (var param in context.Request.Query)
//    {
//        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

//app.Run(async (context) =>
//{
//    string name = context.Request.Query["name"];
//    string age = context.Request.Query["age"];
//    await context.Response.WriteAsync($"{name} - {age}");
//});

//app.Run(async (context) => await context.Response.SendFileAsync("forest.png"));

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.SendFileAsync("html/index.html");
//});

//app.Run(async (context) =>
//{
//    var path = context.Request.Path;
//    var fullPath = $"html/{path}";
//    var response = context.Response;

//    response.ContentType = "text/html; charset=utf-8";
//    if (File.Exists(fullPath))
//    {
//        await response.SendFileAsync(fullPath);
//    }
//    else
//    {
//        response.StatusCode = 404;
//        await response.WriteAsync("<h2>Not Found</h2>");
//    }
//});

//app.Run(async (context) =>
//{
//    context.Response.Headers.ContentDisposition = "attachment; filename=my_forest.png";
//    await context.Response.SendFileAsync("forest.png");
//});

app.Run(async (context) =>
{
    var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
    IFileInfo fileInfo = fileProvider.GetFileInfo("forest.png");

    context.Response.Headers.ContentDisposition = "attachment; filename=my_forest.png";
    await context.Response.SendFileAsync(fileInfo);
});

app.Run();
