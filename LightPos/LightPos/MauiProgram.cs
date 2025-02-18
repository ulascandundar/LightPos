using LightPos.Services;
using LightPos.Shared.Services;
using Microsoft.Extensions.Logging;
using LightPos.Infrastructure.Persistence;
using LightPos.Infrastructure.Mapping;
using MudBlazor.Services;
using LightPos.Application.Services;



#if WINDOWS
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI;
using Microsoft.UI.Windowing;
#endif
namespace LightPos
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the LightPos.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
#if WINDOWS
			builder.ConfigureLifecycleEvents(events =>
			{
				events.AddWindows(wndLifeCycleBuilder =>
				{
					wndLifeCycleBuilder.OnWindowCreated(window =>
					{
						IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
						WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);
						var _appWindow = AppWindow.GetFromWindowId(myWndId);
						_appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);
					});
				});
			});
#endif
			builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
			builder.Services.RegisterDb("");
			builder.Services.RegisterMapping();
			builder.Services.AddMudServices();
			builder.Services.RegisterService();

			var result = builder.Build();
			using (var scope = result.Services.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<LightPosDbContext>();
				context.Database.EnsureCreated();
                SeedService.InitializeData(context).GetAwaiter().GetResult();
			}
			return result;
        }
    }
}
