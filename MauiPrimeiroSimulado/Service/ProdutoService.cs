using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiPrimeiroSimulado.Models;
using Newtonsoft.Json;

namespace MauiPrimeiroSimulado.Service;


public class ProdutoService
{
    private readonly HttpClient _httpClient;
    
    public ProdutoService()
    {
        _httpClient = new HttpClient
        {
            #if WINDOWS
                    BaseAddress = new Uri("http://localhost:5015/api/")
            #else
            BaseAddress = new Uri("http://10.0.2.2:5015/api/")
    #endif

        };
    }

    public async Task<List<Produtos>> GetProdutosAsync()
    {
        var response = await _httpClient.GetAsync("Produtos");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Produtos>>(json);  
    }
    public async Task<Produtos> GetProdutosAsync(int id)
    {
        var response = await _httpClient.GetAsync($"Produtos/{id}");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Produtos>(json);
    }

    public async Task<bool> PostProdutosAsync(Produtos produtos)
    {
        var json = JsonConvert.SerializeObject(produtos);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("Produtos", content);
        return response.IsSuccessStatusCode;

    }

    public async Task<bool> PutProdutosAsync(Produtos produtos)
    {
        var json = JsonConvert.SerializeObject(produtos);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"Produtos/{produtos.idProduto}", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProdutosAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Produtos/{id}");
        return response.IsSuccessStatusCode;
    }
}
