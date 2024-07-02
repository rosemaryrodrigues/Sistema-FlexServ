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
    public partial class F_ConsFrete : Form
    {
        private DataTable dt;
        private DataTable dc;
        private DataTable de;
        private BindingSource fretebindingSource;
        private BindingSource coletabindingSource;
        private BindingSource entregabindingSource;
        public F_ConsFrete()
        {
            InitializeComponent();
            dt = new DataTable();
            dc = new DataTable();
            de = new DataTable();
            fretebindingSource = new BindingSource();
            coletabindingSource = new BindingSource();
            entregabindingSource = new BindingSource();
        }

        private void F_ConsFrete_Load(object sender, EventArgs e)
        {
          
            this.coletaTableAdapter.Fill(this.empresaFlexDataSet2.Coleta);
            
            this.freteTableAdapter.Fill(this.empresaFlexDataSet4.Frete);

            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 130;
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 150;
            dataGridView1.Columns[8].Width = 70;
            dataGridView1.Columns[9].Width = 95;
            dataGridView1.Columns[10].Width = 100;


            dataGridView2.Columns[0].Width = 90;
            dataGridView2.Columns[1].Width = 200;
            dataGridView2.Columns[2].Width = 90;
            dataGridView2.Columns[3].Width = 75;
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].Width = 150;
            dataGridView2.Columns[6].Width = 100;
            dataGridView2.Columns[7].Width = 80;           

            dataGridView3.Columns[0].Width = 90;
            dataGridView3.Columns[1].Width = 200;
            dataGridView3.Columns[2].Width = 180;
            dataGridView3.Columns[3].Width = 80;
            dataGridView3.Columns[4].Width = 75;
            dataGridView3.Columns[5].Width = 150;
            dataGridView3.Columns[6].Width = 150;
            dataGridView3.Columns[7].Width = 80;
                           
           
            this.entregaTableAdapter.Fill(this.empresaFlexDataSet3.Entrega);
           
          
            
            coletabindingSource.DataSource = this.empresaFlexDataSet2.Coleta;
            entregabindingSource.DataSource = this.empresaFlexDataSet3.Entrega;
            fretebindingSource.DataSource = this.empresaFlexDataSet4.Frete;
            dataGridView1.DataSource = fretebindingSource;
            dataGridView2.DataSource = coletabindingSource;
            dataGridView3.DataSource = entregabindingSource;
           
            dt = ((DataView)fretebindingSource.List).Table.Copy();
            dc = ((DataView)coletabindingSource.List).Table.Copy();
            de = ((DataView)entregabindingSource.List).Table.Copy();

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            FiltrarGrade();
        }
        private void FiltrarGrade()
        {
            
            if (int.TryParse(tb_buscar.Text, out int codigo))
            {
                
                ((DataTable)fretebindingSource.DataSource).DefaultView.RowFilter = $"Código = {codigo}";

                if (int.TryParse(tb_buscar.Text, out int idfrete))
                {
                    
                    ((DataTable)coletabindingSource.DataSource).DefaultView.RowFilter = $"IdFrete = {idfrete}";

                    if (int.TryParse(tb_buscar.Text, out int identrega))
                    {
                        
                        ((DataTable)entregabindingSource.DataSource).DefaultView.RowFilter = $"IdFrete = {identrega}";

                        
                        dataGridView1.Refresh();
                        dataGridView2.Refresh();
                        dataGridView3.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira um número válido para buscar.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

      
        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_status_Click(object sender, EventArgs e)
        {
            
            
                
            
           
        }

    }
}
