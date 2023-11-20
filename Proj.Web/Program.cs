using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proj.DataAccess.Data;
using Proj.DataAccess.Repository;
using Proj.DataAccess.Repository.IRepository;
using Proj.Web.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//--------- 1. Register DbContext --------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>
    (
        //options => options.SignIn.RequireConfirmedAccount = true
    )
    .AddEntityFrameworkStores<ApplicationDbContext>();


//--------- 2. Testing Services LifeTime --------------
builder.Services.AddSingleton<ISingleTonGuidService, SingleTonGuidService>();
builder.Services.AddScoped<IScopedGuidService, ScopedGuidService>();
builder.Services.AddTransient<ITransientGuidService, TransientGuidService>();

//--------- 3. Registrering Repositoriers -------------- so many Repository  complex
//builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
//builder.Services.AddScoped<IProductRepository,ProductRepository>();
//builder.Services.AddScoped<IProductRepository,ProductRepository>();
//builder.Services.AddScoped<IProductRepository,ProductRepository>();
//builder.Services.AddScoped<IProductRepository,ProductRepository>();

//--------- 4. Registrering IunitOfWork --------------
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //_____ For simpel Route ______
    //pattern: "{controller=Home}/{action=Index}/{id?}");

    //_____ For AreaBase Route ______
    //pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    //_____ For Fixedd AreaBase Route ______
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
