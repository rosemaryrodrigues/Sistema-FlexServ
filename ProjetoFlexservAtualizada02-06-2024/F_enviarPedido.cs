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
    public partial class F_enviarPedido : Form
    {
        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private string text5;

        public F_enviarPedido(string frete, string cliente, string data, string hora, string qtdtotal, string tipo, string endereco
            , string numero, string cep, string bairro, string cidade, string qtd, string destinatario, string enderecoe
            , string numeroe, string cepe, string bairroe, string cidadee,string nome, string produto, string endereco1, string numero1
            ,string cep1,string bairro1, string cidade1,string qtd1)
        {
            InitializeComponent();
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportEmbeddedResource = "ProjetoFlexservTeste.Report1.rdlc";
                Microsoft.Reporting.WinForms.ReportParameter[] p = new
                               Microsoft.Reporting.WinForms.ReportParameter[26];
                p[0] = new Microsoft.Reporting.WinForms.ReportParameter("Frete", frete);
                p[1] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente", cliente);
                p[2] = new Microsoft.Reporting.WinForms.ReportParameter("Data", data);
                p[3] = new Microsoft.Reporting.WinForms.ReportParameter("Hora", hora);
                p[4] = new Microsoft.Reporting.WinForms.ReportParameter("QtdTotal", qtdtotal);
                p[5] = new Microsoft.Reporting.WinForms.ReportParameter("Tipo", tipo);
                p[6] = new Microsoft.Reporting.WinForms.ReportParameter("Endereco", endereco);
                p[7] = new Microsoft.Reporting.WinForms.ReportParameter("Numero", numero);
                p[8] = new Microsoft.Reporting.WinForms.ReportParameter("Cep", cep);
                p[9] = new Microsoft.Reporting.WinForms.ReportParameter("Bairro", bairro);
                p[10] = new Microsoft.Reporting.WinForms.ReportParameter("Cidade", cidade);
                p[11] = new Microsoft.Reporting.WinForms.ReportParameter("Qtd", qtd);
                p[12] = new Microsoft.Reporting.WinForms.ReportParameter("Destinatario", destinatario);
                p[13] = new Microsoft.Reporting.WinForms.ReportParameter("EnderecoE", enderecoe);
                p[14] = new Microsoft.Reporting.WinForms.ReportParameter("NumeroE", numeroe);
                p[15] = new Microsoft.Reporting.WinForms.ReportParameter("CepE", cepe);
                p[16] = new Microsoft.Reporting.WinForms.ReportParameter("BairroE", bairroe);
                p[17] = new Microsoft.Reporting.WinForms.ReportParameter("CidadeE", cidadee);
                p[18] = new Microsoft.Reporting.WinForms.ReportParameter("Nome", nome);
                p[19] = new Microsoft.Reporting.WinForms.ReportParameter("Produto", produto);
                p[20] = new Microsoft.Reporting.WinForms.ReportParameter("Endereco1", endereco1);
                p[21] = new Microsoft.Reporting.WinForms.ReportParameter("Numero1", numero1);
                p[22] = new Microsoft.Reporting.WinForms.ReportParameter("Cep1", cep1);
                p[23] = new Microsoft.Reporting.WinForms.ReportParameter("Bairro1", bairro1);
                p[24] = new Microsoft.Reporting.WinForms.ReportParameter("Cidade1", cidade1);
                p[25] = new Microsoft.Reporting.WinForms.ReportParameter("Qtd1", qtd1);
                reportViewer1.LocalReport.SetParameters(p);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro .", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        public F_enviarPedido(string text)
        {
            Text = text;
        }

        public F_enviarPedido(string text, string text1, string text2, string text3, string text4, string text5) : this(text)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            this.text4 = text4;
            this.text5 = text5;
        }

        private void F_enviarPedido_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btn_Etiqueta_Click(object sender, EventArgs e)
        {
          
        }
    }
}
