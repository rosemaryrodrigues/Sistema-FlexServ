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
    public partial class F_ConsVeiculo : Form
    {
        DataTable dt = new DataTable();
        public F_ConsVeiculo()
        {
            InitializeComponent();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string placa = tb_buscar.Text;
            if (placa == "")
            {
                MessageBox.Show(" Entre com Placa do Veículo");
                tb_buscar.Focus();
                return;

            }

            string sql = "SELECT * FROM Veiculo WHERE Placa='" + placa + "'";
            dt = Banco.consulta(sql);

            if (dt.Rows.Count == 1)
            {

                tb_idVeiculo.Text = dt.Rows[0].Field<Int32>("Código").ToString();
                tb_tipo.Text = dt.Rows[0].Field<string>("Tipo").ToString();
                tb_modelo.Text = dt.Rows[0].Field<string>("Modelo").ToString();
                tb_placa.Text = dt.Rows[0].Field<string>("Placa").ToString();
                tb_ano.Text = dt.Rows[0].Field<string>("Ano").ToString();
                tb_dono.Text = dt.Rows[0].Field<string>("Dono").ToString();
                tb_motorista.Text = dt.Rows[0].Field<string>("Motorista").ToString();
                tb_funionario.Text = dt.Rows[0].Field<Int32>("IdFuncionario").ToString();


            }
            else
            {
                MessageBox.Show("Veículo não encontrado");
            }



        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirma excluir Veículo?", "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Banco.DeletarVeiculo(tb_idVeiculo.Text);
            }
        }

        private void btn_salvarAtera_Click(object sender, EventArgs e)
        {
            Veiculo u = new Veiculo();
            u.id = Convert.ToInt32(tb_idVeiculo.Text);
            u.IdFuncionario = Convert.ToInt32(tb_funionario.Text);
            u.dono = tb_dono.Text;
            u.motorista = tb_motorista.Text;
            Banco.AtualizarVeiculo(u);
        }

        private void btn_novoVeiculo_Click(object sender, EventArgs e)
        {
            F_NovoVeiculo f_NovoVeiculo = new F_NovoVeiculo();
            f_NovoVeiculo.ShowDialog();
        }
    }
}
