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
    public partial class F_MaisColeta : Form
    {
        DataTable dt = new DataTable();
        public F_MaisColeta()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
           
            try
            {
                // Consulta para obter o último registro de frete no banco de dados
                string f = "SELECT TOP 1 Código FROM Frete ORDER BY Código DESC";
                dt = Banco.consultaFrete(f);

                // Verifica se há pelo menos uma linha retornada
                if (dt.Rows.Count > 0)
                {
                    // Recupera o valor do código do último frete registrado
                    int codigoFrete = dt.Rows[0].Field<int>("Código");                  
                   


                    // Exibe o código do frete no controle de caixa de texto
                    tb_IdFrete.Text = codigoFrete.ToString();
                    Coleta coleta = new Coleta();
                    coleta.endereco = tb_enderecoCole.Text;
                    coleta.cep = msktxtCepCole.Text;
                    coleta.numero = tb_numeroCole.Text;
                    coleta.bairro = tb_bairroCole.Text;
                    coleta.cidade = tb_cidadeCole.Text;
                    coleta.qtd = tb_qdt.Text;                    
                    coleta.idfrete = codigoFrete;
                    Banco.NovoColeta(coleta);
                    MessageBox.Show(" Coleta resgistrado  com sucesso!");
                   

                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar o código do frete.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            F_enviarPedido f_enviarPedido = new F_enviarPedido(tb_enderecoCole.Text);
            


        }
    }
}
