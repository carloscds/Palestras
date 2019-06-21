using System;
using System.Collections.Generic;
using ExemploProdutividade.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExemploProdutividade.Test
{
    [TestClass]
    public class ClientTest
    {
        BancoDados db;

        public ClientTest()
        {
            db = new BancoDados();
        }
        [TestMethod]
        public void AdicionaCliente_VerificaSeInseriu()
        {
            var cli = new Cliente() { ID = 6, Nome = "Antonio", Cidade = "NY" };
            db.Add(cli);
            var cliConsulta = db.GetByID(6);
            Assert.IsNotNull(cliConsulta);
        }

        [TestMethod]
        public void AdicionaVariosClientes_VerificaQuantidadeInserida()
        {
            var clientes = new List<Cliente>();
            clientes.Add(new Cliente() { ID = 1, Nome = "Carlos", Cidade = "CPP" });
            clientes.Add(new Cliente() { ID = 2, Nome = "Angelo", Cidade = "SP" });
            clientes.Add(new Cliente() { ID = 3, Nome = "Maria", Cidade = "NY" });
            clientes.Add(new Cliente() { ID = 4, Nome = "Pedro", Cidade = "SEA" });
            clientes.Add(new Cliente() { ID = 5, Nome = "Jose", Cidade = "CPP" });
            db.AddUmMontaoDeUmaVezSo_EmHomenagemAo_RafaelAlmeida(clientes);
            Assert.AreEqual(db.Count(), 5);
        }
    }
}
