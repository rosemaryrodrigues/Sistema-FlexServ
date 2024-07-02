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
using Correios;
using Newtonsoft.Json;
using System.Net.Http;

namespace ProjetoFlexservTeste
{
    public partial class F_CadFrete : Form
    {
        DataTable dt = new DataTable();
        

        public F_CadFrete()
        {
            InitializeComponent();
        }
        private async void ConsultarCepEpreencherCampos(string cep, TextBox tbEndereco, TextBox tbBairro, TextBox tbCidade)
        {
            

            if (cep.Length == 8)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                        if (response.IsSuccessStatusCode)
                        {
                            var json = await response.Content.ReadAsStringAsync();
                            var endereco = JsonConvert.DeserializeObject<EnderecoViaCep>(json);

                            if (endereco != null)
                            {
                                tbEndereco.Text = endereco.Logradouro;
                                tbBairro.Text = endereco.Bairro;
                                tbCidade.Text = endereco.Localidade;
                                

                            }
                            else
                            {
                                MessageBox.Show("CEP não encontrado", "Atenção!", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Erro ao consultar o CEP", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao consultar o CEP: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void msktxtCepCole_TextChanged(object sender, EventArgs e)
        {
            ConsultarCepEpreencherCampos(msktxtCepCole.Text, tb_enderecoCole, tb_bairroCole, tb_cidadeCole);
        }
        private void msktxtCepCole1_TextChanged(object sender, EventArgs e)
        {
            ConsultarCepEpreencherCampos(msktxtCepCole1.Text, tb_enderecoCole1, tb_bairroCole1, tb_cidadeCole1);
        }
        private void msktxtCepEnt_TextChanged(object sender, EventArgs e)
        {
            ConsultarCepEpreencherCampos(msktxtCepEnt.Text, tb_enderecoEnt, tb_bairroEnt, tb_cidadeEnt);
        }
        public class EnderecoViaCep
        {
            public string Logradouro { get; set; }
            public string Bairro { get; set; }
            public string Localidade { get; set; }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nomeCliente = tb_cpf.Text;
            if (nomeCliente == "")
            {
                MessageBox.Show(" Entre com CPF ou CNPJ");
                tb_cpf.Focus();
                return;

            }
            string produto = cb_produto.Text;
            if (produto == "")
            {
                MessageBox.Show(" Produto vazio");
                cb_produto.Focus();
                return;

            }
            string tipo = cb_tipo.Text;
            if (tipo == "")
            {
                MessageBox.Show(" Veículo vazio");
                cb_tipo.Focus();
                return;

            }
            string qtdTotal = tb_qtdTotal.Text;
            if (qtdTotal == "")
            {
                MessageBox.Show(" Quantidade Total vazio");
                tb_qtdTotal.Focus();
                return;

            }
            string valor = tb_valor.Text;
            if (valor == "")
            {
                MessageBox.Show(" Valor vazio");
                tb_valor.Focus();
                return;

            }
            string numC = tb_numeroCole.Text; 
            if (numC == "")
            {
                MessageBox.Show(" Número coleta vazio");
                tb_numeroCole.Focus();
                return;

            }

            string qdt = tb_qdt.Text;
            if (qdt == "")
            {
                MessageBox.Show(" Quantidade Coleta vazio");
                tb_qdt.Focus();
                return;

            }
            string destinatario = tb_nomeDestino.Text;
            if (destinatario == "")
            {
                MessageBox.Show(" Destinatário vazio");
                tb_nomeDestino.Focus();
                return;

            }

            string numeE = tb_numeroEnt.Text;
            if (numeE == "")
            {
                MessageBox.Show(" Número Entrega vazio");
                tb_numeroEnt.Focus();
                return;

            }
            string sql = "SELECT * FROM Cliente WHERE CpfCnpj='" + nomeCliente + "'";
            dt = Banco.consulta(sql);
            if (dt.Rows.Count > 0)
            {
                tb_cpf.Text = dt.Rows[0].Field<string>("CpfCnpj").ToString();
                tb_nome.Text = dt.Rows[0].Field<string>("Nome").ToString();
            }
            else
            {
                
                MessageBox.Show("Cliente não encontrado. Não é possível cadastrar o frete.");
                tb_cpf.Focus();
                return;
            }

            {

                Frete frete = new Frete();
                frete.data = maskedData.Text;
                frete.hora = maskedHora.Text;
                frete.qtdtotal = tb_qtdTotal.Text;
                frete.tipoveiculo = cb_tipo.Text;
                frete.valor = tb_valor.Text;
                frete.cpfcnpj = tb_cpf.Text;
                frete.produto = cb_produto.Text;
                Banco.NovoFrete(frete);               
            }
            {
                try
                {
                    
                    string f = "SELECT TOP 1 Código FROM Frete ORDER BY Código DESC";
                    dt = Banco.consultaFrete(f);

                 
                    if (dt.Rows.Count > 0)
                    {
                        
                        int codigoFrete = dt.Rows[0].Field<int>("Código");

                        
                        tb_frete.Text = codigoFrete.ToString();
                        Coleta coleta = new Coleta();
                        coleta.endereco = tb_enderecoCole.Text;
                        coleta.cep = msktxtCepCole.Text;
                        coleta.numero = tb_numeroCole.Text;
                        coleta.bairro = tb_bairroCole.Text;
                        coleta.cidade = tb_cidadeCole.Text;
                        coleta.qtd = tb_qdt.Text;                        
                        coleta.idfrete = codigoFrete;                       
                        Banco.NovoColeta(coleta);

                       
                        tb_frete.Text = codigoFrete.ToString();                        
                        coleta.endereco = tb_enderecoCole1.Text;
                        coleta.cep = msktxtCepCole1.Text;
                        coleta.numero = tb_numeroCole1.Text;
                        coleta.bairro = tb_bairroCole1.Text;
                        coleta.cidade = tb_cidadeCole1.Text;
                        coleta.qtd = tb_qdt1.Text;
                        coleta.idfrete = codigoFrete;
                        Banco.NovoColeta(coleta);

                        Entrega entrega = new Entrega();
                        entrega.destinatario = tb_nomeDestino.Text;
                        entrega.endereco = tb_enderecoEnt.Text;
                        entrega.cep = msktxtCepEnt.Text;
                        entrega.numero = tb_numeroEnt.Text;
                        entrega.bairro = tb_bairroEnt.Text;
                        entrega.cidade = tb_cidadeEnt.Text;
                        entrega.idfrete = codigoFrete;
                        Banco.NovoEntrega(entrega);   
                        
                      
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
        }

        private void btnMais_Click(object sender, EventArgs e)
        {

           
            tb_enderecoCole1.Visible = true;
            tb_numeroCole1.Visible = true;
            msktxtCepCole1.Visible = true;
            tb_bairroCole1.Visible = true;
            tb_cidadeCole1.Visible = true;
            tb_qdt1.Visible = true;
            


            int margemHorizontal = 05; 
            int margemVertical = 210;   

            
            msktxtCepCole1.Left = 20;   
            msktxtCepCole1.Top = margemVertical;

            
            tb_enderecoCole1.Left = msktxtCepCole1.Right + margemHorizontal;
            tb_enderecoCole1.Top = margemVertical;
           
            tb_numeroCole1.Left = tb_enderecoCole1.Right + margemHorizontal;
            tb_numeroCole1.Top = margemVertical;
            
            tb_bairroCole1.Left = tb_numeroCole1.Right + margemHorizontal;
            tb_bairroCole1.Top = margemVertical;
            
            tb_cidadeCole1.Left = tb_bairroCole1.Right + margemHorizontal;
            tb_cidadeCole1.Top = margemVertical;
          
            tb_qdt1.Left = tb_cidadeCole1.Right + margemHorizontal;
            tb_qdt1.Top = margemVertical;


        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
        }

        private void btn_Etiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT TOP 1 Código FROM Frete ORDER BY Código DESC";
                dt = Banco.consulta(sql);

               
                if (dt.Rows.Count > 0)
                {
                    
                    int frete = dt.Rows[0].Field<int>("Código");

                   
                    F_etiqueta f_etiqueta = new F_etiqueta(frete.ToString(), tb_nomeDestino.Text, tb_enderecoEnt.Text, tb_numeroEnt.Text,
                        msktxtCepEnt.Text, tb_bairroEnt.Text, tb_cidadeEnt.Text);
                    f_etiqueta.Show();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel2.Text = DateTime.Now.ToShortTimeString();
            maskedData.Text= DateTime.Now.ToShortDateString();
            maskedHora.Text =DateTime.Now.ToShortTimeString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                       
        }

        private void btn_enviarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT TOP 1 Código FROM Frete ORDER BY Código DESC";
                dt = Banco.consulta(sql);

                
                if (dt.Rows.Count > 0)
                {
                    
                    int frete = dt.Rows[0].Field<int>("Código");



                   
                    F_enviarPedido f_enviarPedido = new F_enviarPedido(frete.ToString(), tb_cpf.Text, maskedData.Text, maskedHora.Text, tb_qtdTotal.Text
                        , cb_tipo.Text, tb_enderecoCole.Text, tb_numeroCole.Text, msktxtCepCole.Text, tb_bairroCole.Text, tb_cidadeCole.Text
                        , tb_qdt.Text, tb_nomeDestino.Text, tb_enderecoEnt.Text, tb_numeroEnt.Text, msktxtCepEnt.Text, tb_bairroEnt.Text, tb_cidadeEnt.Text
                        , tb_nome.Text, cb_produto.Text,tb_enderecoCole1.Text, tb_numeroCole1.Text, msktxtCepCole1.Text, tb_bairroCole1.Text, tb_cidadeCole1.Text
                        , tb_qdt1.Text);
                    f_enviarPedido.Show();
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

        private void msktxtCepCole_Leave(object sender, EventArgs e)
        {
            if (!Utilitarios.VerificarConexaoInternet())
            {
                MessageBox.Show("Sem conexão com a internet. Verifique suas configurações de rede.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(msktxtCepCole.Text))
            {
                MessageBox.Show("O campo de CEP está vazio", "Atenção!", MessageBoxButtons.OK);
                return;
            }

            try
            {
                var resposta = Utilitarios.ConsultarCep(msktxtCepCole.Text);

                if (resposta != null)
                {
                    tb_enderecoCole.Text = resposta.logradouro;
                    tb_bairroCole.Text = resposta.bairro;
                    tb_cidadeCole.Text = resposta.localidade;
                }
                else
                {
                    MessageBox.Show("CEP não encontrado", "Atenção!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void msktxtCepCole1_Leave(object sender, EventArgs e)
        {
            if (!Utilitarios.VerificarConexaoInternet())
            {
                MessageBox.Show("Sem conexão com a internet. Verifique suas configurações de rede.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(msktxtCepCole1.Text))
            {
                MessageBox.Show("O campo de CEP está vazio", "Atenção!", MessageBoxButtons.OK);
                return;
            }

            try
            {
                var resposta = Utilitarios.ConsultarCep(msktxtCepCole1.Text);

                if (resposta != null)
                {
                    tb_enderecoCole1.Text = resposta.logradouro;
                    tb_bairroCole1.Text = resposta.bairro;
                    tb_cidadeCole1.Text = resposta.localidade;
                }
                else
                {
                    MessageBox.Show("CEP não encontrado", "Atenção!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void msktxtCepEnt_Leave(object sender, EventArgs e)
        {
            if (!Utilitarios.VerificarConexaoInternet())
            {
                MessageBox.Show("Sem conexão com a internet. Verifique suas configurações de rede.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(msktxtCepEnt.Text))
            {
                MessageBox.Show("O campo de CEP está vazio", "Atenção!", MessageBoxButtons.OK);
                return;
            }

            try
            {
                var resposta = Utilitarios.ConsultarCep(msktxtCepEnt.Text);

                if (resposta != null)
                {
                    tb_enderecoEnt.Text = resposta.logradouro;
                    tb_bairroEnt.Text = resposta.bairro;
                    tb_cidadeEnt.Text = resposta.localidade;
                }
                else
                {
                    MessageBox.Show("CEP não encontrado", "Atenção!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
 }

