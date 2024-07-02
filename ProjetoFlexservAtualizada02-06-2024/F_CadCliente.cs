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
using Newtonsoft.Json;
using System.Net.Http;

namespace ProjetoFlexservTeste
{
        public partial class F_CadCliente : Form
    {
        DataTable dt = new DataTable();
        public F_CadCliente()
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
                                // Outras informações que deseja obter...

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
        private void msktxtCep_TextChanged(object sender, EventArgs e)
        {
            ConsultarCepEpreencherCampos(msktxtCep.Text, tb_endereco, tb_bairro, tb_cidade);
        }
        public class EnderecoViaCep
        {
            public string Logradouro { get; set; }
            public string Bairro { get; set; }
            public string Localidade { get; set; }
            // Outros campos...
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

            tb_cpf.Clear();
            tb_nome.Clear();
            maskedDataNasc.Clear();
            msktxtTelefone.Clear();
            tb_email.Clear();
            tb_endereco.Clear();
            msktxtCep.Clear();
            tb_numero.Clear();
            tb_bairro.Clear();
            tb_cidade.Clear();            
            Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string cpfcnpj = tb_cpf.Text;

            if (cpfcnpj == "")
            {
                MessageBox.Show(" Inserir  o CPF ou CNPJ ");
                tb_cpf.Focus();
                return;
            }
            string nome = tb_nome.Text;
            if (nome == "")
            {
                MessageBox.Show(" Nome do Cliente vazio");
                tb_nome.Focus();
                return;

            }
           

            string sql = "SELECT * FROM Cliente WHERE CpfCnpj='" + cpfcnpj + "'";
            dt = Banco.consulta(sql);
           
            {
                Cliente cliente = new Cliente();
                cliente.nome = tb_nome.Text;
                cliente.cpfcnpj = tb_cpf.Text;
                cliente.datanasc = maskedDataNasc.Text;
                cliente.telefone = msktxtTelefone.Text;
                cliente.email = tb_email.Text;
                cliente.endereco = tb_endereco.Text;
                cliente.cep = msktxtCep.Text;
                cliente.numero = tb_numero.Text;
                cliente.bairro = tb_bairro.Text;
                cliente.cidade = tb_cidade.Text;
                Banco.NovoCliente(cliente);
                


            }
           


        }

        private void msktxtCep_Leave(object sender, EventArgs e)
        {
            if (!Utilitarios.VerificarConexaoInternet())
            {
                MessageBox.Show("Sem conexão com a internet. Verifique suas configurações de rede.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(msktxtCep.Text))
            {
                MessageBox.Show("O campo de CEP está vazio", "Atenção!", MessageBoxButtons.OK);
                return;
            }

            try
            {
                var resposta = Utilitarios.ConsultarCep(msktxtCep.Text);

                if (resposta != null)
                {
                    tb_endereco.Text = resposta.logradouro;
                    tb_bairro.Text = resposta.bairro;
                    tb_cidade.Text = resposta.localidade;
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

