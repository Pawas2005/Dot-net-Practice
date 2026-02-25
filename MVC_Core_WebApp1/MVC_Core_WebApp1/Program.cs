using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello MiddleWare1");
    await next.Invoke();
    await context.Response.WriteAsync("\nHello MiddleWare............");
    await next.Invoke();
    await context.Response.WriteAsync("\n...............Hello MiddleWare............");
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("\nHello MiddleWare2");
    await next.Invoke();
});

app.Run(async context =>
{
    await context.Response.WriteAsync("\nHello MiddleWare3");
});

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
