using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace Loteria.Classes
{
    internal class Loterias
    {
        private readonly static HttpClient client = new();
        public string titulo { get; set; } = string.Empty;
        public List<string> Modalidade = new();

        public async Task GetListLoteriasAsync()
        {
            try
            {
                var response = await client.GetAsync("https://servicebus2.caixa.gov.br/portaldeloterias/api/loterias");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<List<Loterias>>(content);
                foreach (var loteria in json)
                {
                    Modalidade.Add(loteria.titulo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao obter a lista de loterias.\n {e}");
            }

        }

        public async Task<T> GetResultAsync<T>(string loteria)
        {
            try
            {
                var response = await client.GetAsync($"https://servicebus2.caixa.gov.br/portaldeloterias/api/{loteria}");


                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<T>(content);
                if (json != null)
                {
                    return json;
                }
                else
                {
                    throw new Exception("Dados não encontrados ou inválidos.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao obter os dados da {loteria}.\n {e}");
                return default;
            }
        }
    }
}
