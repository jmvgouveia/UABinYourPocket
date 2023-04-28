namespace UABinYourPocket;

public partial class SignInPage : ContentPage
{
	public SignInPage()
    {
        InitializeComponent();

    }
    async void ButtonEntrar_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//Profile");

    }

    async void ButtonRegista_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//Registar");
    }

    async void ButtonPerfil_Clicked(System.Object sender, System.EventArgs e)
    {

        await Shell.Current.GoToAsync("//Perf");

    }

}