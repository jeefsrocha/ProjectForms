using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Integration.OperationAPI;

namespace OperationAPI
{
    public class AnalistaRH :Login
    {
        public async Task<String>? httpGet(string nome)
        {
            AnalistaRH obj = new AnalistaRH();

            string urlAPICreateToken = "https://pim44-api.victorgrferreir.repl.co/api/login";

            var dados = new
            {
                nome = nome,
            };

            string JsonObjeto = JsonConvert.SerializeObject(dados);

            var content = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");

            var resultado =  await obj.httpClient.PostAsync(urlAPICreateToken, content);
            

            if (resultado.IsSuccessStatusCode)
            {
                var tokenJson = resultado.Content.ReadAsStringAsync().Result;
                return JsonConvert.SerializeObject(tokenJson).ToString();
            }
            return null; // Não esquecer de lidar com a exeção.
        }



        public void httpGetID(string id)
        {
            var Token = Entrar(id, senha).ToString();

            using (var httpClient = new HttpClient())
            {
                string urlAPICreateToken = "https://pim44-api.victorgrferreir.repl.co/api/login/analistarh" + id;
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var response = httpClient.GetStringAsync(urlAPICreateToken);
                response.Wait();
                var retorno = JsonConvert.DeserializeObject<string>(response.Result).ToString();
            }
        }


        public void httpPost()
        {
            var Token = Entrar(id, senha).ToString();


            var jsonRefresh = JsonConvert.SerializeObject(Token);

            string urlAPICreateToken = "https://pim44-api.victorgrferreir.repl.co/api/AnalistaRH";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", Token);

                var response = httpClient.PostAsync(urlAPICreateToken, new StringContent(jsonRefresh, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                }
            }
        }



        public void httpPut(string id)
        {
            var Token = Entrar(id, senha).ToString();


            var jsonRefresh = JsonConvert.SerializeObject(Token);

            string urlAPICreateToken = "https://pim44-api.victorgrferreir.repl.co/api/AnalistaRH" + id;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", Token);

                var response = httpClient.PutAsync(urlAPICreateToken, new StringContent(jsonRefresh, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                }
            }
        }

        public void httpDelete(string id)
        {
            var Token = Entrar(id, senha).ToString();

            string urlAPIDeleteToken = "https://pim44-api.victorgrferreir.repl.co/api/AnalistaRH/" + id;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", Token);

                var response = httpClient.DeleteAsync(urlAPIDeleteToken).Result;

                if (response.IsSuccessStatusCode)
                {

                }
            }

        }



    }
}

   
