using ExemploProdutividade.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploProdutividade
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BancoDados();

            var clientes = new List<Cliente>();
            clientes.Add(new Cliente() { ID = 1, Nome = "Carlos", Cidade = "CPP" });
            clientes.Add(new Cliente() { ID = 2, Nome = "Angelo", Cidade = "SP" });
            clientes.Add(new Cliente() { ID = 3, Nome = "Maria", Cidade = "NY" });
            clientes.Add(new Cliente() { ID = 4, Nome = "Pedro", Cidade = "SEA" });
            clientes.Add(new Cliente() { ID = 5, Nome = "Jose", Cidade = "CPP" });
            db.AddUmMontaoDeUmaVezSo_EmHomenagemAo_RafaelAlmeida(clientes);

            var cli = new Cliente() { ID = 6, Nome = "Antonio", Cidade = "NY" };
            db.Add(cli);
            var cliConsulta = db.GetByID(6);
        }
    }
}
