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
    public partial class F_NovoUsuario : Form
    {
        DataTable dt = new DataTable();
        public F_NovoUsuario()
        {
            InitializeComponent();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text;

            if (username == "")
            {
                MessageBox.Show(" Inserir  o CPF ");
                tb_username.Focus();
                return;
            }
            string senha = tb_senha.Text;

            if (senha.Length < 8 || !senha.Any(char.IsUpper))
            {
                MessageBox.Show("A senha deve ter pelo menos 8 caracteres e conter pelo menos uma letra maiúscula.");
                tb_senha.Focus();
                return;
            }

            string sql = "SELECT * FROM Usuario WHERE USERNAME='" + username + "'";
            dt = Banco.consulta(sql);
            {
                Usuario usuario = new Usuario();
                usuario.nome = tb_nome.Text;
                usuario.username = tb_username.Text;
                usuario.senha = tb_senha.Text;
                usuario.status = cb_status.Text;
                usuario.nivel = Convert.ToInt32(Math.Round(n_nivel.Value, 0));
                Banco.NovoUsuario(usuario);

                tb_username.Clear();
                tb_nome.Clear();
                tb_senha.Clear();
                cb_status.Text = "";
                n_nivel.Value = 0;
                tb_username.Focus();


            }

        } 
       
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tb_nome.Clear();
            tb_username.Clear();
            tb_senha.Clear();
            cb_status.Text = "";
            n_nivel.Value = 0;
            tb_nome.Focus();

        }
    }
}
