/*
 * 
 * Finalizar con las funciones de puerto serie para que manejen el protocolo final
 * Arreglar el movimiento del formulario
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.IO.Ports;

namespace Primera_aplicacion
{
    public partial class Form_Conexion : Form
    {
        Boolean conectado = false;

        public double datosLat = 0, datosLng = 0;
        string initCom = "in"; //Caracteres enviados para hacer saber que la app esta funcionando 
        Form_Main Form_Main;

        // Declara el delegado que presentara lo recibido en el formulario. Debido a que la funcion en la que se emplea es del tipo string, el 
        //delegado es del mismo tipo
        delegate string NuevoDato();

        /* Esta variable la utilizo para la funcion void de recibir datos. Todas las demas funciones agarran el valor desde esta variable*/  //((INUTIL))
        //string datosSerie = "";

        //En el constructor del Form hijo agrego como parametro al form principal para que Form_Conexion
        //lo reconozca como padre
        public Form_Conexion(Form_Main nombre)
        {
            InitializeComponent();
            Form_Main = nombre;
        }

        private void Form_Conexion_Load(object sender, EventArgs e)
        {
            //Escondo esta ventana
            this.Location = Form_Main.Location;
            this.Hide();

            //this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ConFormMouseMove);
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            if (!conectado)  //Si no esta conectado el puerto, realizar la conexión
            {
                try
                {
                    //Definir los parámetros de la comunicación serial 
                    serialPort1.PortName = boxCom.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.Parity = Parity.None;
                    serialPort1.DataBits = 8;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();  //Abrir la conexión

                    conectado = true;

                    lblConectar.Text = "Conectado";
                    lblConectar.BackColor = Color.Green;
                }
                catch (Exception ex)   // Código de error
                {
                    MessageBox.Show("Error en la conexión " + ex.Message);
                    serialPort1.Close(); //Cerrar la conexión
                }
            }
            else   //Cerrar conexión.
            {
                if (serialPort1 != null)
                    serialPort1.Close();

                conectado = false;

                lblConectar.Text = "Desconectado";
                lblConectar.BackColor = Color.Firebrick;
            }


        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //Crea el dato a enviar
            string dato = txtEnviarLat.Text + ";" + txtEnviarLong.Text;

            enviarCoordenadas(dato);
        }

        //region comentada
        #region SerialPort old
        //private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    Recibir();
        //}

        //private void Recibir()
        //{
        //    /*Obtiene un valor que indica si el llamador debe llamar a un método de invocación cuando realiza llamadas 
        //     * a métodos del control porque el llamador se encuentra 
        //     * en un subproceso distinto al del control donde se creó.
        //     * true si Handle del control se creó en un subproceso distinto al subproceso que realiza la llamada 
        //     * (lo que indica que debe realizar llamadas al control mediante un método de invocación); 
        //     * en caso contrario, false. 
        //    */
        //    if (this.InvokeRequired)
        //    {
        //        NuevoDato ND = new NuevoDato(Recibir);
        //        //Ejecuta un delegado en el subproceso que posee el identificador de ventana subyacente del control.
        //        this.Invoke(ND);
        //    }
        //    else
        //    {
        //        string datos = Convert.ToString(serialPort1.ReadExisting());
        //        //Recibe los datos desde el puerto serie y los separa en latitud y longitud
        //        string[] Dts = datos.Split(new Char[] { ';' }, 2);
        //        datosLat = Convert.ToDouble(Dts[0]);
        //        datosLng = Convert.ToDouble(Dts[1]);
        //        txt_Recibir_Lat.Text = Dts[0];
        //        txt_Recibir_Long.Text = Dts[1];

        //        //envia las coordenadas al Form_Main para que las muestre en el mapa
        //        Form_Main.coordenadasSerie(datosLat, datosLng);
        //    }
        //}
        #endregion  

        //Revisa el puerto serie y devuelve lo que encuentre como un string
        private string recibirDatos()
        {
            string datos = "";

            if (this.InvokeRequired)
            {
                NuevoDato ND = new NuevoDato(recibirDatos);
                //Ejecuta un delegado en el subproceso que posee el identificador de ventana subyacente del control.
                this.Invoke(ND);
            }
            else
            {
                datos = Convert.ToString(serialPort1.ReadExisting());
            }
            return datos;
        }
        /* MISMA FUNCION QUE LA DE ARRIBA PERO VOID */ // ((por ahora inutil))
        #region Copia
        //private string recibirDatos()
        //{
        //    string datos = "";

        //    //if (this.InvokeRequired)
        //    //{
        //    //    NuevoDato ND = new NuevoDato(recibirDatos); //no puedo llamar a un delegado para una funcion string, tengo que resolverlo
        //    //    //Ejecuta un delegado en el subproceso que posee el identificador de ventana subyacente del control.
        //    //    this.Invoke(ND);
        //    //}
        //    //else
        //    //{
        //        datos = Convert.ToString(serialPort1.ReadExisting());
        //    //}
        //    return datos;
        //}
        #endregion

        //inicializa la parte de comunicacion de la app
        private void Setup()
        {
            /*
             * -Enviar aviso de que inicio la app                        
             * -Recbir datos de Coordenadas iniciales (y bateria)        
             * -Setear las Coordenadas Iniciales en el Main              
             */
            string coordenadas;

            iniciarCom();
            while (serialPort1.BytesToRead == 0) { }
            coordenadas = recibirDatos();  //lee el puerto serie
            string[] Dts = coordenadas.Split(new Char[] { ';' }, 2); //separa la lat de la longitud
            Form_Main.coordenadasIniciales(Convert.ToDouble(Dts[0]), Convert.ToDouble(Dts[1]));
        }

        //Mantiene abierto el form
        private void Form_Conexion_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        //Envia el string de inicio, espera a recibir datos y los devuelve
        private string iniciarCom()
        {
            string data = "";
            serialPort1.WriteLine(initCom);
            while (serialPort1.BytesToRead == 0) { } //Espera a que haya datos que leer
            data = recibirDatos();    //Funcion para recibir los datos del puerto serie
            serialPort1.DiscardInBuffer(); //Limpia el Buffer de entrada
            return data;
        }

        //Funcion provisoria que solamente envia coordenadas por el puerto serie
        public void enviarCoordenadas(string dato)
        {
            //Si esta conectado, envia los datos de las textbox
            if (conectado) serialPort1.WriteLine(dato);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #region CopiadoDeInternet
        const int WM_SYSCOMMAND = 0x112;
        const int MOUSE_MOVE = 0xF012;

        // Declaraciones del API 
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        // 
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        // 
        // función privada usada para mover el formulario actual 

        //private void ConMoverForm()
        //{
        //    ReleaseCapture();
        //    SendMessage(this.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0);
        //}

        //public void ConFormMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    ConMoverForm();
        //}

        #endregion

        /*No funciona*/
        public void reajustarPos(Point posicion)
        {
            if (this.Visible)
            {
                this.Location = posicion;
                this.Hide();
                this.Show();
            }
        }
        /********************/
    }
}
