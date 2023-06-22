using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Services.Repositories
{
    public static class DollarExchangeApi
    {
        internal class CurrencyInfo
        {
            public string Code { get; set; }
            public string Codein { get; set; }
            public string Name { get; set; }
            public string High { get; set; }
            public string Low { get; set; }
            public string VarBid { get; set; }
            public string PctChange { get; set; }
            public string Bid { get; set; }
            public string Ask { get; set; }
            public string Timestamp { get; set; }
            public string CreateDate { get; set; }
        }

        internal class Currency
        {
            public CurrencyInfo USDBRL { get; set; }
        }

        public static async Task<string> GetDollarToday()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Fazer a requisição GET para a API
                    HttpResponseMessage response = await client.GetAsync("https://economia.awesomeapi.com.br/last/USD-BRL");

                    // Verificar se a requisição foi bem-sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        // Ler a resposta como uma string
                        string responseBody = await response.Content.ReadAsStringAsync();

                        var dollar = JsonConvert.DeserializeObject<Currency>(responseBody);

                        return dollar.USDBRL.Bid;
                    }
                    else
                    {
                        throw new Exception($"A requisição falhou com o código de status: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocorreu um erro na requisição: {ex.Message}");
                }
            }
        }
    }
}
