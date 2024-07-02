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
using System.Globalization;

namespace ProjetoFlexservTeste
{
    public partial class F_Relatorio : Form
    {
        private DataTable dt;       
        private BindingSource fretebindingSource;
        
        public F_Relatorio()
        {
            InitializeComponent();
            dt = new DataTable();            
            fretebindingSource = new BindingSource();
            

        }

        private void F_Relatorio_Load(object sender, EventArgs e)
        {
            
            this.freteTableAdapter.Fill(this.empresaFlexDataSet5.Frete);

            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 95;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[7].Width = 170;
            dataGridView1.Columns[8].Width = 80;
            dataGridView1.Columns[9].Width = 110;
            dataGridView1.Columns[10].Width = 110;
                 
           
           
            fretebindingSource.DataSource = this.empresaFlexDataSet5.Frete;
            dataGridView1.DataSource = fretebindingSource;
            
            dt = ((DataView)fretebindingSource.List).Table.Copy();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            
            if (radioButtonMes.Checked)
            {
                
                FiltrarGrade("Mes");
            }
            else if (radioButtonDia.Checked)
            {
                
                FiltrarGrade("Dia");
            }
           
            else
            {
                
                MessageBox.Show("Por favor, selecione uma opção de busca (Mês ou Dia).", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarGrade(string tipoBusca)
        {

            
            LimparResultadosAnteriores();

            
            if (DateTime.TryParse(maskedData.Text, out DateTime selectedDate))
            {
                
                string filterExpression;
                if (tipoBusca == "Mes")
                {
                    filterExpression = $"Data LIKE '%/{selectedDate.Month:D2}/{selectedDate.Year}'";
                }
                else if (tipoBusca == "Dia")
                {
                    filterExpression = $"Data = '{selectedDate.ToString("dd/MM/yyyy")}'";
                }
                else
                {
                    
                    MessageBox.Show("Tipo de busca inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    ((DataTable)fretebindingSource.DataSource).DefaultView.RowFilter = filterExpression;

                    
                    dataGridView1.Refresh();
                    
                    CalcularEExibirInformacoesAdicionais();
                    
                    CalcularEExibirInformacoesAdicionaisColeta();


                    
                    Dictionary<int, int> quantidadeFretesPorVeiculo = new Dictionary<int, int>();

                   
                    Dictionary<string, int> quantidadeFretesPorCliente = new Dictionary<string, int>();

                    
                    Dictionary<string, int> quantidadeProdutosPorCategoria = new Dictionary<string, int>();

                    
                    int totalFretesNoMes = 0;
                    
                    int totalProdutos = 0;

                    
                    int quantidadePessoaFisica = 0;
                    int quantidadePessoaJuridica = 0;
                    foreach (DataRowView row in ((DataTable)fretebindingSource.DataSource).DefaultView)
                    {
                        int idVeiculo = Convert.ToInt32(row["idVeiculo"]);
                        string cpfCnpj = row["CpfCnpj"].ToString();
                        string nomeProduto = row["Produto"].ToString();

                       
                        if (cpfCnpj.Length <= 15)
                        {
                           
                            quantidadePessoaFisica++;
                        }
                        else
                        {
                            
                            quantidadePessoaJuridica++;
                        }


                        if (quantidadeFretesPorVeiculo.ContainsKey(idVeiculo))
                        {
                            quantidadeFretesPorVeiculo[idVeiculo]++;
                        }
                        else
                        {
                            quantidadeFretesPorVeiculo[idVeiculo] = 1;
                        }

                        if (quantidadeFretesPorCliente.ContainsKey(cpfCnpj))
                        {
                            quantidadeFretesPorCliente[cpfCnpj]++;
                        }
                        else
                        {
                            quantidadeFretesPorCliente[cpfCnpj] = 1;
                        }
                       
                        if (quantidadeProdutosPorCategoria.ContainsKey(nomeProduto))
                        {
                            quantidadeProdutosPorCategoria[nomeProduto]++;
                        }
                        else
                        {
                            quantidadeProdutosPorCategoria[nomeProduto] = 1;
                        }

                        totalFretesNoMes++;
                        totalProdutos++;
                    }
                    
                    lb_fisica.Text = quantidadePessoaFisica.ToString();
                    lb_juridica.Text = quantidadePessoaJuridica.ToString();

                    
                    var resultadosOrdenadosVeiculos = quantidadeFretesPorVeiculo.OrderByDescending(x => x.Value);

                   
                    int contadorVeiculos = 0;
                    foreach (var resultado in resultadosOrdenadosVeiculos)
                    {
                        if (contadorVeiculos < 7) 
                        {
                            switch (contadorVeiculos)
                            {
                                case 0:
                                    lb_veiculo.Text = resultado.Key.ToString();
                                    lb_veiculofrete.Text = resultado.Value.ToString();
                                    break;
                                case 1:
                                    lb_veiculo1.Text = resultado.Key.ToString();
                                    lb_veiculofrete1.Text = resultado.Value.ToString();
                                    break;
                                case 2:
                                    lb_veiculo2.Text = resultado.Key.ToString();
                                    lb_veiculofrete2.Text = resultado.Value.ToString();
                                    break;
                                case 3:
                                    lb_veiculo3.Text = resultado.Key.ToString();
                                    lb_veiculofrete3.Text = resultado.Value.ToString();
                                    break;
                                case 4:
                                    lb_veiculo4.Text = resultado.Key.ToString();
                                    lb_veiculofrete4.Text = resultado.Value.ToString();
                                    break;
                                case 5:
                                    lb_veiculo5.Text = resultado.Key.ToString();
                                    lb_veiculofrete5.Text = resultado.Value.ToString();
                                    break;
                                case 6:
                                    lb_veiculo6.Text = resultado.Key.ToString();
                                    lb_veiculofrete6.Text = resultado.Value.ToString();
                                    break;
                                    
                            }
                            contadorVeiculos++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    var resultadosOrdenadosProdutos = quantidadeProdutosPorCategoria.OrderByDescending(x => x.Value);

                    
                    List<string> nomesProdutos = new List<string> { "Diversos", "Calçados", "Roupa", "Informática", "Celulares", "Eletrodomésticos" };

                    
                    int contadorProdutos = 0;
                    foreach (var resultado in resultadosOrdenadosProdutos)
                    {
                        if (contadorProdutos < 6) 
                        {
                            switch (contadorProdutos)
                            {
                                case 0:
                                    lb_produto1.Text = resultado.Key;
                                    lb_produto1Q.Text = resultado.Value.ToString();
                                    break;
                                case 1:
                                    lb_produto2.Text = resultado.Key;
                                    lb_produto2Q.Text = resultado.Value.ToString();
                                    break;
                                case 2:
                                    lb_produto3.Text = resultado.Key;
                                    lb_produto3Q.Text = resultado.Value.ToString();
                                    break;
                                case 3:
                                    lb_produto4.Text = resultado.Key;
                                    lb_produto4Q.Text = resultado.Value.ToString();
                                    break;
                                case 4:
                                    lb_produto5.Text = resultado.Key;
                                    lb_produto5Q.Text = resultado.Value.ToString();
                                    break;
                                case 5:
                                    lb_produto6.Text = resultado.Key;
                                    lb_produto6Q.Text = resultado.Value.ToString();
                                    break;
                                    
                            }
                            contadorProdutos++;
                        }
                        else
                        {
                            break;
                        }
                    }

                   
                    var resultadosOrdenadosClientes = quantidadeFretesPorCliente.OrderByDescending(x => x.Value);

                   
                    int contadorClientes = 0;
                    foreach (var resultado in resultadosOrdenadosClientes)
                    {
                        if (contadorClientes < 10) 
                        {
                            switch (contadorClientes)
                            {
                                case 0:
                                    lb_nomeCliente.Text = ConsultarNomeCliente(resultado.Key); 
                                    lb_totalCliente.Text = resultado.Value.ToString(); 
                                    lb_cnpjCnpj.Text = resultado.Key; 
                                    break;
                                case 1:
                                    lb_nomeCliente1.Text = ConsultarNomeCliente(resultado.Key); 
                                    lb_totalCliente1.Text = resultado.Value.ToString(); 
                                    lb_cnpjCnpj1.Text = resultado.Key; 
                                    break;
                                case 2:
                                    lb_nomeCliente2.Text = ConsultarNomeCliente(resultado.Key); 
                                    lb_totalCliente2.Text = resultado.Value.ToString(); 
                                    lb_cnpjCnpj2.Text = resultado.Key; 
                                    break;
                                case 3:
                                    lb_nomeCliente3.Text = ConsultarNomeCliente(resultado.Key); 
                                    lb_totalCliente3.Text = resultado.Value.ToString(); 
                                    lb_cnpjCnpj3.Text = resultado.Key; 
                                    break;
                                case 4:
                                    lb_nomeCliente4.Text = ConsultarNomeCliente(resultado.Key); 
                                    lb_totalCliente4.Text = resultado.Value.ToString(); 
                                    lb_cnpjCnpj4.Text = resultado.Key; 
                                    break;
                                case 5:
                                    lb_nomeCliente5.Text = ConsultarNomeCliente(resultado.Key); 
                                    lb_totalCliente5.Text = resultado.Value.ToString(); 
                                    lb_cnpjCnpj5.Text = resultado.Key; 
                                    break;
                                case 6:
                                    lb_nomeCliente6.Text = ConsultarNomeCliente(resultado.Key); 
                                    lb_totalCliente6.Text = resultado.Value.ToString(); 
                                    lb_cnpjCnpj6.Text = resultado.Key; 
                                    break;
                                case 7:
                                    lb_nomeCliente7.Text = ConsultarNomeCliente(resultado.Key); 
                                    lb_totalCliente7.Text = resultado.Value.ToString(); 
                                    lb_cnpjCnpj7.Text = resultado.Key; 
                                    break;
                                case 8:
                                    lb_nomeCliente8.Text = ConsultarNomeCliente(resultado.Key); 
                                    lb_totalCliente8.Text = resultado.Value.ToString(); 
                                    lb_cnpjCnpj8.Text = resultado.Key; 
                                    break;
                                case 9:
                                    lb_nomeCliente9.Text = ConsultarNomeCliente(resultado.Key); 
                                    lb_totalCliente9.Text = resultado.Value.ToString(); 
                                    lb_cnpjCnpj9.Text = resultado.Key; 
                                    break;
                               
                               
                                    
                            }
                            contadorClientes++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    
                    lb_total.Text = totalFretesNoMes.ToString();

                    
                    decimal valorTotalFretes = 0;
                    foreach (DataRowView row in ((DataTable)fretebindingSource.DataSource).DefaultView)
                    {
                        if (row["Valor"] != DBNull.Value)
                        {
                            valorTotalFretes += Convert.ToDecimal(row["Valor"]);
                        }
                    }

                   
                    lb_valor_total.Text = valorTotalFretes.ToString("C2");

                    
                    ConsultarMotoristas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao aplicar o filtro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira uma data válida no formato MM/yyyy.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalcularEExibirInformacoesAdicionais()
        {
            
            Dictionary<string, int> quantidadeFretesPorCidade = new Dictionary<string, int>();

            

            
            foreach (DataRowView row in ((DataTable)fretebindingSource.DataSource).DefaultView)
            {
                
                int codigoFrete = Convert.ToInt32(row["Código"]); 

               
                string sql = $"SELECT Cidade FROM Entrega WHERE IdFrete = {codigoFrete}";
                DataTable dt = Banco.consulta(sql);


                
                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    string cidade = dt.Rows[0]["Cidade"].ToString();
                    if (quantidadeFretesPorCidade.ContainsKey(cidade))
                    {
                        quantidadeFretesPorCidade[cidade]++;
                    }
                    else
                    {
                        quantidadeFretesPorCidade[cidade] = 1;
                    }
                }
            }

            
            string cidadeMaisFretes = "";
            string cidadeMenosFretes = "";
            int maxFretes = 0;
            int minFretes = int.MaxValue;

            foreach (var kvp in quantidadeFretesPorCidade)
            {
                if (kvp.Value > maxFretes)
                {
                    maxFretes = kvp.Value;
                    cidadeMaisFretes = kvp.Key;
                }

                if (kvp.Value < minFretes)
                {
                    minFretes = kvp.Value;
                    cidadeMenosFretes = kvp.Key;
                }
            }

            
            lb_cidadeMaior.Text = $"{cidadeMaisFretes} ({maxFretes} fretes)";
            lb_cidadeMenor.Text = $"{cidadeMenosFretes} ({minFretes} fretes)";

            
        }
        private string ConsultarNomeCidade(string nomeCidade)
    {
        try
        {
        
        string sql = $"SELECT NomeCidade FROM Cidade WHERE NomeCidade = '{nomeCidade}'";
        DataTable dt = Banco.consulta(sql);

                if (dt.Rows.Count == 1)
                {
                    
                    return dt.Rows[0]["NomeCidade"].ToString();
                }
               
                return "";
            }
    catch (Exception ex)
    {
         
    }
            
            return "";
        }
        private void CalcularEExibirInformacoesAdicionaisColeta()
        {
            
            Dictionary<string, int> quantidadeFretesPorCidadeColeta = new Dictionary<string, int>();

            
            foreach (DataRowView row in ((DataTable)fretebindingSource.DataSource).DefaultView)
            {
                
                int codigoFrete = Convert.ToInt32(row["Código"]); 

               
                string sql = $"SELECT Cidade FROM Coleta WHERE IdFrete = {codigoFrete}";
                DataTable dt = Banco.consulta(sql);

                
                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    string cidade = dt.Rows[0]["Cidade"].ToString();
                    if (quantidadeFretesPorCidadeColeta.ContainsKey(cidade))
                    {
                        quantidadeFretesPorCidadeColeta[cidade]++;
                    }
                    else
                    {
                        quantidadeFretesPorCidadeColeta[cidade] = 1;
                    }
                }
            }


            
            string cidadeMaisFretes = "";
            string cidadeMenosFretes = "";
            int maxFretes = 0;
            int minFretes = int.MaxValue;

            foreach (var kvp in quantidadeFretesPorCidadeColeta)
            {
                if (kvp.Value > maxFretes)
                {
                    maxFretes = kvp.Value;
                    cidadeMaisFretes = kvp.Key;
                }

                if (kvp.Value < minFretes)
                {
                    minFretes = kvp.Value;
                    cidadeMenosFretes = kvp.Key;
                }
            }

            
            lb_cidadeMaiorColeta.Text = $"{cidadeMaisFretes} ({maxFretes} fretes)";
            lb_cidadeMenorColeta.Text = $"{cidadeMenosFretes} ({minFretes} fretes)";
        }

        private string ConsultarNomeCidadeColeta(string cidade)
        {
            try
            {
                
                string sql = $"SELECT Cidade FROM Coleta WHERE Cidade = '{cidade}'";
                Console.WriteLine("SQL: " + sql); 
                DataTable dt = Banco.consulta(sql);
                Console.WriteLine("Linhas retornadas: " + dt.Rows.Count); 

                if (dt != null && dt.Rows.Count == 1)
                {
                    
                    return dt.Rows[0]["Cidade"].ToString();
                }
                
                return "";
            }
            catch (Exception ex)
            {
                
                return "";
            }
        }


        private void ConsultarMotoristas()
        {
            
            List<Label> labelsVeiculo = new List<Label> { lb_veiculo, lb_veiculo1, lb_veiculo2, lb_veiculo3, lb_veiculo4, lb_veiculo5, lb_veiculo6 };
            List<Label> labelsNome = new List<Label> { lb_nome, lb_nome1, lb_nome2, lb_nome3, lb_nome4, lb_nome5, lb_nome6 };

            
            LimparNomesAnteriores(labelsNome);

            
            for (int i = 0; i < labelsVeiculo.Count; i++)
            {
               
                string idVeiculo = labelsVeiculo[i].Text;

                
                if (!int.TryParse(idVeiculo, out int veiculoId))
                {
                    
                    continue; 
                }

                
                string sql = $"SELECT Motorista FROM Veiculo WHERE Código = {veiculoId}";
                DataTable dt = Banco.consulta(sql);

                if (dt.Rows.Count == 1)
                {
                    
                    labelsNome[i].Text = dt.Rows[0]["Motorista"].ToString();
                }
                else
                {
                    MessageBox.Show($"Motorista não encontrado para o veículo com ID {idVeiculo}.");
                }
            }

        }

        
        private string ConsultarNomeCliente(string cpfCnpj)
        {
            try
            {
                
                string sql = $"SELECT Nome FROM Cliente WHERE CpfCnpj = '{cpfCnpj}'";
                DataTable dt = Banco.consulta(sql);

                if (dt.Rows.Count == 1)
                {
                    
                    return dt.Rows[0]["Nome"].ToString();
                }
                else
                {
                   
                    return "Cliente não encontrado";
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Erro ao consultar nome do cliente: " + ex.Message);
                return "Erro ao consultar nome do cliente";
            }
        }

        private void LimparNomesAnteriores(List<Label> labels)
        {
            
            foreach (var label in labels)
            {
                label.Text = "";
            }
        }

        private void LimparResultadosAnteriores()
        {
            lb_veiculo.Text = "";
            lb_nome.Text = "";
            lb_veiculofrete.Text = "";
            lb_veiculo1.Text = "";
            lb_nome1.Text = "";
            lb_veiculofrete1.Text = "";
            lb_veiculo2.Text = "";
            lb_nome2.Text = "";
            lb_veiculofrete2.Text = "";
            lb_veiculo3.Text = "";
            lb_nome3.Text = "";
            lb_veiculofrete3.Text = "";
            lb_veiculo4.Text = "";
            lb_nome4.Text = "";
            lb_veiculofrete4.Text = "";
            lb_veiculo5.Text = "";
            lb_nome5.Text = "";
            lb_veiculofrete5.Text = "";
            lb_veiculo6.Text = "";
            lb_nome6.Text = "";
            lb_veiculofrete6.Text = "";
            // Limpa os resultados do cliente
            lb_nomeCliente.Text = "";
            lb_cnpjCnpj.Text = "";
            lb_totalCliente.Text = "";
            lb_nomeCliente1.Text = "";
            lb_cnpjCnpj1.Text = "";
            lb_totalCliente1.Text = "";
            lb_nomeCliente2.Text = "";
            lb_cnpjCnpj2.Text = "";
            lb_totalCliente2.Text = "";
            lb_nomeCliente3.Text = "";
            lb_cnpjCnpj3.Text = "";
            lb_totalCliente3.Text = "";
            lb_nomeCliente4.Text = "";
            lb_cnpjCnpj4.Text = "";
            lb_totalCliente4.Text = "";
            lb_nomeCliente5.Text = "";
            lb_cnpjCnpj5.Text = "";
            lb_totalCliente5.Text = "";
            lb_nomeCliente6.Text = "";
            lb_cnpjCnpj6.Text = "";
            lb_totalCliente6.Text = "";
            lb_nomeCliente7.Text = "";
            lb_cnpjCnpj7.Text = "";
            lb_totalCliente7.Text = "";
            lb_nomeCliente8.Text = "";
            lb_cnpjCnpj8.Text = "";
            lb_totalCliente8.Text = "";
            lb_nomeCliente9.Text = "";
            lb_cnpjCnpj9.Text = "";
            lb_totalCliente9.Text = "";           
            // Limpa os resultados dos produtos
            lb_produto1.Text = "";
            lb_produto1Q.Text = "";
            lb_produto2.Text = "";
            lb_produto2Q.Text = "";
            lb_produto3.Text = "";
            lb_produto3Q.Text = "";
            lb_produto4.Text = "";
            lb_produto4Q.Text = "";
            lb_produto5.Text = "";
            lb_produto5Q.Text = "";
            lb_produto6.Text = "";
            lb_produto6Q.Text = "";
            // Limpa os resultados pessoas fisica e juridica
            lb_fisica.Text = "";
            lb_juridica.Text = "";
            // Limpa os resultados pessoas cidade entrega e coleta
            lb_cidadeMaior.Text = "";
            lb_cidadeMenor.Text = "";
            lb_cidadeMaiorColeta.Text = "";
            lb_cidadeMenorColeta.Text = "";
            // Limpa os resultados  frete total e valor total  na data
            lb_total.Text = "";
            lb_valor_total.Text = ""; 




        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            F_EntregasRealizadas f_EntregasRealizadas = new F_EntregasRealizadas(maskedData.Text, lb_veiculo.Text, lb_veiculo1.Text, lb_veiculo2.Text,
                       lb_veiculo3.Text, lb_veiculo4.Text, lb_veiculo5.Text, lb_veiculo6.Text, lb_nome.Text, lb_nome1.Text, lb_nome2.Text, lb_nome3.Text,
                       lb_nome4.Text, lb_nome5.Text, lb_nome6.Text, lb_veiculofrete.Text, lb_veiculofrete1.Text, lb_veiculofrete2.Text, lb_veiculofrete3.Text,
                       lb_veiculofrete4.Text, lb_veiculofrete5.Text, lb_veiculofrete6.Text, lb_valor_total.Text, lb_total.Text, lb_nomeCliente.Text, lb_nomeCliente1.Text,
                       lb_nomeCliente2.Text, lb_nomeCliente3.Text, lb_nomeCliente4.Text, lb_nomeCliente5.Text, lb_nomeCliente6.Text, lb_cnpjCnpj.Text, lb_cnpjCnpj1.Text, 
                       lb_cnpjCnpj2.Text, lb_cnpjCnpj3.Text, lb_cnpjCnpj4.Text, lb_cnpjCnpj5.Text, lb_cnpjCnpj6.Text, lb_totalCliente.Text, lb_totalCliente1.Text, 
                       lb_totalCliente2.Text, lb_totalCliente3.Text, lb_totalCliente4.Text, lb_totalCliente5.Text, lb_totalCliente6.Text, lb_produto1.Text, lb_produto2.Text,
                       lb_produto3.Text, lb_produto4.Text, lb_produto5.Text, lb_produto6.Text, lb_produto1Q.Text, lb_produto2Q.Text, lb_produto3Q.Text, lb_produto4Q.Text,
                       lb_produto5Q.Text, lb_produto6Q.Text, lb_nomeCliente7.Text, lb_nomeCliente8.Text, lb_nomeCliente9.Text, lb_cnpjCnpj7.Text, lb_cnpjCnpj8.Text,
                       lb_cnpjCnpj9.Text,lb_totalCliente7.Text, lb_totalCliente8.Text, lb_totalCliente9.Text,lb_fisica.Text, lb_juridica.Text, lb_cidadeMaior.Text,
                       lb_cidadeMenor.Text, lb_cidadeMaiorColeta.Text, lb_cidadeMenorColeta.Text);
            f_EntregasRealizadas.ShowDialog();
        }
    }
}




            


       
    

