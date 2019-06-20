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
        private List<Cliente> _clientes;

        public BancoDados()
        {
            _clientes = new List<Cliente>();
        }

        public void Add(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public void AddBatch(List<Cliente> clientes)
        {
            _clientes.AddRange(clientes);
        }

        public Cliente GetByID(int id)
        {
            return _clientes.Where(c => c.ID == id).FirstOrDefault();
        }

        public int Count() => _clientes.Count;
    }
}
