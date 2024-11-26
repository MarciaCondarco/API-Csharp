using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

// Antes de criar a API, instalar no pacote de Nuget: Newtonsoft.Json 

// httpclient: usado para fazer requisições http, como get, post, put, delete.

//GetAsync: Método assincrono usado para fazer requisição Get.

//ReadAsStringAsync: lê a resposta da API como uma string.

//JsonConvert.DeserializeObject: Usado para converter o Json da resposta em um Objeto C#



//Quando você marca um método como async, o compilador permite o uso de await dentro dele, que é a palavra chave que indica onde o código deve esperar por uma opeação assincrona.

//quando usa o VOID: ele não retorna nenhu valor, ele apenas executa a ação de imprimir os dados, sempre depende de algum recurso para exibir algo.  EX: Console.Write


namespace API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //httpclient faz a criação da instância do httpclient

            HttpClient client = new HttpClient();


            //Defini a url do api o codigo abaixo
            string apiUrl = "https://github.com/carolstran/sailor-moon-api/blob/main/index.js";
            //try - enquanto se estiver o verdadeiro ele faz 
            try
            {
                //enviar uma requisição GET para a API
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                //Verificar se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    //Ler o conteúdo da resposta como uma string 
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    //Converter o Json para um objeto C# 
                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonResult);


                    Console.WriteLine("Resposta da API: ");
                    //Exibir o resultado 
                    //Console.WriteLine(jsonResult);

                    foreach (var produto in jsonObject)
                    {
                        Console.WriteLine($"\nNome: {produto.scouts.scoutName}");
                        //Console.WriteLine($"\nNome: {produto.title}" + $"Avaliação: {produto.rating.rate}");
                    }
                }
                else
                {
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            finally
            {
                //Fechar o HttpClient
                client.Dispose();
            }

        }
    }
}
