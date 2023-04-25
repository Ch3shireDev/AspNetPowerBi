using AspNetPowerBi.Services;

namespace AspNetPowerBi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        if (builder.Environment.IsDevelopment())
        {
            
            builder.Configuration.AddUserSecrets<Program>();
        }
        
        var powerBISettings = builder
                .Configuration
                .GetSection("PowerBI")
                .Get<PowerBISettings>()
            ;

        var powerBiService = new PowerBiService(powerBISettings);
        builder.Services.AddSingleton(powerBiService);


        var app = builder.Build();

         
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            "default",
            "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}