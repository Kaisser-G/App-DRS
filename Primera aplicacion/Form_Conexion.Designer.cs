namespace Primera_aplicacion
{
    partial class Form_Conexion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Conexion));
            this.btn_Conectar = new System.Windows.Forms.Button();
            this.btn_Enviar = new System.Windows.Forms.Button();
            this.lbl_Conectar = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txt_Enviar_Lat = new System.Windows.Forms.TextBox();
            this.lbl_Enviar = new System.Windows.Forms.Label();
            this.lbl_Recibir = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Enviar_Long = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Recibir_Long = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Recibir_Lat = new System.Windows.Forms.TextBox();
            this.btn_Conexion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Conectar
            // 
            this.btn_Conectar.BackColor = System.Drawing.Color.Red;
            this.btn_Conectar.BackgroundImage = global::Primera_aplicacion.Properties.Resources.fondo_DRS_v1;
            this.btn_Conectar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Conectar.Location = new System.Drawing.Point(60, 89);
            this.btn_Conectar.Name = "btn_Conectar";
            this.btn_Conectar.Size = new System.Drawing.Size(140, 30);
            this.btn_Conectar.TabIndex = 0;
            this.btn_Conectar.Text = "Conectar/Desconectar";
            this.btn_Conectar.UseVisualStyleBackColor = false;
            this.btn_Conectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // btn_Enviar
            // 
            this.btn_Enviar.BackColor = System.Drawing.Color.Red;
            this.btn_Enviar.BackgroundImage = global::Primera_aplicacion.Properties.Resources.fondo_DRS_v1;
            this.btn_Enviar.Location = new System.Drawing.Point(60, 139);
            this.btn_Enviar.Name = "btn_Enviar";
            this.btn_Enviar.Size = new System.Drawing.Size(140, 30);
            this.btn_Enviar.TabIndex = 1;
            this.btn_Enviar.Text = "Enviar Coordenada";
            this.btn_Enviar.UseVisualStyleBackColor = false;
            this.btn_Enviar.Click += new System.EventHandler(this.btn_Enviar_Click);
            // 
            // lbl_Conectar
            // 
            this.lbl_Conectar.AutoSize = true;
            this.lbl_Conectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Conectar.Location = new System.Drawing.Point(5, 47);
            this.lbl_Conectar.Name = "lbl_Conectar";
            this.lbl_Conectar.Size = new System.Drawing.Size(89, 13);
            this.lbl_Conectar.TabIndex = 2;
            this.lbl_Conectar.Text = "Desconectado";
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7"});
            this.comboBox1.Location = new System.Drawing.Point(71, 305);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "COM";
            // 
            // txt_Enviar_Lat
            // 
            this.txt_Enviar_Lat.Location = new System.Drawing.Point(121, 189);
            this.txt_Enviar_Lat.Name = "txt_Enviar_Lat";
            this.txt_Enviar_Lat.Size = new System.Drawing.Size(101, 20);
            this.txt_Enviar_Lat.TabIndex = 5;
            // 
            // lbl_Enviar
            // 
            this.lbl_Enviar.AutoSize = true;
            this.lbl_Enviar.Location = new System.Drawing.Point(13, 196);
            this.lbl_Enviar.Name = "lbl_Enviar";
            this.lbl_Enviar.Size = new System.Drawing.Size(65, 26);
            this.lbl_Enviar.TabIndex = 7;
            this.lbl_Enviar.Text = "Coordenada\r\nPara Enviar";
            // 
            // lbl_Recibir
            // 
            this.lbl_Recibir.AutoSize = true;
            this.lbl_Recibir.Location = new System.Drawing.Point(14, 238);
            this.lbl_Recibir.Name = "lbl_Recibir";
            this.lbl_Recibir.Size = new System.Drawing.Size(65, 26);
            this.lbl_Recibir.TabIndex = 8;
            this.lbl_Recibir.Text = "Coordenada\r\nRecibida";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Long:";
            // 
            // txt_Enviar_Long
            // 
            this.txt_Enviar_Long.Location = new System.Drawing.Point(121, 208);
            this.txt_Enviar_Long.Name = "txt_Enviar_Long";
            this.txt_Enviar_Long.Size = new System.Drawing.Size(101, 20);
            this.txt_Enviar_Long.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Long:";
            // 
            // txt_Recibir_Long
            // 
            this.txt_Recibir_Long.Location = new System.Drawing.Point(121, 256);
            this.txt_Recibir_Long.Name = "txt_Recibir_Long";
            this.txt_Recibir_Long.Size = new System.Drawing.Size(101, 20);
            this.txt_Recibir_Long.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Lat:";
            // 
            // txt_Recibir_Lat
            // 
            this.txt_Recibir_Lat.Location = new System.Drawing.Point(121, 235);
            this.txt_Recibir_Lat.Name = "txt_Recibir_Lat";
            this.txt_Recibir_Lat.Size = new System.Drawing.Size(101, 20);
            this.txt_Recibir_Lat.TabIndex = 16;
            // 
            // btn_Conexion
            // 
            this.btn_Conexion.BackColor = System.Drawing.Color.Snow;
            this.btn_Conexion.FlatAppearance.BorderSize = 0;
            this.btn_Conexion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Snow;
            this.btn_Conexion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btn_Conexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Conexion.Location = new System.Drawing.Point(5, 5);
            this.btn_Conexion.Name = "btn_Conexion";
            this.btn_Conexion.Size = new System.Drawing.Size(30, 30);
            this.btn_Conexion.TabIndex = 17;
            this.btn_Conexion.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 40);
            this.panel2.TabIndex = 25;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.DarkRed;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Snow;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(710, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Snow;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(5, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(41, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Conectar";
            // 
            // Form_Conexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(234, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_Conexion);
            this.Controls.Add(this.txt_Recibir_Lat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Recibir_Long);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Enviar_Long);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Recibir);
            this.Controls.Add(this.lbl_Enviar);
            this.Controls.Add(this.txt_Enviar_Lat);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbl_Conectar);
            this.Controls.Add(this.btn_Enviar);
            this.Controls.Add(this.btn_Conectar);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Conexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conectar";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Conexion_FormClosing);
            this.Load += new System.EventHandler(this.Form_Conexion_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Conectar;
        private System.Windows.Forms.Button btn_Enviar;
        private System.Windows.Forms.Label lbl_Conectar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txt_Enviar_Lat;
        private System.Windows.Forms.Label lbl_Enviar;
        private System.Windows.Forms.Label lbl_Recibir;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Enviar_Long;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Recibir_Long;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Recibir_Lat;
        private System.Windows.Forms.Button btn_Conexion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}