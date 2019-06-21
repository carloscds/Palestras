using ExemploProdutividade.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploProdutividade
{
    public class BancoDados
    {
        private readonly List<Cliente> _clientes;

        public BancoDados()
        {
            _clientes = new List<Cliente>();
        }

        public void Add(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public void AddUmMontaoDeUmaVezSo_EmHomenagemAo_RafaelAlmeida(List<Cliente> clientes)
        {
            _clientes.AddRange(clientes);
        }

        public Cliente GetByID(int id)
        {
            return _clientes.FirstOrDefault(c => c.ID == id);
        }

        public int Count() => _clientes.Count;
    }
}
