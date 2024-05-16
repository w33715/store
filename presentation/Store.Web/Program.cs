using Store;
using Store.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Корзина содержится в памяти
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); //Сессия длится 20 мин
    options.Cookie.HttpOnly = true; //обращение к кукам только из сервера
    options.Cookie.IsEssential = true; // кука-техническая информация, не личная
});
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<BookService, BookService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
