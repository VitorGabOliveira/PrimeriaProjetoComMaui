using MauiPrimeiroSimulado.Models;
using MauiPrimeiroSimulado.Service;

namespace MauiPrimeiroSimulado.Views;

public partial class Vendas : ContentPage
{

    private readonly ProdutoService _produtoService;
    private readonly TransacaoService _transacaoService;
    public int novoProdutoId;
    public string? tipoTransacao;
    public Vendas()
    {
        InitializeComponent();
        _transacaoService = new TransacaoService();
        _produtoService = new ProdutoService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            var produtos = await _produtoService.GetProdutosAsync();

            selectProduto.ItemsSource = produtos;
            selectProduto.ItemDisplayBinding = new Binding("nomeProduto");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao carregar produtos: {ex.Message}", "OK");
        }

        //Picker picker = new Picker { Title = "Select a monkey" };
        //picker.SetBinding(Picker.ItemsSourceProperty, static (Produtos pd) => pd.idProduto);
        //picker.ItemDisplayBinding = Binding.Create(static (Produtos pd) => pd.nomeProduto);
    }



    private void select_SelectedIndexChanged(object sender, EventArgs e)
    {

        var picker = (Picker)sender;
        tipoTransacao = picker.SelectedItem?.ToString();  
    }

    private void selectProduto_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var produtoSelecionado = (Produtos)picker.SelectedItem;

        if (produtoSelecionado != null)
        {
            novoProdutoId = produtoSelecionado.idProduto;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(tipoTransacao))
        {
            if (tipoTransacao != "venda" && tipoTransacao != "ajuste" && tipoTransacao != "compra")
            {
                await DisplayAlert("Transação Inválida", "Por favor, selecione um tipo válido de transação", "ok");
                return;
            }
        }
        string texto = quantidadeEntry.Text;
        if (!int.TryParse(texto, out int quantidade))
        {
            await DisplayAlert("Erro", "Digite um valor numérico válido para a quantidade.", "OK");
            return;
        }
        Transacoes novaTransacao = new Transacoes();
        novaTransacao.tipoTransacao = tipoTransacao;
        novaTransacao.quantidadeTransacao = quantidade;
        novaTransacao.produtoId = novoProdutoId;
        var ok = await _transacaoService.PostTransacaoAsync(novaTransacao);      
        if (!ok)
            await DisplayAlert("Erro", "Não foi possível salvar a transação.", "OK");

    }

    private void Sair_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}