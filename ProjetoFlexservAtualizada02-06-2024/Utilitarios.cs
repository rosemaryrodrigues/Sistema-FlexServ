using System;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ProjetoFlexservTeste
{
    public static class Utilitarios
    {
        public static bool VerificarConexaoInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static ViaCepResponse ConsultarCep(string cep)
        {
            try
            {
                using (var client = new WebClient())
                {
                    string url = $"https://viacep.com.br/ws/{cep}/json/";
                    string json = client.DownloadString(url);
                    return JsonConvert.DeserializeObject<ViaCepResponse>(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao consultar o CEP: " + ex.Message);
            }
        }
    }
    public class ViaCepResponse
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
    }
}