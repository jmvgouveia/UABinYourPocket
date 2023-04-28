namespace UABinYourPocket;

public partial class Perf : ContentPage
{
	public Perf()
	{
		InitializeComponent();
        BindingContext = new ViewModels.ProfileViewModel();

    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignInPage");
    }

    async void HomeButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignInPage");
    }

    
}
