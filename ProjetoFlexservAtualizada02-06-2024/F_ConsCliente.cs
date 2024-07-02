using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ProjetoFlexservTeste
{
    public partial class F_ConsCliente : Form
    {

        DataTable dt = new DataTable();

        public F_ConsCliente()
        {

            InitializeComponent();
        }      
          private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_salvarAtera_Click(object sender, EventArgs e)
        {          
            Cliente u = new Cliente();
            u.id = Convert.ToInt32(tb_idCliente.Text);
            u.nome = tb_nomecliente.Text;
            u.cpfcnpj = tb_cpf.Text;
            u.datanasc = maskedDataNasc.Text;
            u.telefone = msktxtTelefone.Text;
            u.email = tb_email.Text;
            u.endereco = tb_endereco.Text;
            u.cep = msktxtCep.Text;
            u.numero = tb_numero.Text;
            u.bairro = tb_bairro.Text;
            u.cidade = tb_cidade.Text;

            Banco.AtualizarCliente(u);

            tb_nomecliente.Clear();
            tb_idCliente.Clear();
            tb_nomecliente.Clear();
            tb_cpf.Clear();
            maskedDataNasc.Clear();
            msktxtTelefone.Clear();
            tb_email.Clear();
            tb_endereco.Clear();
            msktxtCep.Clear();
            tb_numero.Clear();
            tb_bairro.Clear();
            tb_cidade.Clear();
            tb_nomecliente.Focus();
        }

        private void btn_novoCliente_Click(object sender, EventArgs e)
        {
            F_CadCliente f_CadCliente = new F_CadCliente();
            f_CadCliente.ShowDialog();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirma excluir Cliente?", "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Banco.DeletarCliente(tb_idCliente.Text);
                tb_nomecliente.Clear();
                tb_idCliente.Clear();
                tb_nomecliente.Clear();
                tb_cpf.Clear();
                maskedDataNasc.Clear();
                msktxtTelefone.Clear();
                tb_email.Clear();
                tb_endereco.Clear();
                msktxtCep.Clear();
                tb_numero.Clear();
                tb_bairro.Clear();
                tb_cidade.Clear();
                tb_nomecliente.Focus();


            }
        }

        private void btn_consultar_Click_1(object sender, EventArgs e)
        {
            string nomeCliente = tb_cpf.Text;           
            if (nomeCliente == "")
            {
                MessageBox.Show(" Entre com CPF ou CNPJ");
                tb_cpf.Focus();
                return;

            }
           
            string sql = "SELECT * FROM Cliente WHERE CpfCnpj='" + nomeCliente + "'";
            dt = Banco.consulta(sql);         
            
            if (dt.Rows.Count == 1)
            {
               
                tb_idCliente.Text = dt.Rows[0].Field<Int32>("Código").ToString();
                tb_nomecliente.Text = dt.Rows[0].Field<string>("Nome").ToString();
                maskedDataNasc.Text = dt.Rows[0].Field<string>("DataNasc").ToString();
                msktxtTelefone.Text = dt.Rows[0].Field<string>("Telefone").ToString();
                tb_email.Text = dt.Rows[0].Field<string>("Email").ToString();
                tb_endereco.Text = dt.Rows[0].Field<string>("Endereço").ToString();
                msktxtCep.Text = dt.Rows[0].Field<string>("Cep").ToString();
                tb_numero.Text = dt.Rows[0].Field<string>("Numero").ToString();
                tb_bairro.Text = dt.Rows[0].Field<string>("Bairro").ToString();
                tb_cidade.Text = dt.Rows[0].Field<string>("Cidade").ToString();
                
            }
            else
            {
                MessageBox.Show("Cliente não encontrado");
            }



        }




    }
}
        
       
 

