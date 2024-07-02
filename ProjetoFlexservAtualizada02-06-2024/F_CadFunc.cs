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
    public partial class F_CadFunc : Form
    {
        DataTable dt = new DataTable();
        public F_CadFunc()
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
        private void msktxtCep_TextChanged(object sender, EventArgs e)
        {
            ConsultarCepEpreencherCampos(msktxtCep.Text, tb_endereco, tb_bairro, tb_cidade);
        }
        public class EnderecoViaCep
        {
            public string Logradouro { get; set; }
            public string Bairro { get; set; }
            public string Localidade { get; set; }
           
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string cpf = tb_cpf.Text;

            if (cpf == "")
            {
                MessageBox.Show("Inserir o CPF");
                tb_cpf.Focus();
                return;
            }

            try
            {
                string sql = "SELECT * FROM Funcionario WHERE CPF='" + cpf + "'";
                dt = Banco.consulta(sql);

                
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.nome = tb_nome.Text;
                    funcionario.cpf = tb_cpf.Text;
                    funcionario.datanasc = maskedDataNasc.Text;
                    funcionario.telefone = msktxtTelefone.Text;
                    funcionario.email = tb_email.Text;
                    funcionario.endereco = tb_endereco.Text;
                    funcionario.cargo = tb_cargo.Text;
                    funcionario.cep = msktxtCep.Text;
                    funcionario.numero = tb_numero.Text;
                    funcionario.bairro = tb_bairro.Text;
                    funcionario.cidade = tb_cidade.Text;
                    funcionario.salario = tb_salario.Text;

                    Banco.NovoFuncionario(funcionario);
                    
                }
                
            }
            catch (Exception ex)
            {
               
            }
        

    }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
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
