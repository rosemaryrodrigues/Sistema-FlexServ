
namespace ProjetoFlexservTeste
{
    partial class F_AlterarEntrega
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.tb_buscar = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_IdEntrega = new System.Windows.Forms.TextBox();
            this.msktxtCep = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tb_cidade = new System.Windows.Forms.TextBox();
            this.tb_bairro = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_numero = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tb_endereco = new System.Windows.Forms.TextBox();
            this.tb_destinatario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_salvarAtera = new System.Windows.Forms.Button();
            this.tb_Idfrete = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(19, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "Alterar Entrega";
            // 
            // tb_buscar
            // 
            this.tb_buscar.Location = new System.Drawing.Point(81, 58);
            this.tb_buscar.Name = "tb_buscar";
            this.tb_buscar.Size = new System.Drawing.Size(77, 20);
            this.tb_buscar.TabIndex = 56;
            // 
            // btn_buscar
            // 
            this.btn_buscar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_buscar.Location = new System.Drawing.Point(183, 56);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 55;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(19, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 54;
            this.label1.Text = "ID Frete";
            // 
            // btn_fechar
            // 
            this.btn_fechar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_fechar.Location = new System.Drawing.Point(330, 286);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(116, 27);
            this.btn_fechar.TabIndex = 246;
            this.btn_fechar.Text = "Fechar";
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 245;
            this.label2.Text = "ID Entrega";
            // 
            // tb_IdEntrega
            // 
            this.tb_IdEntrega.Location = new System.Drawing.Point(16, 110);
            this.tb_IdEntrega.Name = "tb_IdEntrega";
            this.tb_IdEntrega.ReadOnly = true;
            this.tb_IdEntrega.Size = new System.Drawing.Size(78, 20);
            this.tb_IdEntrega.TabIndex = 244;
            this.tb_IdEntrega.TabStop = false;
            // 
            // msktxtCep
            // 
            this.msktxtCep.Location = new System.Drawing.Point(51, 215);
            this.msktxtCep.Mask = "00000-000";
            this.msktxtCep.Name = "msktxtCep";
            this.msktxtCep.Size = new System.Drawing.Size(73, 20);
            this.msktxtCep.TabIndex = 243;
            this.msktxtCep.ValidatingType = typeof(System.DateTime);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(240, 243);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 14);
            this.label17.TabIndex = 242;
            this.label17.Text = "Cidade";
            // 
            // tb_cidade
            // 
            this.tb_cidade.Location = new System.Drawing.Point(296, 241);
            this.tb_cidade.Name = "tb_cidade";
            this.tb_cidade.Size = new System.Drawing.Size(150, 20);
            this.tb_cidade.TabIndex = 241;
            // 
            // tb_bairro
            // 
            this.tb_bairro.Location = new System.Drawing.Point(62, 241);
            this.tb_bairro.Name = "tb_bairro";
            this.tb_bairro.Size = new System.Drawing.Size(174, 20);
            this.tb_bairro.TabIndex = 240;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(15, 243);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 14);
            this.label18.TabIndex = 239;
            this.label18.Text = "Bairro";
            // 
            // tb_numero
            // 
            this.tb_numero.Location = new System.Drawing.Point(159, 215);
            this.tb_numero.Name = "tb_numero";
            this.tb_numero.Size = new System.Drawing.Size(77, 20);
            this.tb_numero.TabIndex = 238;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(13, 217);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 14);
            this.label19.TabIndex = 237;
            this.label19.Text = "CEP";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(132, 217);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 14);
            this.label20.TabIndex = 236;
            this.label20.Text = "N°";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(13, 185);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(51, 14);
            this.label21.TabIndex = 235;
            this.label21.Text = "Rua/Av";
            // 
            // tb_endereco
            // 
            this.tb_endereco.Location = new System.Drawing.Point(71, 185);
            this.tb_endereco.Name = "tb_endereco";
            this.tb_endereco.Size = new System.Drawing.Size(320, 20);
            this.tb_endereco.TabIndex = 234;
            // 
            // tb_destinatario
            // 
            this.tb_destinatario.Location = new System.Drawing.Point(106, 150);
            this.tb_destinatario.Name = "tb_destinatario";
            this.tb_destinatario.Size = new System.Drawing.Size(294, 20);
            this.tb_destinatario.TabIndex = 233;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 152);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 14);
            this.label6.TabIndex = 232;
            this.label6.Text = "Destinatário";
            // 
            // btn_salvarAtera
            // 
            this.btn_salvarAtera.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_salvarAtera.Location = new System.Drawing.Point(18, 284);
            this.btn_salvarAtera.Name = "btn_salvarAtera";
            this.btn_salvarAtera.Size = new System.Drawing.Size(121, 29);
            this.btn_salvarAtera.TabIndex = 231;
            this.btn_salvarAtera.Text = "Salvar Alterações";
            this.btn_salvarAtera.UseVisualStyleBackColor = true;
            // 
            // tb_Idfrete
            // 
            this.tb_Idfrete.Location = new System.Drawing.Point(183, 110);
            this.tb_Idfrete.Name = "tb_Idfrete";
            this.tb_Idfrete.ReadOnly = true;
            this.tb_Idfrete.Size = new System.Drawing.Size(78, 20);
            this.tb_Idfrete.TabIndex = 247;
            this.tb_Idfrete.TabStop = false;
            // 
            // F_AlterarEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 327);
            this.Controls.Add(this.tb_Idfrete);
            this.Controls.Add(this.btn_fechar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_IdEntrega);
            this.Controls.Add(this.msktxtCep);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tb_cidade);
            this.Controls.Add(this.tb_bairro);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tb_numero);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tb_endereco);
            this.Controls.Add(this.tb_destinatario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_salvarAtera);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_buscar);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "F_AlterarEntrega";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Entrega";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_buscar;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_IdEntrega;
        private System.Windows.Forms.MaskedTextBox msktxtCep;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tb_cidade;
        private System.Windows.Forms.TextBox tb_bairro;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_numero;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tb_endereco;
        private System.Windows.Forms.TextBox tb_destinatario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_salvarAtera;
        private System.Windows.Forms.TextBox tb_Idfrete;
    }
}