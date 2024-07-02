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
    public partial class F_NovoVeiculo : Form
    {
        DataTable dt = new DataTable();
        public F_NovoVeiculo()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Veiculo";
            dt = Banco.consulta(sql);
            {
                Veiculo veiculo = new Veiculo();
                veiculo.tipo = tb_tipo.Text;
                veiculo.modelo = tb_modelo.Text;
                veiculo.placa = tb_placa.Text;
                veiculo.ano = tb_ano.Text;
                veiculo.dono = tb_dono.Text;
                veiculo.motorista = tb_motorista.Text;
                veiculo.IdFuncionario = Convert.ToInt32(tb_IdFuncionario.Text);
                Banco.NovoVeiculo(veiculo);
               
                tb_tipo.Clear();
                tb_modelo.Clear();
                tb_placa.Clear();
                tb_ano.Clear();
                tb_dono.Clear();
                tb_motorista.Clear();
                tb_IdFuncionario.Clear();
                tb_dono.Focus();
            }
        }
    }
}

