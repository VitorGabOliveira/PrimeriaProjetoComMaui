using MauiPrimeiroSimulado.Models;

namespace MauiPrimeiroSimulado.Views;

public partial class CadastroProduto : ContentPage
{

    public bool cadastro;
	public CadastroProduto(bool ehCadastro)
	{
		InitializeComponent();
        cadastro = ehCadastro;
        if (ehCadastro)
        {
            // exemplo de preencher os campos
            nomeProdutoEntry.Text = null;
            categoriaEntry.Text = null;
            precoEntry.Text = null;
            quantidadeEntry.Text = null;
        }

    }

    public CadastroProduto(bool ehCadastro, Produtos produto)
    {
        InitializeComponent();

        if (!ehCadastro)
        {
            nomeProdutoEntry.Text = produto.nomeProduto;
            categoriaEntry.Text = produto.categoria;
            precoEntry.Text = produto.preco.ToString();
            quantidadeEntry.Text = produto.quantidadeProduto.ToString();
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (cadastro)
        {
            tituloEntry.Text = "Cadastrar Produto";
        }
        else
        {
            tituloEntry.Text = "Editar Produto";
        }
    }


    public void VoltarParaHome(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }

    private async void CriarProduto(object sender, EventArgs e)
    {

        await DisplayAlert("Sucesso!", "Novo Produto cadastrado", "Ok");
        await Navigation.PopAsync();
    }
}