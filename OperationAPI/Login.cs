using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OperationAPI;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Integration.OperationAPI
{   

   
    public class Login : Pessoa
    {
        public async Task<string> Entrar(string id, string senha)
        {
            string urlAPICreateToken = "https://pim44-api.victorgrferreir.repl.co/api/login";

            var dados = new
            {
                id = id,
                senha = senha,
            };

            string JsonObjeto = JsonConvert.SerializeObject(dados);

            var content = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");

            var resultado = await httpClient.PostAsync(urlAPICreateToken, content);

            if (resultado.IsSuccessStatusCode)
            {
                var tokenJson = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.SerializeObject(tokenJson).ToString();
            }
            else if (resultado.StatusCode == HttpStatusCode.BadRequest) // 400 Bad Request
            {
                System.Console.WriteLine("Erro 400");
            }
            else if (resultado.StatusCode == HttpStatusCode.Unauthorized) // 401 Unauthorized
            {
                System.Console.WriteLine("Entrada não autorizada");
            }
            else if (resultado.StatusCode == HttpStatusCode.Forbidden) // 403 Forbidden
            {
                System.Console.WriteLine("Requisição não autorizada");
            }
            else if (resultado.StatusCode == HttpStatusCode.NotFound) // 404 Not Found
            {
                System.Console.WriteLine("Resultado não encontrado");
            }
            else if (resultado.StatusCode == HttpStatusCode.InternalServerError) // 500 Internal Server Error
            {
                System.Console.WriteLine("Erro interno");
            }

            return null;
        }




        public async Task refreshToken()
        {
            var Token = Entrar(id, senha).ToString();


            var jsonRefresh = JsonConvert.SerializeObject(Token);

            string urlAPICreateToken = "https://pim44-api.victorgrferreir.repl.co/api/Login/refresh";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", Token);

                var response = await httpClient.PostAsync(urlAPICreateToken, new StringContent(jsonRefresh, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                }
            }
        }

        public async Task Startup()
        {
            var Token = Entrar(id, senha).ToString();


            var jsonRefresh = JsonConvert.SerializeObject(Token);

            string urlAPICreateToken = "https://pim44-api.victorgrferreir.repl.co/api/Login/startup";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", Token);

                var response = await httpClient.PostAsync(urlAPICreateToken, new StringContent(jsonRefresh, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                }
            }

        }

        public async Task mudarSenha()
        {
            var Token = Entrar(id, senha).ToString();


            var jsonRefresh = JsonConvert.SerializeObject(Token);

            string urlAPICreateToken = "https://pim44-api.victorgrferreir.repl.co/api/Login/mudarsenha";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", Token);

                var response = await httpClient.PutAsync(urlAPICreateToken, new StringContent(jsonRefresh, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                }
            }

        }

    }


}



