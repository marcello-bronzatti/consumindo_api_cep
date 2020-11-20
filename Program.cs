using Refit;
using System;
using System.Threading.Tasks;

namespace ExemploRefit
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.WriteLine("Informe seu cep: ");

                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultado informaçoes do CEP: "  + cepInformado);

                var addres = await cepClient.GetAddressAsync(cepInformado);

                Console.Write($"\nLogradouro: {addres.Logradouro},\nBairro: {addres.Bairro},\nCidade: {addres.Localidade}");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na consulta de CEP" + e.Message);
            }
        }
    }
}
