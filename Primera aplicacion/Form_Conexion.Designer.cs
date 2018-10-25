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
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblConectar = new System.Windows.Forms.Label();
            this.boxCom = new System.Windows.Forms.ComboBox();
            this.txtEnviarLat = new System.Windows.Forms.TextBox();
            this.lbl_Enviar = new System.Windows.Forms.Label();
            this.lbl_Recibir = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnviarLong = new System.Windows.Forms.TextBox();
            this.txtRecibirLong = new System.Windows.Forms.TextBox();
            this.txtRecibirLat = new System.Windows.Forms.TextBox();
            this.btn_Conexion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.Crimson;
            this.btnConectar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConectar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.Location = new System.Drawing.Point(45, 360);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(146, 30);
            this.btnConectar.TabIndex = 0;
            this.btnConectar.Text = "Conectar/Desconectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.Chocolate;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(51, 167);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(140, 30);
            this.btnEnviar.TabIndex = 1;
            this.btnEnviar.Text = "Enviar Coordenada";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblConectar
            // 
            this.lblConectar.AutoSize = true;
            this.lblConectar.BackColor = System.Drawing.Color.Firebrick;
            this.lblConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblConectar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConectar.Location = new System.Drawing.Point(80, 53);
            this.lblConectar.Name = "lblConectar";
            this.lblConectar.Size = new System.Drawing.Size(118, 21);
            this.lblConectar.TabIndex = 2;
            this.lblConectar.Text = "Desconectado";
            // 
            // boxCom
            // 
            this.boxCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boxCom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCom.FormattingEnabled = true;
            this.boxCom.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7"});
            this.boxCom.Location = new System.Drawing.Point(60, 316);
            this.boxCom.Name = "boxCom";
            this.boxCom.Size = new System.Drawing.Size(120, 23);
            this.boxCom.TabIndex = 3;
            this.boxCom.Text = "COM1";
            // 
            // txtEnviarLat
            // 
            this.txtEnviarLat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEnviarLat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnviarLat.Location = new System.Drawing.Point(18, 146);
            this.txtEnviarLat.Name = "txtEnviarLat";
            this.txtEnviarLat.Size = new System.Drawing.Size(101, 15);
            this.txtEnviarLat.TabIndex = 5;
            // 
            // lbl_Enviar
            // 
            this.lbl_Enviar.AutoSize = true;
            this.lbl_Enviar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Enviar.Location = new System.Drawing.Point(23, 93);
            this.lbl_Enviar.Name = "lbl_Enviar";
            this.lbl_Enviar.Size = new System.Drawing.Size(188, 21);
            this.lbl_Enviar.TabIndex = 7;
            this.lbl_Enviar.Text = "Coordenada para enviar:";
            // 
            // lbl_Recibir
            // 
            this.lbl_Recibir.AutoSize = true;
            this.lbl_Recibir.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Recibir.Location = new System.Drawing.Point(41, 217);
            this.lbl_Recibir.Name = "lbl_Recibir";
            this.lbl_Recibir.Size = new System.Drawing.Size(156, 20);
            this.lbl_Recibir.TabIndex = 8;
            this.lbl_Recibir.Text = "Coordenada recibida:";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Long:";
            // 
            // txtEnviarLong
            // 
            this.txtEnviarLong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEnviarLong.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnviarLong.Location = new System.Drawing.Point(121, 146);
            this.txtEnviarLong.Name = "txtEnviarLong";
            this.txtEnviarLong.Size = new System.Drawing.Size(101, 15);
            this.txtEnviarLong.TabIndex = 10;
            // 
            // txtRecibirLong
            // 
            this.txtRecibirLong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecibirLong.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecibirLong.Location = new System.Drawing.Point(121, 272);
            this.txtRecibirLong.Name = "txtRecibirLong";
            this.txtRecibirLong.Size = new System.Drawing.Size(101, 15);
            this.txtRecibirLong.TabIndex = 14;
            // 
            // txtRecibirLat
            // 
            this.txtRecibirLat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecibirLat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecibirLat.Location = new System.Drawing.Point(18, 272);
            this.txtRecibirLat.Name = "txtRecibirLat";
            this.txtRecibirLat.Size = new System.Drawing.Size(101, 15);
            this.txtRecibirLat.TabIndex = 16;
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
            this.panel2.Controls.Add(this.btnMenu);
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
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnMenu.Image = global::Primera_aplicacion.Properties.Resources.imgMenu;
            this.btnMenu.Location = new System.Drawing.Point(5, 5);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(30, 30);
            this.btnMenu.TabIndex = 11;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 21);
            this.label6.TabIndex = 26;
            this.label6.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Long:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Lat:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(27, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 22);
            this.button1.TabIndex = 29;
            this.button1.Text = "Reiniciar Conexion";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Conexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(234, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_Conexion);
            this.Controls.Add(this.txtRecibirLat);
            this.Controls.Add(this.txtRecibirLong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEnviarLong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Recibir);
            this.Controls.Add(this.lbl_Enviar);
            this.Controls.Add(this.txtEnviarLat);
            this.Controls.Add(this.boxCom);
            this.Controls.Add(this.lblConectar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnConectar);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Conexion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conectar";
            this.Load += new System.EventHandler(this.Form_Conexion_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblConectar;
        private System.Windows.Forms.ComboBox boxCom;
        private System.Windows.Forms.TextBox txtEnviarLat;
        private System.Windows.Forms.Label lbl_Enviar;
        private System.Windows.Forms.Label lbl_Recibir;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnviarLong;
        private System.Windows.Forms.TextBox txtRecibirLong;
        private System.Windows.Forms.TextBox txtRecibirLat;
        private System.Windows.Forms.Button btn_Conexion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}