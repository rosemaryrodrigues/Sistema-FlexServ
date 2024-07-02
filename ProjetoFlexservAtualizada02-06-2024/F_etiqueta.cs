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
    public partial class F_etiqueta : Form
    {
        public F_etiqueta(string frete, string destinatario, string endereco, string numero, string cep, string bairro, string cidade)
        {
            InitializeComponent();
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportEmbeddedResource = "ProjetoFlexservTeste.Report2.rdlc";
                Microsoft.Reporting.WinForms.ReportParameter[] p = new
                               Microsoft.Reporting.WinForms.ReportParameter[7];
                p[0] = new Microsoft.Reporting.WinForms.ReportParameter("Frete", frete);
                p[1] = new Microsoft.Reporting.WinForms.ReportParameter("Destinatario", destinatario);
                p[2] = new Microsoft.Reporting.WinForms.ReportParameter("Endereco", endereco);
                p[3] = new Microsoft.Reporting.WinForms.ReportParameter("Numero", numero);
                p[4] = new Microsoft.Reporting.WinForms.ReportParameter("Cep", cep);
                p[5] = new Microsoft.Reporting.WinForms.ReportParameter("Bairro", bairro);
                p[6] = new Microsoft.Reporting.WinForms.ReportParameter("Cidade", cidade);
                reportViewer1.LocalReport.SetParameters(p);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro .", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void F_etiqueta_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
