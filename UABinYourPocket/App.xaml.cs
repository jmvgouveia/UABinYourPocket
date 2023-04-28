using Microsoft.Maui.Platform;
using UABinYourPocket.Handlers;


namespace UABinYourPocket;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();


        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(SemBordas), (handler, view) =>
        {
            if (view is SemBordas)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });



        MainPage = new AppShell();
            
	}
}

