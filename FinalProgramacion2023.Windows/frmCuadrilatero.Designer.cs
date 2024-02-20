namespace FinalProgramacion2023.Windows
{
    partial class frmCuadrilatero
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            rbtPuntos = new RadioButton();
            rbtRayas = new RadioButton();
            rbtLineal = new RadioButton();
            cboRelleno = new ComboBox();
            label4 = new Label();
            btnCancelar = new Button();
            btnOK = new Button();
            txtLadoB = new TextBox();
            label2 = new Label();
            txtLadoA = new TextBox();
            label1 = new Label();
            ladoAErrorProvider = new ErrorProvider(components);
            ladoBErrorProvider = new ErrorProvider(components);
            btnBorrar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ladoAErrorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ladoBErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbtPuntos);
            groupBox1.Controls.Add(rbtRayas);
            groupBox1.Controls.Add(rbtLineal);
            groupBox1.Location = new Point(41, 144);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 76);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = " Bordes ";
            // 
            // rbtPuntos
            // 
            rbtPuntos.AutoSize = true;
            rbtPuntos.Location = new Point(168, 29);
            rbtPuntos.Name = "rbtPuntos";
            rbtPuntos.Size = new Size(62, 19);
            rbtPuntos.TabIndex = 0;
            rbtPuntos.TabStop = true;
            rbtPuntos.Text = "Puntos";
            rbtPuntos.UseVisualStyleBackColor = true;
            // 
            // rbtRayas
            // 
            rbtRayas.AutoSize = true;
            rbtRayas.Location = new Point(89, 29);
            rbtRayas.Name = "rbtRayas";
            rbtRayas.Size = new Size(55, 19);
            rbtRayas.TabIndex = 0;
            rbtRayas.TabStop = true;
            rbtRayas.Text = "Rayas";
            rbtRayas.UseVisualStyleBackColor = true;
            // 
            // rbtLineal
            // 
            rbtLineal.AutoSize = true;
            rbtLineal.Location = new Point(15, 29);
            rbtLineal.Name = "rbtLineal";
            rbtLineal.Size = new Size(56, 19);
            rbtLineal.TabIndex = 0;
            rbtLineal.TabStop = true;
            rbtLineal.Text = "Lineal";
            rbtLineal.UseVisualStyleBackColor = true;
            // 
            // cboRelleno
            // 
            cboRelleno.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRelleno.FormattingEnabled = true;
            cboRelleno.Location = new Point(101, 115);
            cboRelleno.Name = "cboRelleno";
            cboRelleno.Size = new Size(121, 23);
            cboRelleno.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 118);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 14;
            label4.Text = "Relleno:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(250, 229);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 61);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(41, 229);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 61);
            btnOK.TabIndex = 13;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // txtLadoB
            // 
            txtLadoB.Location = new Point(101, 51);
            txtLadoB.Name = "txtLadoB";
            txtLadoB.Size = new Size(100, 23);
            txtLadoB.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 54);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 7;
            label2.Text = "Lado B:";
            // 
            // txtLadoA
            // 
            txtLadoA.Location = new Point(101, 22);
            txtLadoA.Name = "txtLadoA";
            txtLadoA.Size = new Size(100, 23);
            txtLadoA.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 25);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 8;
            label1.Text = "Lado A:";
            // 
            // ladoAErrorProvider
            // 
            ladoAErrorProvider.ContainerControl = this;
            // 
            // ladoBErrorProvider
            // 
            ladoBErrorProvider.ContainerControl = this;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(147, 229);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 61);
            btnBorrar.TabIndex = 17;
            btnBorrar.Text = "Limpiar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // frmCuadrilatero
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 313);
            Controls.Add(btnBorrar);
            Controls.Add(groupBox1);
            Controls.Add(cboRelleno);
            Controls.Add(label4);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtLadoB);
            Controls.Add(label2);
            Controls.Add(txtLadoA);
            Controls.Add(label1);
            Name = "frmCuadrilatero";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCuadrilatero";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ladoAErrorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)ladoBErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rbtPuntos;
        private RadioButton rbtRayas;
        private RadioButton rbtLineal;
        private ComboBox cboRelleno;
        private Label label4;
        private Button btnCancelar;
        private Button btnOK;
        private TextBox txtLadoB;
        private Label label2;
        private TextBox txtLadoA;
        private Label label1;
        private ErrorProvider ladoAErrorProvider;
        private ErrorProvider ladoBErrorProvider;
        private Button btnBorrar;
    }
}