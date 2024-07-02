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
    public partial class F_RealizarEntrega : Form
    {
        DataTable dt = new DataTable();
        private DataTable df;
        private BindingSource fretebindingSource;
        private DataTable dv;
        private BindingSource veiculobindingSource;

        public F_RealizarEntrega()
        {
            InitializeComponent();
            df = new DataTable();
            fretebindingSource = new BindingSource();
            dv = new DataTable();
            veiculobindingSource = new BindingSource();

        }
        private void F_CancelarFrete_Load(object sender, EventArgs e)
        {
           
            this.freteTableAdapter.Fill(this.empresaFlexDataSet7.Frete);
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 90;      
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[7].Width = 150;
            dataGridView1.Columns[8].Width = 70;
            dataGridView1.Columns[9].Width = 95;
            dataGridView1.Columns[10].Width = 100;

            dataGridView2.Columns[0].Width = 60;
            dataGridView2.Columns[1].Width = 70;
            dataGridView2.Columns[2].Width = 150;
            dataGridView2.Columns[3].Width = 90;
            dataGridView2.Columns[4].Width = 60;
            dataGridView2.Columns[5].Width = 180;
            dataGridView2.Columns[6].Width = 180;
                 
                     
            
            this.veiculoTableAdapter.Fill(this.empresaFlexDataSet6.Veiculo);           
                       
            fretebindingSource.DataSource = this.empresaFlexDataSet7.Frete;
            dataGridView1.DataSource = fretebindingSource;
            veiculobindingSource.DataSource = this.empresaFlexDataSet6.Veiculo;
            dataGridView2.DataSource = veiculobindingSource;
            
            dt = ((DataView)fretebindingSource.List).Table.Copy();
            dv = ((DataView)veiculobindingSource.List).Table.Copy();


        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            FiltrarGrade();
        }
        private void FiltrarGrade()
        {
            
            DataTable dataTable = (DataTable)fretebindingSource.DataSource;

            
            StringBuilder filterExpression = new StringBuilder();

            
            if (!string.IsNullOrEmpty(tb_buscar.Text))
            {
                if (int.TryParse(tb_buscar.Text, out int codigo))
                {
                    filterExpression.Append($"Código = {codigo}");
                }
                else
                {
                    MessageBox.Show("Por favor, insira um número válido para buscar.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            
            if (string.IsNullOrEmpty(maskedHoraC.Text) || string.IsNullOrEmpty(maskedHoraE.Text))
            {
                
                if (filterExpression.Length > 0)
                    filterExpression.Append(" AND ");

                filterExpression.Append($"(Hora_Coleta = '' OR Hora_Entrega = '')");
            }

           
            dataTable.DefaultView.RowFilter = filterExpression.ToString();

           
            dataGridView1.Refresh();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            int selectedRowCount = dataGridView.SelectedRows.Count;

            if (selectedRowCount > 0)
            {
                DataRowView selectedRowView = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                DataRow selectedRow = selectedRowView.Row;

                try
                {
                    tb_IdVeiculo.Text = selectedRow.Field<int>("IdVeiculo").ToString();

                    
                    Console.WriteLine("Campo 'IdVeiculo' foi acessado com sucesso.");

                    maskedHoraC.Text = selectedRow.Field<string>("Hora_Coleta");

                    
                    Console.WriteLine("Campo 'Hora_Coleta' foi acessado com sucesso.");

                    maskedHoraE.Text = selectedRow.Field<string>("Hora_Entrega");

                   
                    Console.WriteLine("Campo 'Hora_Entrega' foi acessado com sucesso.");
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show($"Erro ao acessar os dados da linha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Exceção: {ex.Message}");
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(tb_IdVeiculo.Text))
                {
                    MessageBox.Show("Por favor, insira o ID do veículo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_IdVeiculo.Focus();
                    return;
                }

                Frete u = new Frete();
                
                u.Idveiculo = Convert.ToInt32(tb_IdVeiculo.Text);
                u.id = Convert.ToInt32(tb_buscar.Text);
                u.horac = maskedHoraC.Text;
                u.horae = maskedHoraE.Text;
                
                Banco.AtualizarEntrega(u);               

                
                MessageBox.Show("Registrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              

                
                AtualizarDataGridView();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Erro ao Registrada  Entrega: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void AtualizarDataGridView()
        {
            try
            {
                
                this.freteTableAdapter.Fill(this.empresaFlexDataSet7.Frete);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar DataGridView: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Filtrar()
        {
            
            string tipo = cb_veiculo1.Text;

            
            if (!string.IsNullOrEmpty(tipo))
            {
                
                tipo = tipo.Replace("'", "''");

                
                ((DataTable)veiculobindingSource.DataSource).DefaultView.RowFilter = $"Tipo = '{tipo}'";

                                     
                dataGridView2.Refresh();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um tipo de veículo válido para pesquisar.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel2.Text = DateTime.Now.ToShortTimeString();
           

        }
    }
}





