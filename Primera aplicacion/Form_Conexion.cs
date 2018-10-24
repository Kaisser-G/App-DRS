/*
 * Revisar en la funcion setup la cantidad de datos a recibir
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


        //En el constructor del Form hijo agrego como parametro al form principal para que Form_Conexion
        //lo reconozca como padre
        public Form_Conexion(Form_Main nombre)
        {
            InitializeComponent();
            Form_Main = nombre;
       //     this.MdiParent = Form_Main;
        }

        private void Form_Conexion_Load(object sender, EventArgs e)
        {
            //Escondo esta ventana
            this.Location = Form_Main.Location;
            this.Hide();

            //Asigna la funcion de movimiento para las acciones de hacer click sobre partes del formulario
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ConFormMouseMove);
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ConFormMouseMove);
            this.lblConectar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ConFormMouseMove);
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


        #region SerialPort
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            #region Ubicacion
            /*
             * Recibir los datos de la ubicacion y mostrarlos en el mapa
             */
            string datos;
            datos = recibirDatos();
            string[] Dts = datos.Split(new Char[] { ';' });
            if (Dts.Length <= 2) 
            {
                double lat = Convert.ToDouble(Dts[0]);
                double lng = Convert.ToDouble(Dts[1]);
                Form_Main.dibujarMarcador(lat, lng);
            }
            #endregion
        }
        #endregion  

        #region ComSerie
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

        //inicializa la parte de comunicacion de la app
        private void Setup()
        {
            /*
             * -Enviar aviso de que inicio la app                        
             * -Recbir datos de Coordenadas iniciales (y bateria)        
             * -Setear las Coordenadas Iniciales en el Main              
             */
            string coordenadas;

            //envia los datos de inicio
            iniciarCom();
            //espera a que lleguen datos por el puerto serie
            while (serialPort1.BytesToRead == 0) { }
            coordenadas = recibirDatos();  //lee el puerto serie
            string[] Dts = coordenadas.Split(new Char[] { ';' }, 2); //separa la lat de la longitud
            //setea las coordenadas iniciales
            Form_Main.coordenadasIniciales(Convert.ToDouble(Dts[0]), Convert.ToDouble(Dts[1]));
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
#endregion

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

   #region MovForm
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

        private void ConMoverForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0);
        }

        private void ConFormMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ConMoverForm();
        }

        #endregion

    }
}
