namespace UABinYourPocket;

public partial class Registar : ContentPage
{
	public Registar()
	{
		InitializeComponent();
	}

    async void ButtonRegistar_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//Profile");
    }

    async void ButtonLogin_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignInPage");
    }
}
