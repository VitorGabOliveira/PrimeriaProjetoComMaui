using System.Collections.ObjectModel;
using MauiPrimeiroSimulado.Models;
using MauiPrimeiroSimulado.Service;

namespace MauiPrimeiroSimulado.Views;

public partial class AllTransacoes : ContentPage
{
    public ObservableCollection<Transacoes> transacoes {  get; set; }
    private readonly TransacaoService _transacaoService = new TransacaoService();
	public AllTransacoes()
	{
		InitializeComponent();

        transacoes = new ObservableCollection<Transacoes>();
        BindingContext = this;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarTransacao();

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Transacoes transacaoSelecionada)
        {
            DisplayAlert("Produto Selecionado", transacaoSelecionada.produtoId.ToString(), "OK");
        }
    }

    public async Task CarregarTransacao()
    {
        try
        {
            var lista = await _transacaoService.GetTransacoesAsync();

            transacoes.Clear();
            foreach (var t in lista)
                transacoes.Add(t);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro ao carregar", ex.Message, "OK");
        }
    }
}