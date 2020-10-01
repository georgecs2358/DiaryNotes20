using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blazored.Modal;
using ElectronNET.API;
using ElectronNET.API.Entities;

namespace DiaryNotes20
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method is called by the runtime; adds required services
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddRazorPages();
      services.AddServerSideBlazor();
      services.AddBlazoredModal();
    }

    // This method gets called by the runtime and creates the app window
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      } else {
        app.UseExceptionHandler("/Error");
      }

      app.UseStaticFiles();

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapBlazorHub();
        endpoints.MapFallbackToPage("/_Host");
      });

      if (HybridSupport.IsElectronActive)
      {
        ElectronBootstrap();
      }
      // Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());
    }

    public async void ElectronBootstrap()
    {
      var browserWindow = await Electron.WindowManager.CreateWindowAsync(
        new BrowserWindowOptions { Width = 950, Height = 700, Show = false }
      );

      await browserWindow.WebContents.Session.ClearCacheAsync();
      browserWindow.OnReadyToShow += () => browserWindow.Show();
      browserWindow.SetTitle("DiaryNotes 20");
    }
  }
}
