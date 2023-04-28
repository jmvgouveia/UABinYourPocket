namespace UABinYourPocket;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();

		BindingContext = new ViewModels.ProfileViewModel();
	}

    async void ButtonVoltar_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignInPage");
    }

    async void ButtonTeste_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//Registar");
    }
}