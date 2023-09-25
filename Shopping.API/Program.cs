using Shopping.Business.Abstract;
using Shopping.Business.Concrete;
using Shopping.DataAccess;
using Shopping.DataAccess.Abstract;
using Shopping.DataAccess.Concrete;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductService, ProductManager>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();


// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "All Products API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "All Products API");
});

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

app.MapControllers();

app.Run();