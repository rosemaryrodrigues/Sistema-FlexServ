using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFlexservTeste
{
    public partial class F_GestaoUsuario : Form
    {
        public F_GestaoUsuario()
        {
            InitializeComponent();
        }

        private void F_GestaoUsuario_Load(object sender, EventArgs e)
        {

            dgv_usuarios.DataSource = Banco.ObterUsuariosIdNome();
            dgv_usuarios.Columns[0].Width = 85;
            dgv_usuarios.Columns[1].Width = 190;
            
            this.usuarioTableAdapter.Fill(this.empresaFlexDataSet.Usuario);


        }

        private void btn_novoUsuario_Click(object sender, EventArgs e)
        {
            F_NovoUsuario f_NovoUsuario = new F_NovoUsuario();
            f_NovoUsuario.ShowDialog();
            dgv_usuarios.DataSource = Banco.ObterUsuariosIdNome();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_usuarios_SelectionChanged(object sender, EventArgs e)
        {


            DataGridView dvg =(DataGridView)sender;
            int contlinhas = dvg.SelectedRows.Count;
            if(contlinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dvg.SelectedRows[0].Cells[0].Value.ToString();
                dt = Banco.ObterDadosUsuario(vid);               
                tb_idUsuario.Text = dt.Rows[0].Field<Int32>("Código").ToString();
                tb_nome.Text = dt.Rows[0].Field<string>("Nome").ToString();
                tb_username.Text = dt.Rows[0].Field<string>("Username").ToString();
                tb_senha.Text = dt.Rows[0].Field<string>("Senha").ToString();
                cb_status.Text = dt.Rows[0].Field<string>("Status").ToString();
                tb_nome.Text = dt.Rows[0].Field<string>("Nome").ToString();
                nup_nivel.Value = dt.Rows[0].Field<Int32>("Nivel");
                              

            }
           
        }

        private void btn_salvarAtera_Click(object sender, EventArgs e)
        {

            int linha = dgv_usuarios.SelectedRows[0].Index;
            Usuario u = new Usuario();
            u.id = Convert.ToInt32(tb_idUsuario.Text);
            u.nome = tb_nome.Text;
            u.username = tb_username.Text;
            u.senha = tb_senha.Text;
            u.status = cb_status.Text;
            u.nivel = Convert.ToInt32(Math.Round(nup_nivel.Value,0));
            Banco.AtualizarUsuario(u);
            dgv_usuarios.DataSource = Banco.ObterUsuariosIdNome();
            dgv_usuarios.CurrentCell = dgv_usuarios[0, linha];
            MessageBox.Show("Atualizado!");
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirma excluir Usuário?","Excluir?", MessageBoxButtons.YesNo);
            if(res == DialogResult.Yes)
            {
                Banco.DeletarUsuario(tb_idUsuario.Text);
                dgv_usuarios.Rows.Remove(dgv_usuarios.CurrentRow);
               
            }
        }
    }
}
