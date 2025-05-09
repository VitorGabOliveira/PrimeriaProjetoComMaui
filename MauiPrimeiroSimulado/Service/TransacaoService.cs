using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MauiPrimeiroSimulado.Models;
using Newtonsoft.Json;

namespace MauiPrimeiroSimulado.Service
{
    public class TransacaoService
    {
        private readonly HttpClient _httpClient;

        public TransacaoService()
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

        // GET api/Transacoes
        public async Task<List<Transacoes>> GetTransacoesAsync()
        {
            var response = await _httpClient.GetAsync("Transacoes");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Transacoes>>(json)!;
        }

        // GET api/Transacoes/{id}
        public async Task<Transacoes> GetTransacaoAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Transacoes/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Transacoes>(json)!;
        }

        // POST api/Transacoes
        public async Task<bool> PostTransacaoAsync(Transacoes transacao)
        {
            var json = JsonConvert.SerializeObject(transacao);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Transacoes", content);
            Console.WriteLine("testado");
            Console.WriteLine(json);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Erro ao salvar transação: {response.StatusCode} - {error}");
            }
            return response.IsSuccessStatusCode;
        }

        // PUT api/Transacoes/{id}
        public async Task<bool> PutTransacaoAsync(Transacoes transacao)
        {
            var json = JsonConvert.SerializeObject(transacao);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"Transacoes/{transacao.idTransacao}", content);
            return response.IsSuccessStatusCode;
        }

        // DELETE api/Transacoes/{id}
        public async Task<bool> DeleteTransacaoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Transacoes/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
