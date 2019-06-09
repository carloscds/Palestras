using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace ExemploWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var conexao = new SqlConnection("data source=(local); initial catalog=northwind; integrated security=true;");
            var customer = conexao.Query<Customer>("select customerID, companyName from customers");
            dataGridView1.DataSource = customer;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
    }

}
