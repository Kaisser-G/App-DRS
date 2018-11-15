namespace Primera_aplicacion
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtLatitud = new System.Windows.Forms.TextBox();
            this.txtLongitud = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUbicacion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnConexion = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRango = new System.Windows.Forms.Button();
            this.pbNivelBat = new System.Windows.Forms.ProgressBar();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblBateria = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(8, 57);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(426, 381);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl1_OnMarkerClick);
            this.gMapControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDoubleClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Location = new System.Drawing.Point(440, 204);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 25);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Location = new System.Drawing.Point(522, 204);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 25);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(441, 68);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(157, 15);
            this.txtDescripcion.TabIndex = 3;
            // 
            // txtLatitud
            // 
            this.txtLatitud.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLatitud.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLatitud.Location = new System.Drawing.Point(440, 129);
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.Size = new System.Drawing.Size(157, 15);
            this.txtLatitud.TabIndex = 4;
            // 
            // txtLongitud
            // 
            this.txtLongitud.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLongitud.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongitud.Location = new System.Drawing.Point(440, 172);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(157, 15);
            this.txtLongitud.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(440, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(440, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Latitud";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(440, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Longitud";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(440, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tabla de Posiciones";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(444, 258);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(153, 180);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Seleccionar_registro);
            // 
            // btnUbicacion
            // 
            this.btnUbicacion.BackColor = System.Drawing.Color.DarkCyan;
            this.btnUbicacion.FlatAppearance.BorderSize = 0;
            this.btnUbicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUbicacion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUbicacion.ForeColor = System.Drawing.Color.White;
            this.btnUbicacion.Location = new System.Drawing.Point(334, 402);
            this.btnUbicacion.Name = "btnUbicacion";
            this.btnUbicacion.Size = new System.Drawing.Size(100, 36);
            this.btnUbicacion.TabIndex = 23;
            this.btnUbicacion.Text = "Enviar Ubicacion";
            this.btnUbicacion.UseVisualStyleBackColor = false;
            this.btnUbicacion.Click += new System.EventHandler(this.btnUbicacion_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnMin);
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.btnConexion);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(824, 40);
            this.panel2.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Primera_aplicacion.Properties.Resources.DRS_Logo_v2;
            this.button1.Location = new System.Drawing.Point(385, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 30);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnMin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Snow;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.Location = new System.Drawing.Point(754, 4);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(30, 30);
            this.btnMin.TabIndex = 14;
            this.btnMin.Text = "_";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.DarkRed;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(790, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnConexion
            // 
            this.btnConexion.BackColor = System.Drawing.Color.Transparent;
            this.btnConexion.FlatAppearance.BorderSize = 0;
            this.btnConexion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnConexion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnConexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConexion.Image = global::Primera_aplicacion.Properties.Resources.imgMenu;
            this.btnConexion.Location = new System.Drawing.Point(5, 5);
            this.btnConexion.Name = "btnConexion";
            this.btnConexion.Size = new System.Drawing.Size(30, 30);
            this.btnConexion.TabIndex = 11;
            this.btnConexion.UseVisualStyleBackColor = false;
            this.btnConexion.Click += new System.EventHandler(this.btnConexion_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(603, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 234);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aptitud";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBateria);
            this.groupBox1.Controls.Add(this.lblNivel);
            this.groupBox1.Controls.Add(this.pbNivelBat);
            this.groupBox1.Controls.Add(this.btnRango);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(644, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 145);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bateria";
            // 
            // btnRango
            // 
            this.btnRango.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRango.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRango.ForeColor = System.Drawing.Color.White;
            this.btnRango.Location = new System.Drawing.Point(22, 94);
            this.btnRango.Name = "btnRango";
            this.btnRango.Size = new System.Drawing.Size(97, 34);
            this.btnRango.TabIndex = 25;
            this.btnRango.Text = "Rango";
            this.btnRango.UseVisualStyleBackColor = false;
            this.btnRango.Click += new System.EventHandler(this.btnRango_Click);
            // 
            // pbNivelBat
            // 
            this.pbNivelBat.BackColor = System.Drawing.Color.Firebrick;
            this.pbNivelBat.ForeColor = System.Drawing.Color.PaleGreen;
            this.pbNivelBat.Location = new System.Drawing.Point(21, 47);
            this.pbNivelBat.Name = "pbNivelBat";
            this.pbNivelBat.Size = new System.Drawing.Size(97, 23);
            this.pbNivelBat.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbNivelBat.TabIndex = 29;
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.BackColor = System.Drawing.Color.Transparent;
            this.lblNivel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNivel.Location = new System.Drawing.Point(17, 27);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(45, 19);
            this.lblNivel.TabIndex = 31;
            this.lblNivel.Text = "Nivel:";
            // 
            // lblBateria
            // 
            this.lblBateria.AutoSize = true;
            this.lblBateria.BackColor = System.Drawing.Color.Transparent;
            this.lblBateria.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBateria.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblBateria.Location = new System.Drawing.Point(89, 27);
            this.lblBateria.Name = "lblBateria";
            this.lblBateria.Size = new System.Drawing.Size(29, 19);
            this.lblBateria.TabIndex = 32;
            this.lblBateria.Text = "0%";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(824, 450);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnUbicacion);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLongitud);
            this.Controls.Add(this.txtLatitud);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gMapControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Google Maps";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LocationChanged += new System.EventHandler(this.Form_Main_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtLatitud;
        private System.Windows.Forms.TextBox txtLongitud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConexion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUbicacion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBateria;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.ProgressBar pbNivelBat;
        private System.Windows.Forms.Button btnRango;
    }
}

