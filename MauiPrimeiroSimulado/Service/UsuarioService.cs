using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiPrimeiroSimulado.Models;
using Newtonsoft.Json;

namespace MauiPrimeiroSimulado.Service
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService()
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

        public async Task<List<Usuarios>> GetUsuariosAsync()
        {
            var response = await _httpClient.GetAsync("Usuarios");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Usuarios>>(json);
        }
        public async Task<Usuarios> GetUsuariosAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Usuarios/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Usuarios>(json);
        }

        public async Task<bool> PostUsuariosAsync(Usuarios usuario)
        {
            var json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Usuarios", content);
            return response.IsSuccessStatusCode;

        }

        public async Task<bool> PutProdutosAsync(Usuarios usuario)
        {
            var json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"Produtos/{usuario.idUsuario}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProdutosAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Produtos/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
