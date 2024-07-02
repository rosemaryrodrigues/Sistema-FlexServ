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
    public partial class F_EntregasRealizadas : Form
    {
        public F_EntregasRealizadas(string data, string veiculo, string veiculo1, string veiculo2, string veiculo3, string veiculo4, string veiculo5
            , string veiculo6, string nome, string nome1, string nome2, string nome3, string nome4, string nome5,string nome6,string frete, string frete1
            ,string frete2, string frete3, string frete4, string frete5, string frete6,string total,string valor, string cliente, string cliente1, string cliente2
            , string cliente3, string cliente4, string cliente5,string cliente6,string cpf, string cpf1, string cpf2, string cpf3, string cpf4, string cpf5, string cpf6
            ,string ftotal, string ftotal1, string ftotal2, string ftotal3, string ftotal4, string ftotal5, string ftotal6,string produto, string produto1, string produto2
            , string produto3, string produto4, string produto5,string qtd, string qtd1, string qtd2, string qtd3, string qtd4, string qtd5,string cliente7, string cliente8
            , string cliente9,string cpf7, string cpf8, string cpf9, string ftotal7, string ftotal8, string ftotal9,string fisica, string juridica,string entregama,string entregame
            ,string coletama, string coletame)
        {
            InitializeComponent();
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportEmbeddedResource = "ProjetoFlexservTeste.Report3.rdlc";
                Microsoft.Reporting.WinForms.ReportParameter[] p = new
                               Microsoft.Reporting.WinForms.ReportParameter[72];
                p[0] = new Microsoft.Reporting.WinForms.ReportParameter("Data", data);
                p[1] = new Microsoft.Reporting.WinForms.ReportParameter("Veiculo", veiculo);
                p[2] = new Microsoft.Reporting.WinForms.ReportParameter("Veiculo1", veiculo1);
                p[3] = new Microsoft.Reporting.WinForms.ReportParameter("Veiculo2", veiculo2);
                p[4] = new Microsoft.Reporting.WinForms.ReportParameter("Veiculo3", veiculo3);
                p[5] = new Microsoft.Reporting.WinForms.ReportParameter("Veiculo4", veiculo4);
                p[6] = new Microsoft.Reporting.WinForms.ReportParameter("Veiculo5", veiculo5);
                p[7] = new Microsoft.Reporting.WinForms.ReportParameter("Veiculo6", veiculo6);
                p[8] = new Microsoft.Reporting.WinForms.ReportParameter("Nome", nome);
                p[9] = new Microsoft.Reporting.WinForms.ReportParameter("Nome1", nome1);
                p[10] = new Microsoft.Reporting.WinForms.ReportParameter("Nome2", nome2);
                p[11] = new Microsoft.Reporting.WinForms.ReportParameter("Nome3", nome3);
                p[12] = new Microsoft.Reporting.WinForms.ReportParameter("Nome4", nome4);
                p[13] = new Microsoft.Reporting.WinForms.ReportParameter("Nome5", nome5);
                p[14] = new Microsoft.Reporting.WinForms.ReportParameter("Nome6", nome6);
                p[15] = new Microsoft.Reporting.WinForms.ReportParameter("Frete", frete);
                p[16] = new Microsoft.Reporting.WinForms.ReportParameter("Frete1", frete1);
                p[17] = new Microsoft.Reporting.WinForms.ReportParameter("Frete2", frete2);
                p[18] = new Microsoft.Reporting.WinForms.ReportParameter("Frete3", frete3);
                p[19] = new Microsoft.Reporting.WinForms.ReportParameter("Frete4", frete4);
                p[20] = new Microsoft.Reporting.WinForms.ReportParameter("Frete5", frete5);
                p[21] = new Microsoft.Reporting.WinForms.ReportParameter("Frete6", frete6);
                p[22] = new Microsoft.Reporting.WinForms.ReportParameter("Valor", valor);
                p[23] = new Microsoft.Reporting.WinForms.ReportParameter("Total", total);
                p[24] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente", cliente);
                p[25] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente1", cliente1);
                p[26] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente2", cliente2);
                p[27] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente3", cliente3);
                p[28] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente4", cliente4);
                p[29] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente5", cliente5);
                p[30] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente6", cliente6);
                p[31] = new Microsoft.Reporting.WinForms.ReportParameter("CPF", cpf);
                p[32] = new Microsoft.Reporting.WinForms.ReportParameter("CPF1", cpf1);
                p[33] = new Microsoft.Reporting.WinForms.ReportParameter("CPF2", cpf2);
                p[34] = new Microsoft.Reporting.WinForms.ReportParameter("CPF3", cpf3);
                p[35] = new Microsoft.Reporting.WinForms.ReportParameter("CPF4", cpf4);
                p[36] = new Microsoft.Reporting.WinForms.ReportParameter("CPF5", cpf5);
                p[37] = new Microsoft.Reporting.WinForms.ReportParameter("CPF6", cpf6);
                p[38] = new Microsoft.Reporting.WinForms.ReportParameter("FTotal", ftotal);
                p[39] = new Microsoft.Reporting.WinForms.ReportParameter("FTotal1", ftotal1);
                p[40] = new Microsoft.Reporting.WinForms.ReportParameter("FTotal2", ftotal2);
                p[41] = new Microsoft.Reporting.WinForms.ReportParameter("FTotal3", ftotal3);
                p[42] = new Microsoft.Reporting.WinForms.ReportParameter("FTotal4", ftotal4);
                p[43] = new Microsoft.Reporting.WinForms.ReportParameter("FTotal5", ftotal5);
                p[44] = new Microsoft.Reporting.WinForms.ReportParameter("FTotal6", ftotal6);
                p[45] = new Microsoft.Reporting.WinForms.ReportParameter("Produto", produto);
                p[46] = new Microsoft.Reporting.WinForms.ReportParameter("Produto1", produto1);
                p[47] = new Microsoft.Reporting.WinForms.ReportParameter("Produto2", produto2);
                p[48] = new Microsoft.Reporting.WinForms.ReportParameter("Produto3", produto3);
                p[49] = new Microsoft.Reporting.WinForms.ReportParameter("Produto4", produto4);
                p[50] = new Microsoft.Reporting.WinForms.ReportParameter("Produto5", produto5);
                p[51] = new Microsoft.Reporting.WinForms.ReportParameter("Qtd", qtd);
                p[52] = new Microsoft.Reporting.WinForms.ReportParameter("Qtd1", qtd1);
                p[53] = new Microsoft.Reporting.WinForms.ReportParameter("Qtd2", qtd2);
                p[54] = new Microsoft.Reporting.WinForms.ReportParameter("Qtd3", qtd3);
                p[55] = new Microsoft.Reporting.WinForms.ReportParameter("Qtd4", qtd4);
                p[56] = new Microsoft.Reporting.WinForms.ReportParameter("Qtd5", qtd5);
                p[57] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente7", cliente7);
                p[58] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente8", cliente8);
                p[59] = new Microsoft.Reporting.WinForms.ReportParameter("Cliente9", cliente9);                
                p[60] = new Microsoft.Reporting.WinForms.ReportParameter("CPF7", cpf7);
                p[61] = new Microsoft.Reporting.WinForms.ReportParameter("CPF8", cpf8);
                p[62] = new Microsoft.Reporting.WinForms.ReportParameter("CPF9", cpf9);               
                p[63] = new Microsoft.Reporting.WinForms.ReportParameter("FTotal7", ftotal7);
                p[64] = new Microsoft.Reporting.WinForms.ReportParameter("FTotal8", ftotal8);
                p[65] = new Microsoft.Reporting.WinForms.ReportParameter("FTotal9", ftotal9);                             
                p[66] = new Microsoft.Reporting.WinForms.ReportParameter("juridica", juridica);
                p[67] = new Microsoft.Reporting.WinForms.ReportParameter("Fisica", fisica);
                p[68] = new Microsoft.Reporting.WinForms.ReportParameter("EntregaMA", entregama);
                p[69] = new Microsoft.Reporting.WinForms.ReportParameter("EntregaMe", entregame);
                p[70] = new Microsoft.Reporting.WinForms.ReportParameter("ColetaMA", coletama);
                p[71] = new Microsoft.Reporting.WinForms.ReportParameter("ColetaME", coletame);

                reportViewer1.LocalReport.SetParameters(p);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro .", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void F_EntregasRealizadas_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
