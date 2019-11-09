using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RH.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;

namespace RH.Web.Services
{
    public class DAO
    {
        private string urlAPI;
        static HttpClient client;
        public DAO(string url)
        {
            urlAPI = url;
            client = new HttpClient();
        }

        public List<Funcionario> RetornaFuncionarios()
        {
            var dados = client.GetAsync(urlAPI + "/funcionario");
            if(dados.Result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Funcionario>>(dados.Result.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return null;
            }
        }

        public void Add(Funcionario funcionario)
        {
            client.PostAsJsonAsync<Funcionario>(urlAPI + "/funcionario",funcionario);
        }

        public Funcionario GetFuncionario(int id)
        {
            var dados = client.GetAsync(urlAPI + "/funcionario/"+id.ToString());
            if (dados.Result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Funcionario>(dados.Result.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return null;
            }
        }

        public void Update(Funcionario funcionario)
        {
            client.PutAsJsonAsync<Funcionario>(urlAPI + "/funcionario/"+funcionario.Codigo.ToString(), funcionario);
        }

        public void Delete(int id)
        {
            client.DeleteAsync(urlAPI + "/funcionario/" + id.ToString());
        }
    }
}
