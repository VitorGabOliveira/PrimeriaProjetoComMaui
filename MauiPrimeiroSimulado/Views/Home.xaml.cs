using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MauiPrimeiroSimulado.Models;
using MauiPrimeiroSimulado.Service;

namespace MauiPrimeiroSimulado.Views;

public partial class Home : ContentPage
{
    public ObservableCollection<Produtos> produtos {  get; set; }
    private readonly ProdutoService _produtosService = new ProdutoService();
    public bool ehCadastro = true;
    public Home()
	{
		InitializeComponent();

        produtos = new ObservableCollection<Produtos>();
        BindingContext = this;

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CarregarProdutos();
    }

    private void OnItemTapped(object sender, TappedEventArgs e)
    {
        ehCadastro = false;
        if (e.Parameter is Produtos produtoSelecionado)
        {
            DisplayAlert("Produto Selecionado", produtoSelecionado.nomeProduto, "OK");
            Navigation.PushAsync(new CadastroProduto(ehCadastro, produtoSelecionado));
        }
    }

    

    private void AdicionarUsuario(object sender, EventArgs e)
    {
        ehCadastro = true;
        Navigation.PushAsync(new CadastroProduto(ehCadastro));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }


    public async Task CarregarProdutos()
    {
        try
        {
            var lista = await _produtosService.GetProdutosAsync();

            produtos.Clear();
            foreach (var p in lista)
                produtos.Add(p);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro ao carregar", ex.Message, "OK");
        }
    }

    private void CadastrarVenda_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Vendas());
    }

    private void telaTransacao_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AllTransacoes());
    }
}