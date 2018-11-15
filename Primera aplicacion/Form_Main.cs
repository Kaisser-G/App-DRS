using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using System.Drawing.Drawing2D; //Espacio de nombre utilizado para funciones graficas adicionales

using GMap.NET; //Espacios de nombre utilizados para el control de la API de Google Maps

using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Primera_aplicacion
{
    public partial class Form_Main : Form
    {
        //Declaracion de objetos para el manejo de la API
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;

        //Confguracion de Bitmap para el horizonte
        Bitmap horizonte;
        Graphics grafico;

        //Configuracion para el dibujo
        SolidBrush pincelBlanco, pincelRojo, pincelNegro, pincelGris, pincelTierra, pincelCielo;
        Pen lapizBlanco, lapizRojo, lapizNegro, lapizGris, lapizTierra, lapizCielo;
        Font Arial;

        //Creo un objeto de la clase para guardar los datos de aptitud del drone
        Aptitud datos = new Aptitud();

        //Fila seleccionada en el dataTable
        int fila_seleccionada;

        //Inicializacion de los datos de ubicacion inicial
        double LatInicial = -34.706845093052735;
        double LngInicial = -58.23879250387637;

        int cont = 1; //contador para las ubicaciones seleccionadas
        public int rango = 300; //rango aproximado en metros del alcance del dron
        bool rangoOnOff = false; //indica si ya esta dibujado o no el alcance del dron en el mapa
        int rangMax = 2400; //alcance maximo estimado del drone en metros con bateria llena

        //variables utilizadas para la creacion de poligonos
            //Circulo
        List<PointLatLng> listaCirculo = new List<PointLatLng>();
        GMapOverlay layerCirculo = new GMapOverlay("Capa Circulo");
            //Recorrido
        List<PointLatLng> listaRecorrido = new List<PointLatLng>();
        GMapOverlay layerRecorrido = new GMapOverlay("Capa Recorrido");
/*
 * -Agregar que cuando llegue la ubicacion inicial la agregue como primer punto de la lista    LISTO
 * -Crear la funcion que vaya agregando los puntos que va mandando el dron y a la vez dibuje el recorrido LISTO
 * -Adaptar la funcion de recepcion de datos para que si llega una coordenada, llame a la funcion de dibujar recorrido
 */

        //capa para marcadores llamados desde el puerto serie
        GMapOverlay serialOverlay = new GMapOverlay("Capa Serial");
        int contRuta = 1;//contador para las ubicaciones de 

        //Creo el objeto del Form de conexion serie
        Form_Conexion formCon;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //inicializacion del mapa
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.CanDragMap = true;
            gMapControl.MapProvider = GMapProviders.GoogleMap;
            gMapControl.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl.MinZoom = 0;
            gMapControl.MaxZoom = 24;
            gMapControl.Zoom = 18;
            gMapControl.AutoScroll = true;

            //Marcador
            markerOverlay = new GMapOverlay("Marcador"); //genera una capa por encima del mapa creado
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.blue); //crea el marcador
            markerOverlay.Markers.Add(marker);//Añadir al marcador
            marker.Tag = "Ubicacion Inicial";

            //Añadir un Tooltip (texto) al marcador
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver; //el tooltip aparece cuando se le pone el mouse encima
            marker.ToolTipText = "Ubicacion: Ubicacion Inicial \n Latitud: " + LatInicial + "\n Longitud: " + LngInicial;

            //añadir el overlay al mapa principal
            gMapControl.Overlays.Add(markerOverlay);

            //Añadir el DataTable
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("Latitud", typeof(double)));
            dt.Columns.Add(new DataColumn("Longitud", typeof(double)));

            //Agregar la primera fila y exhibir todo en la interfaz
            dt.Rows.Add("Ubicacion Inicial", LatInicial, LngInicial);
            dataGridView1.DataSource = dt;

            //hacer invisible en la interfaz la latitud y la longitud
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.ReadOnly = true;

            //Dibujo
            datos.Pitch = 0;
            datos.Roll = 0;
            datos.Yaw = 0;
            Dibujar(datos.Pitch, datos.Roll, datos.Yaw);

            #region MovimientoForm
            /*
             * Llamo a funciones de EventHandler cada vez que el mouse se mueve sobre alguno de los elementos de la
             * interfaz para poder moverla de manera manual, ya que retire los bordes en el diseño
             */
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.label4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.label5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.txtDescripcion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.txtLatitud.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.txtLongitud.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMouseMove);
            #endregion
        }

        #region ManejoMarcadores

        private void Seleccionar_registro(object sender, DataGridViewCellMouseEventArgs e)
        {
            fila_seleccionada = e.RowIndex; //devuelve la fila seleccionada

            //inserta los datos seleccionados en el dt y los pone en los textbox
            if (fila_seleccionada >= 0)
            {
                txtDescripcion.Text = dataGridView1.Rows[fila_seleccionada].Cells[0].Value.ToString();
                txtLatitud.Text = dataGridView1.Rows[fila_seleccionada].Cells[1].Value.ToString();
                txtLongitud.Text = dataGridView1.Rows[fila_seleccionada].Cells[2].Value.ToString();
            }

            //centrar el mapa          
            gMapControl.Position = new PointLatLng(Convert.ToDouble(txtLatitud.Text), Convert.ToDouble(txtLongitud.Text));


        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //obtener los datos de lat y lng del lugat donde se hizo doble click
            double lat = gMapControl.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl.FromLocalToLatLng(e.X, e.Y).Lng;

            //inicializar el marcador
            marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(marker);//Añadir al marcador

            //Añado los datos a los textbox
            txtDescripcion.Text = "Ubicacion " + cont;
            txtLatitud.Text = lat.ToString();
            txtLongitud.Text = lng.ToString();
            cont++;

            //Añade la posicion seleccionada al dt
            dt.Rows.Add(txtDescripcion.Text, txtLatitud.Text, txtLongitud.Text);

            //Crear el marcador
            marker.Position = new PointLatLng(lat, lng);

            //agregar el tooltip
            marker.ToolTipText = "Ubicacion: " + txtDescripcion.Text + "\n Latitud: " + lat + "\n Longitud: " + lng;

            //Agregarle un Tag al marker
            marker.Tag = txtDescripcion.Text;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion;

                //Si la casilla esta en blanco, inserta una descripcion por defecto
                if (txtDescripcion.Text != "")
                    descripcion = txtDescripcion.Text;
                else
                { descripcion = "Ubicacion " + cont; cont++; }

                //Agregar los datos al dt
                dt.Rows.Add(descripcion, txtLatitud.Text, txtLongitud.Text);

                //Inicializar el marcador
                marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(txtLatitud.Text), Convert.ToDouble(txtLongitud.Text)), GMarkerGoogleType.red);
                markerOverlay.Markers.Add(marker);//Añadir al marcador

                //Colocar el marcador
                marker.Position = new PointLatLng(Convert.ToDouble(txtLatitud.Text), Convert.ToDouble(txtLongitud.Text));

                //agregar el tooltip
                marker.ToolTipText = "Ubicacion: " + descripcion + "\n Latitud: " + txtLatitud.Text + "\n Longitud: " + txtLongitud.Text;

                //centrar el mapa
                gMapControl.Position = marker.Position;

                //Agregarle un Tag al marker
                marker.Tag = descripcion;
            }
            //Devuelve el error al usuario en caso de realizar una accion no permitida
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error"); } 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Elimina la fila seleccionada en el dt y su marcador correspondiente
                dataGridView1.Rows.RemoveAt(fila_seleccionada);
                markerOverlay.Markers.RemoveAt(fila_seleccionada);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            //En esta seccion tuve que agregar la linea que le pasa el dato de la fila a la variable fila_seleccionada
            double lat = item.Position.Lat;
            double lng = item.Position.Lng;

            int fila = 0;

            //encuentra la fila en la que se ubica el marcador
            for (int x = 0; dataGridView1.Rows[x].Cells[0].Value.ToString() != item.Tag.ToString(); x++) fila = x + 1;

            //Deselecciona todas las filas del dt primero y luego selecciona la fila actual
            for (int i = 0; i != dataGridView1.RowCount; i++) dataGridView1.Rows[i].Selected = false;
            dataGridView1.Rows[fila].Selected = true;
            //IMPORTANTE
            fila_seleccionada = fila;

            //Cuando se hace click sobre un marcador se muestran sus datos en los label
            txtDescripcion.Text = item.Tag.ToString();
            txtLatitud.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
            txtLongitud.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
        }

        //dibujar marcadores en base a las ubicaciones recibidas desde el puerto serie
        public void dibujarMarcador(double Latitud, double Longitud)
        {
            PointLatLng ubicacion = new PointLatLng();
            ubicacion.Lat = Latitud;
            ubicacion.Lng = Longitud;

            //inicializar el marcador
            marker = new GMarkerGoogle(ubicacion, GMarkerGoogleType.orange);
            serialOverlay.Markers.Add(marker);//Añadir al marcador

            string descripcion = "Ruta " + contRuta.ToString();
            string lat = ubicacion.Lat.ToString();
            string lng = ubicacion.Lng.ToString();
            contRuta++;

            //Añade la posicion seleccionada al dt
            dt.Rows.Add(descripcion, lat, lng);

            //Crear el marcador
            marker.Position = ubicacion;

            //agregar el tooltip
            marker.ToolTipText = "Ubicacion: " + descripcion + "\n Latitud: " + lat + "\n Longitud: " + lng;

            //Agregarle un Tag al marker
            marker.Tag = descripcion;
        }

        //elimina a todos los marcadores de la capa de marcadores por puerto serie
        public void borrarMarkSerial()
        {
            serialOverlay.Clear();
        }
        #endregion

        private void btnConexion_Click(object sender, EventArgs e)
        {
            if (formCon == null)
                formCon = new Form_Conexion(this);

                //Abrir el Form de conexion
                formCon.Show(this);            
        }

        #region ComunicacionSerie
        public void coordenadasSerie(double dataLat, double dataLng)
        {
            PointLatLng CoordSerie = new PointLatLng(dataLat, dataLng);

            marker = new GMarkerGoogle(CoordSerie, GMarkerGoogleType.red);
            marker.Tag = "Marcador Serie " + cont.ToString();
            marker.Position = CoordSerie;

            markerOverlay.Markers.Add(marker);
 
            gMapControl.Position = marker.Position;
            
            txtDescripcion.Text = "Ubicacion " + cont;
            txtLatitud.Text = CoordSerie.Lat.ToString();
            txtLongitud.Text = CoordSerie.Lng.ToString();

            dt.Rows.Add(txtDescripcion.Text, txtLatitud.Text, txtLongitud.Text);

            cont++;
        }

        //Recibe un par de coordenadas y las setea como las coordenadas iniciales de la app
        public void coordenadasIniciales(double lat, double lng)
        {
            //Esta es una solucion provisoria ya que tengo problemas con la conversion de string a double en cuanto
            //a la ubicacion del punto decimal
            while (lat > 180 || lat < -180)
                lat /= 10;
            while (lng > 90 || lng < -90)
                lng /= 10;

            LatInicial = lat;
            LngInicial = lng;

            //centrar el mapa
            gMapControl.Position = new PointLatLng(LatInicial, LngInicial);

            //Elimina el marcador y modifica los valores de las celdas
            markerOverlay.Markers.RemoveAt(0);
            dataGridView1.Rows[0].Cells[1].Value = LatInicial;
            dataGridView1.Rows[0].Cells[2].Value = LngInicial;
            dataGridView1.DataSource = dt;

            //Marcador
            markerOverlay = new GMapOverlay("Marcador"); //genera una capa por encima del mapa creado
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.blue); //crea el marcador
            markerOverlay.Markers.Add(marker);//Añadir al marcador
            marker.Tag = "Ubicacion Inicial";

            //Añadir un Tooltip (texto) al marcador
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver; //el tooltip aparece cuando se le pone el mouse encima
            marker.ToolTipText = "Ubicacion: Ubicacion Inicial \n Latitud: " + LatInicial + "\n Longitud: " + LngInicial;

            //añadir el overlay al mapa principal
            gMapControl.Overlays.Add(markerOverlay);
   
            //Limpiar la lista de recorrido para asegurarse de que la coord inical sea el primer miembro
            listaRecorrido.Clear();
            //Agregar el punto inicial a la lista de recorrido
            listaRecorrido.Add(new PointLatLng(LatInicial, LngInicial));
        }
        #endregion

        //Agarra la latitud y la longitud seleccionadas y las envia por el puerto serie
        private void btnUbicacion_Click(object sender, EventArgs e)
        {
            try
            {
                string dato = txtLatitud.Text + ";" + txtLongitud.Text;
                formCon.enviarCoordenadas(dato);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        #region FuncionesSistema


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //Si existe el Formulario de Conexion
            if(formCon != null){
                formCon.Hide();             
                Application.ExitThread();   //Lo esconde y termina la aplicacion
            }
            else { Application.ExitThread(); } //En caso contrario termina la aplicacion directamente
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            if (formCon != null)
            {
                formCon.WindowState = FormWindowState.Minimized;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
        #endregion


        #region ConfigMov
        const int WM_SYSCOMMAND = 0x112;    //Comandos del sistema en hexadecimal
        const int MOUSE_MOVE = 0xF012;

        // Declaraciones del API 
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        // función privada usada para mover el formulario actual 
        private void moverForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0);
        }


        private void FormMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            moverForm();
        }
        #endregion
    

        private void btnRango_Click(object sender, EventArgs e)
        {
            if (!rangoOnOff)  //si el circulo no esta dbujado
            {
                double radio;

                /*
                 * Haciendo calculos para convertir los valores de coordenadas a distancia en metros la unidad
                 * de radio del circulo es de aproximadamente 89m
                 */
                radio = rango / 89.0;

                //Cant de puntos para dibujar el circulo
                int puntos = 360;

                //Angulo entre dos puntos, en radianes
                double angSegmentos = 2 * Math.PI / puntos;

                PointLatLng centro = new PointLatLng();
                centro.Lat = LatInicial;
                centro.Lng = LngInicial;

                double ang;

                for (int i = 1; i <= puntos; i++)
                {
                    //Se crean los puntos variando el angulo y se los agrega a la lista
                    ang = angSegmentos * i;
                    double a = centro.Lat + Math.Sin(ang) * radio / 1000;
                    double b = centro.Lng + Math.Cos(ang) * radio / 1000;

                    PointLatLng marca = new PointLatLng(a, b);
                    listaCirculo.Add(marca);

                }

                //Se crea el poligono Circulo
                GMapPolygon circulo = new GMapPolygon(listaCirculo, "Circulo");
                //Se agrega el circulo a la capa
                layerCirculo.Polygons.Add(circulo);
                //Se agrega la capa al mapa
                gMapControl.Overlays.Add(layerCirculo);
                //Se actualiza el mapa
                //gMapControl1.Refresh();
                gMapControl.Zoom++;
                gMapControl.Zoom--;

                //Se limpia la lista para el proximo circulo
                listaCirculo.Clear();

                //Se indica que el rango esta dbujado
                rangoOnOff = true;
            }
            else
            {
                layerCirculo.Polygons.Clear();
                //Se indica que el circulo esta borrado
                rangoOnOff = false;
            }

        }

        //Actualiza la posicion del Form_Conexion cada vez que se mueva el formulario principal
        private void Form_Main_LocationChanged(object sender, EventArgs e)
        {
            if(formCon != null)
            formCon.Location = this.Location;
        }
        
        //recibe el dato del nivel de bateria, lo señala y calcula el rango
        public void nivelBateria(int nivel)
        {
            //limita el rango maximo y minimo
            if (nivel > 100) { nivel = 100; }
            if (nivel < 0) { nivel = 0; }

            //establece el nivel de bateria
            pbNivelBat.Value = nivel;
            lblBateria.Text = nivel + "%";

            rango = (rangMax * nivel) / 100;
        }

        private void Form_Main_Minimizado()
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                formCon.WindowState = FormWindowState.Minimized;
            }
        }

        //Funcion que recibe una coordenada, la agrega a la lista del recorrido y lo dibuja
        public void dibujarRecorrido(double lat, double lng)
        {
            PointLatLng punto = new PointLatLng();
            punto.Lat = lat;
            punto.Lng = lng;

            //////////////////Polilinea
            //Se agrega el punto recibido a la lista de puntos
            listaRecorrido.Add(punto);

            //Se crea el poligono Circulo
            GMapPolygon recorrido = new GMapPolygon(listaCirculo, "Circulo");

            //Se agrega el recorrido a la capa
            layerRecorrido.Polygons.Add(recorrido);

            //Se agrega la capa al mapa
            gMapControl.Overlays.Add(layerRecorrido);

            //Se actualiza el mapa
            gMapControl.Zoom++;
            gMapControl.Zoom--;

        }

        #region Dibujo
        public void Dibujar(int pitch, int roll, int yaw)
        {
            #region Config
            /**** Configuracion ******/
            //Reescalado
            int scl;
            if (pictureBox1.Width <= pictureBox1.Height) { scl = pictureBox1.Width; }
            else { scl = pictureBox1.Height; }

            //Valor de pitch
            int Vpitch = 0;  //el valor de pitch tiene su 0 en el centro del instrumento y toma valores pos hacia abajo
            //Valor del Yaw
            int VYaw = 0;
            //Angulo de roll
            double ARoll = 0; //se lo inicializa a 0

            //centro de la pantalla
            Point centro = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2); //punto central
            //Puntos del rectangulo de gnd
            Point[] gnd = new Point[4];
            //Puntos lineas largas
            Point a = new Point(); //primer punto de la linea
            Point b = new Point(); // segundo
            Point t = new Point(); //punto del texto
            /* 
             * Se utilizan dos puntos en relacion a las lineas de pitch, centLineas se utilizara como el punto central
             * sobre el cual rotara cada linea (se varia en el for) y PPitch es el punto central de todas las lineas de pitch
             * (se podria decir que es el punto central de la linea 0) que se vera afectado por la variacion de pitch y yaw
             */
            //Punto central de cada linea
            Point centLineas = new Point(centro.X, centro.Y); //Lo inicializo en el mismo lugar que el centro de la pantalla
            //Punto central
            Point PCentral = new Point(centro.X, centro.Y);
            //Colores para el dibujo
            Color cielo = Color.SteelBlue;
            Color tierra = Color.Chocolate;

            //Rectangulo de gnd
            int adjV = 90; //Angulo de ajuste para lineas verticales
            int lngGnd = scl * 300;

            //Lineas
            int lngLinL = scl / 5; //Longitud de las lineas largas
            int lngLinC = scl / 8; //Longitud de las lineas cortas
            int sepLin = scl / 4; //Factor de separacion de las lineas
            //Grosor de las lineas
            float grosor = scl * 3 / 300; //El 300 se usa porque el bitmap original se hizo con un tamaño de 300px

            //Fuente
            int fuente = scl / 16;
            if (fuente < 1) { fuente = 1; } //Evita que la fuente sea menor a 1

            //Inicializacion
            horizonte = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grafico = Graphics.FromImage(horizonte);
            //Brushes
            pincelBlanco = new SolidBrush(Color.White);
            pincelRojo = new SolidBrush(Color.Red);
            pincelNegro = new SolidBrush(Color.Black);
            pincelGris = new SolidBrush(Color.LightGray);
            pincelTierra = new SolidBrush(tierra);
            pincelCielo = new SolidBrush(cielo); //Teal, Aqua
            //Lapices
            lapizBlanco = new Pen(pincelBlanco, grosor);
            lapizRojo = new Pen(pincelRojo, grosor);
            lapizNegro = new Pen(pincelNegro, grosor);
            lapizGris = new Pen(pincelGris, grosor);
            lapizTierra = new Pen(pincelTierra, grosor);
            lapizCielo = new Pen(pincelCielo, grosor);

            Arial = new Font("Arial", fuente);
            #endregion

            /******** Comandos *****************/

            Vpitch = pitch;

            VYaw = yaw;
            
            ARoll = roll * 360 / 100;


            PCentral.X = (int)(centro.X + (Vpitch * Math.Cos((ARoll + adjV) * Math.PI / 180)));
            PCentral.Y = (int)(centro.Y + (Vpitch * Math.Sin((ARoll + adjV) * Math.PI / 180)));

            PCentral.X = (int)(PCentral.X + (VYaw * Math.Cos((ARoll) * Math.PI / 180)));
            PCentral.Y = (int)(PCentral.Y + (VYaw * Math.Sin((ARoll) * Math.PI / 180)));

            /******** Dibujo Base del Horizonte *********/
            grafico.Clear(cielo);
            //dibujar rectangulo del suelo
            Point baseRec = new Point();
            baseRec.X = (int)(PCentral.X + ((scl / 4) * 18 * Math.Cos((ARoll + adjV) * Math.PI / 180)));
            baseRec.Y = (int)(PCentral.Y + ((scl / 4) * 18 * Math.Sin((ARoll + adjV) * Math.PI / 180)));

            //Rectangulo
            gnd[0].X = (int)(PCentral.X + (lngGnd * Math.Cos((180 + ARoll) * Math.PI / 180)));
            gnd[0].Y = (int)(PCentral.Y + (lngGnd * Math.Sin((180 + ARoll) * Math.PI / 180)));
            gnd[1].X = (int)(PCentral.X + (lngGnd * Math.Cos((ARoll) * Math.PI / 180)));
            gnd[1].Y = (int)(PCentral.Y + (lngGnd * Math.Sin((ARoll) * Math.PI / 180)));
            gnd[2].X = (int)(baseRec.X + (lngGnd * Math.Cos((ARoll) * Math.PI / 180)));
            gnd[2].Y = (int)(baseRec.Y + (lngGnd * Math.Sin((180 + ARoll) * Math.PI / 180)));
            gnd[3].X = (int)(baseRec.X + (lngGnd * Math.Cos((ARoll) * Math.PI / 180)));
            gnd[3].Y = (int)(baseRec.Y + (lngGnd * Math.Sin((ARoll) * Math.PI / 180)));

            //Dibujo
            grafico.DrawPolygon(lapizBlanco, gnd);
            grafico.FillPolygon(pincelTierra, gnd);

            /*********** Dibujo lineas de altitud *******************/

            //Lineas largas
            //Texto
            Size textoChico = new Size(scl / 8, scl / 8);
            Size textoGrande = new Size(scl / 6, scl / 6);

            PointF[] recGrande = new PointF[4];

            int sepTxt = scl / 30; //Separacion del texto con respecto a las lineas
            int txtWidth = scl / 40; //Anchura del cuadro de texto
            int txtHeight = scl / 80; //Mitad de la altura del cuadro de texto
            //Lineas superiores
            for (int i = 0; i < 18; i++)
            {
                centLineas.X = (int)(PCentral.X + (i * sepLin * Math.Cos((adjV - ARoll) * Math.PI / 180)));
                centLineas.Y = (int)(PCentral.Y - (i * sepLin * Math.Sin((adjV - ARoll) * Math.PI / 180)));

                a.X = (int)(centLineas.X + (lngLinL * Math.Cos((180 + ARoll) * Math.PI / 180)));
                a.Y = (int)(centLineas.Y + (lngLinL * Math.Sin((180 + ARoll) * Math.PI / 180)));

                b.X = (int)(centLineas.X + (lngLinL * Math.Cos((ARoll) * Math.PI / 180)));
                b.Y = (int)(centLineas.Y + (lngLinL * Math.Sin((ARoll) * Math.PI / 180)));

                grafico.DrawLine(lapizBlanco, a, b);

                //Para hacer el texto voy a tener que crear una caja y ubicarlo dentro
                //recGrande[0].X = (float)(a.X - (sepTxt * Math.Cos((ARoll) * Math.PI / 180)));
                //recGrande[0].Y = (float)(a.Y - (txtHeight * Math.Sin((ARoll) * Math.PI / 180)));
                //recGrande[1].X = (float)(recGrande[0].X + (txtWidth * Math.Cos((ARoll) * Math.PI / 180)));
                //recGrande[1].Y = recGrande[0].Y;
                //recGrande[2].X = (float)(a.X - (sepTxt * Math.Cos((ARoll) * Math.PI / 180)));
                //recGrande[2].Y = (float)(a.Y + (txtHeight * Math.Sin((ARoll) * Math.PI / 180)));
                //recGrande[3].X = (float)(recGrande[2].X + (txtWidth * Math.Cos((ARoll) * Math.PI / 180)));
                //recGrande[3].Y = recGrande[2].Y;

                //t.Y = a.Y - scl / 20;
                //if (i == 0) { t.X += scl / 40; } //Ajuste de 0
                //grafico.DrawString((i * 10).ToString(), Arial, pincelBlanco, t);
                //if (i == 0) { t.X -= scl / 40; }
            }

            t.X -= scl / 60; //ajuste por el '-'
            //Lineas inferores
            for (int i = 1; i < 17; i++)
            {
                centLineas.X = (int)(PCentral.X - (i * sepLin * Math.Cos((adjV - ARoll) * Math.PI / 180)));
                centLineas.Y = (int)(PCentral.Y + (i * sepLin * Math.Sin((adjV - ARoll) * Math.PI / 180)));

                a.X = (int)(centLineas.X + (lngLinL * Math.Cos((180 + ARoll) * Math.PI / 180)));
                a.Y = (int)(centLineas.Y + (lngLinL * Math.Sin((180 + ARoll) * Math.PI / 180)));

                b.X = (int)(centLineas.X + (lngLinL * Math.Cos((ARoll) * Math.PI / 180)));
                b.Y = (int)(centLineas.Y + (lngLinL * Math.Sin((ARoll) * Math.PI / 180)));

                grafico.DrawLine(lapizBlanco, a, b);
            }

            //Lineas cortas
            //Lineas Superiores
            for (int i = 0; i < 18; i++)
            {
                centLineas.X = (int)(PCentral.X + ((i * sepLin - (sepLin / 2)) * Math.Cos((adjV - ARoll) * Math.PI / 180)));
                centLineas.Y = (int)(PCentral.Y - ((i * sepLin - (sepLin / 2)) * Math.Sin((adjV - ARoll) * Math.PI / 180)));

                a.X = (int)(centLineas.X + (lngLinC * Math.Cos((180 + ARoll) * Math.PI / 180)));
                a.Y = (int)(centLineas.Y + (lngLinC * Math.Sin((180 + ARoll) * Math.PI / 180)));

                b.X = (int)(centLineas.X + (lngLinC * Math.Cos((ARoll) * Math.PI / 180)));
                b.Y = (int)(centLineas.Y + (lngLinC * Math.Sin((ARoll) * Math.PI / 180)));

                grafico.DrawLine(lapizBlanco, a, b);

            }

            t.X -= scl / 60; //ajuste por el '-'
            //Lineas inferores
            for (int i = 1; i < 17; i++)
            {
                centLineas.X = (int)(PCentral.X - ((i * sepLin + (sepLin / 2)) * Math.Cos((adjV - ARoll) * Math.PI / 180)));
                centLineas.Y = (int)(PCentral.Y + ((i * sepLin + (sepLin / 2)) * Math.Sin((adjV - ARoll) * Math.PI / 180)));

                a.X = (int)(centLineas.X + (lngLinC * Math.Cos((180 + ARoll) * Math.PI / 180)));
                a.Y = (int)(centLineas.Y + (lngLinC * Math.Sin((180 + ARoll) * Math.PI / 180)));

                b.X = (int)(centLineas.X + (lngLinC * Math.Cos((ARoll) * Math.PI / 180)));
                b.Y = (int)(centLineas.Y + (lngLinC * Math.Sin((ARoll) * Math.PI / 180)));

                grafico.DrawLine(lapizBlanco, a, b);
            }

            /******* Dibujo reticula central (fija) ************/

            //Punto central
            Point puntoCentral = new Point(); //Punto inicial del rectangulo que contiene al punto central
            puntoCentral.X = pictureBox1.Width / 2 - (scl / 150);
            puntoCentral.Y = pictureBox1.Height / 2 - (scl / 150); //Escalado
            Rectangle recCentral = new Rectangle(puntoCentral.X, puntoCentral.Y, scl / 75, scl / 75);
            grafico.DrawEllipse(lapizRojo, recCentral);
            grafico.FillEllipse(pincelRojo, recCentral);

            //Lineas
            grafico.DrawLine(lapizRojo, centro.X - scl / 4, centro.Y, centro.X - scl / 20, centro.Y);
            grafico.DrawLine(lapizRojo, pictureBox1.Width - scl / 4, centro.Y, centro.X + scl / 20, centro.Y);

            //Circulo
            grafico.DrawArc(lapizRojo, centro.X - scl / 20, centro.Y - scl / 20, scl / 10, scl / 10, 0, 180);


            //Borde del instrumento
            grafico.DrawEllipse(lapizBlanco, 0, 0, pictureBox1.Width, pictureBox1.Height); //Creo el borde del horizonte
            //Creo un Path, que es una serie de segmentos, que en este caso utilizo como el area a rellenar
            GraphicsPath area = new GraphicsPath(); 
            area.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height); //Agrego el circulo interior
            //Agrego un circulo exterior mas grande
            area.AddEllipse(-(pictureBox1.Width / 2), -(pictureBox1.Height / 2), pictureBox1.Width * 2, pictureBox1.Height * 2);
            //Relleno el area creada
            grafico.FillPath(pincelNegro, area); 

            //Referencia de horizonte
            int altTrg = scl / 10; //Mitad de la altura del triangulo de referencia
            int lrgTrg = scl / 7; //Anchura de los triangulos de referecia

            Point[] trgL = new Point[3]; //Triangulo izquierdo
            Point[] trgR = new Point[3]; //Triangulo derecho

            trgL[0].X = trgL[2].X = 0;
            trgL[1].X = lrgTrg;
            trgL[0].Y = centro.Y - altTrg;
            trgL[1].Y = centro.Y;
            trgL[2].Y = centro.Y + altTrg;

            grafico.DrawPolygon(lapizNegro, trgL);
            grafico.FillPolygon(pincelGris, trgL);

            trgR[0].X = trgR[2].X = pictureBox1.Width;
            trgR[1].X = pictureBox1.Width - lrgTrg;
            trgR[0].Y = centro.Y - altTrg;
            trgR[1].Y = centro.Y;
            trgR[2].Y = centro.Y + altTrg;

            grafico.DrawPolygon(lapizNegro, trgR);
            grafico.FillPolygon(pincelGris, trgR);

            //Referencia de Viraje
            double sepBrg = scl / 2; //Separacion con respecto al centro de las lineas de viraje
            Point[] brg15L = new Point[2];
            Point[] brg15R = new Point[2];

            brg15R[0].X = (int)(centro.X + (sepBrg * Math.Cos((-90 + 15) * Math.PI / 180)));
            brg15R[0].Y = (int)(centro.Y + (sepBrg * Math.Sin((-90 + 15) * Math.PI / 180)));
            brg15R[1].X = (int)(centro.X + (sepBrg * 2 * Math.Cos((-90 + 15) * Math.PI / 180)));
            brg15R[1].Y = (int)(centro.Y + (sepBrg * 2 * Math.Sin((-90 + 15) * Math.PI / 180)));

            brg15L[0].X = (int)(centro.X + (sepBrg * Math.Cos((-90 - 15) * Math.PI / 180)));
            brg15L[0].Y = (int)(centro.Y + (sepBrg * Math.Sin((-90 - 15) * Math.PI / 180)));
            brg15L[1].X = (int)(centro.X + (sepBrg * 2 * Math.Cos((-90 - 15) * Math.PI / 180)));
            brg15L[1].Y = (int)(centro.Y + (sepBrg * 2 * Math.Sin((-90 - 15) * Math.PI / 180)));

            Point[] brg30L = new Point[2];
            Point[] brg30R = new Point[2];

            brg30R[0].X = (int)(centro.X + (sepBrg * Math.Cos((-90 + 30) * Math.PI / 180)));
            brg30R[0].Y = (int)(centro.Y + (sepBrg * Math.Sin((-90 + 30) * Math.PI / 180)));
            brg30R[1].X = (int)(centro.X + (sepBrg * 2 * Math.Cos((-90 + 30) * Math.PI / 180)));
            brg30R[1].Y = (int)(centro.Y + (sepBrg * 2 * Math.Sin((-90 + 30) * Math.PI / 180)));

            brg30L[0].X = (int)(centro.X + (sepBrg * Math.Cos((-90 - 30) * Math.PI / 180)));
            brg30L[0].Y = (int)(centro.Y + (sepBrg * Math.Sin((-90 - 30) * Math.PI / 180)));
            brg30L[1].X = (int)(centro.X + (sepBrg * 2 * Math.Cos((-90 - 30) * Math.PI / 180)));
            brg30L[1].Y = (int)(centro.Y + (sepBrg * 2 * Math.Sin((-90 - 30) * Math.PI / 180)));

            Point[] brg45L = new Point[2];
            Point[] brg45R = new Point[2];

            brg45R[0].X = (int)(centro.X + (sepBrg * Math.Cos((-90 + 45) * Math.PI / 180)));
            brg45R[0].Y = (int)(centro.Y + (sepBrg * Math.Sin((-90 + 45) * Math.PI / 180)));
            brg45R[1].X = (int)(centro.X + (sepBrg * 2 * Math.Cos((-90 + 45) * Math.PI / 180)));
            brg45R[1].Y = (int)(centro.Y + (sepBrg * 2 * Math.Sin((-90 + 45) * Math.PI / 180)));

            brg45L[0].X = (int)(centro.X + (sepBrg * Math.Cos((-90 - 45) * Math.PI / 180)));
            brg45L[0].Y = (int)(centro.Y + (sepBrg * Math.Sin((-90 - 45) * Math.PI / 180)));
            brg45L[1].X = (int)(centro.X + (sepBrg * 2 * Math.Cos((-90 - 45) * Math.PI / 180)));
            brg45L[1].Y = (int)(centro.Y + (sepBrg * 2 * Math.Sin((-90 - 45) * Math.PI / 180)));

            grafico.DrawLine(lapizBlanco, brg15R[0], brg15R[1]);
            grafico.DrawLine(lapizBlanco, brg15L[0], brg15L[1]);

            grafico.DrawLine(lapizBlanco, brg30R[0], brg30R[1]);
            grafico.DrawLine(lapizBlanco, brg30L[0], brg30L[1]);

            grafico.DrawLine(lapizBlanco, brg45R[0], brg45R[1]);
            grafico.DrawLine(lapizBlanco, brg45L[0], brg45L[1]);

            //IMPORTANTE colocar la imagen creada en el picturebox al final de la funcion
            pictureBox1.Image = horizonte;
        }
        #endregion
    }
}
