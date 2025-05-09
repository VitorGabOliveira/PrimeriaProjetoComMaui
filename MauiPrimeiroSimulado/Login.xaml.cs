namespace MauiPrimeiroSimulado;

using System.Threading.Tasks;
using MauiPrimeiroSimulado.Models;
using MauiPrimeiroSimulado.Service;
using MauiPrimeiroSimulado.Views;

public partial class Login : ContentPage
{
	private readonly UsuarioService usuarioService = new UsuarioService();
    List<Usuarios> user = new List<Usuarios>();
	public Login()
	{
		InitializeComponent();
       

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        btnLogin.IsEnabled = false;        
        await CarregarUsuarios();
        btnLogin.IsEnabled = true;
        
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
       
        await DisplayAlert("teste", user.Count().ToString(),"ok");
		await Navigation.PushAsync(new Home());
    }

    public async Task CarregarUsuarios()
    {
        user.Clear();
        var lista = await usuarioService.GetUsuariosAsync();
        foreach (var u in lista)
            user.Add(u);
    }
}