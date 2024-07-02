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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            F_Login f_Login = new F_Login(this);
            f_Login.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel2.Text = DateTime.Now.ToShortTimeString();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //////desativado não esta em uso cancelado 
        }

        private void gestãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel >= 2)
                {
                    ///PROCEDIMENTOS DO PROGRAMAS
                    F_GestaoUsuario f_GestaoUsuario = new F_GestaoUsuario();
                    f_GestaoUsuario.ShowDialog();

               }
               else
               {
                  MessageBox.Show("Acesso não permitido");
               }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        private void funcionaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                 if (Globais.nivel >= 2)
                 {
                           

                 }
                 else
                 {
                     MessageBox.Show("Acesso não permitido");
                 }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                 if (Globais.nivel >= 2)
                 {
                
               
                  }
                 else
                 {
                     MessageBox.Show("Acesso não permitido");
                 }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        private void logonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Login f_Login = new F_Login(this);
            f_Login.ShowDialog();
        }

        private void logolfToolStripMenuItem_Click(object sender, EventArgs e)
        {
           lb_acesso.Text = "0";
           lb_nomeUsuario.Text = "---";
           pb_ledLogado.Image = Properties.Resources.led_vermelho;
           Globais.nivel = 0;
           Globais.logado = false;
        }

        private void cadastroFreteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel == 1 || Globais.nivel == 2)
                {
                   
                    F_CadFrete f_CadFrete = new F_CadFrete();
                    f_CadFrete.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }


        }

        private void cadastrarFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel >= 2)
                {
                   
                    F_CadFunc f_CadFunc = new F_CadFunc();
                    f_CadFunc.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        private void consultarFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel >= 2)
                {
                   
                    F_ConsFuncionario f_ConsFuncionario = new F_ConsFuncionario();
                    f_ConsFuncionario.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        private void consultarFreteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_ConsFrete f_ConsFrete = new F_ConsFrete();
            f_ConsFrete.ShowDialog();
        }

        private void freteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel == 0 || Globais.nivel == 2)
                {
                    
                    F_Relatorio f_Relatorio = new F_Relatorio();
                    f_Relatorio.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        private void consultarVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel == 0 || Globais.nivel == 2)
                {
                    
                    F_ConsVeiculo f_ConsVeiculo = new F_ConsVeiculo();
                    f_ConsVeiculo.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        private void cadastroVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel == 0 || Globais.nivel == 2)
                {
                   
                    F_NovoVeiculo f_NovoVeiculo = new F_NovoVeiculo();
                    f_NovoVeiculo.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        private void statusFreteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /////desativado não esta em uso cancelado 
        }

        private void realizarEntregaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel == 0 || Globais.nivel == 2)
                {
                    
                    F_RealizarEntrega f_RealizarEntrega = new F_RealizarEntrega();
                    f_RealizarEntrega.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel == 1 || Globais.nivel == 2)
                {
                    
                    F_CadCliente f_CadCliente = new F_CadCliente();
                    f_CadCliente.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                if (Globais.nivel == 1 || Globais.nivel == 2)
                {
                    
                    F_ConsCliente f_ConsCliente = new F_ConsCliente();
                    f_ConsCliente.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Acesso não permitido");
                }
            }
            else
            {
                MessageBox.Show("É necessário ter um usuário logado");
            }
        }
    }
}
