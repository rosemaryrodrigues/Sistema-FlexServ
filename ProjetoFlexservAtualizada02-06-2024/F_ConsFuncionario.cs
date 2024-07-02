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
    public partial class F_ConsFuncionario : Form
    {
        DataTable dt = new DataTable();
        public F_ConsFuncionario()
        {
            InitializeComponent();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_salvarAtera_Click(object sender, EventArgs e)
        {
            Funcionario u = new Funcionario();
            u.id = Convert.ToInt32(tb_idFuncionario.Text);
            u.nome = tb_nome.Text;
            u.cpf = tb_cpf.Text;
            u.datanasc = maskedDataNasc.Text;
            u.telefone = msktxtTelefone.Text;
            u.email = tb_email.Text;
            u.cargo = tb_cargo.Text;
            u.endereco = tb_endereco.Text;
            u.cep = msktxtCep.Text;
            u.numero = tb_numero.Text;
            u.bairro = tb_bairro.Text;
            u.cidade = tb_cidade.Text;
            u.salario = tb_salario.Text;
            

            Banco.AtualizarFuncionario(u);

            tb_nome.Clear();
            tb_idFuncionario.Clear();
            tb_nome.Clear();
            tb_cpf.Clear();
            maskedDataNasc.Clear();
            msktxtTelefone.Clear();
            tb_email.Clear();
            tb_cargo.Clear();
            tb_endereco.Clear();
            msktxtCep.Clear();
            tb_numero.Clear();
            tb_bairro.Clear();
            tb_cidade.Clear();
            tb_salario.Clear();
           
            tb_nome.Focus();

        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            string nomeFuncionario = tb_cpf.Text;
            if (nomeFuncionario == "")
            {
                MessageBox.Show(" Entre com CPF ");
                tb_cpf.Focus();
                return;

            }

            string sql = "SELECT * FROM Funcionario WHERE CPF='" + nomeFuncionario + "'";
            dt = Banco.consulta(sql);

            if (dt.Rows.Count == 1)
            {

                tb_idFuncionario.Text = dt.Rows[0].Field<Int32>("Código").ToString();
                tb_nome.Text = dt.Rows[0].Field<string>("Nome").ToString();
                maskedDataNasc.Text = dt.Rows[0].Field<string>("DataNasc").ToString();
                msktxtTelefone.Text = dt.Rows[0].Field<string>("Telefone").ToString();
                tb_email.Text = dt.Rows[0].Field<string>("Email").ToString();
                tb_cargo.Text = dt.Rows[0].Field<string>("Cargo").ToString();
                tb_endereco.Text = dt.Rows[0].Field<string>("Endereço").ToString();
                msktxtCep.Text = dt.Rows[0].Field<string>("Cep").ToString();
                tb_numero.Text = dt.Rows[0].Field<string>("Numero").ToString();
                tb_bairro.Text = dt.Rows[0].Field<string>("Bairro").ToString();
                tb_cidade.Text = dt.Rows[0].Field<string>("Cidade").ToString();
                tb_salario.Text = dt.Rows[0].Field<string>("Salario").ToString();
               

            }
            else
            {
                MessageBox.Show("Funcionário não encontrado");
            }

        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirma excluir Funcionário?", "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Banco.DeletarFuncionario(tb_idFuncionario.Text);
                tb_nome.Clear();
                tb_idFuncionario.Clear();
                tb_nome.Clear();
                tb_cpf.Clear();
                maskedDataNasc.Clear();
                msktxtTelefone.Clear();
                tb_email.Clear();
                tb_cargo.Clear();
                tb_endereco.Clear();
                msktxtCep.Clear();
                tb_numero.Clear();
                tb_bairro.Clear();
                tb_cidade.Clear();
                tb_salario.Clear();               
                tb_nome.Focus();


            }
        }

        private void btn_novoFuncionario_Click(object sender, EventArgs e)
        {
            F_CadFunc f_CadFunc = new F_CadFunc();
            f_CadFunc.ShowDialog();
        }
    }
}
