/*
 * Acordar de que manera se va a realizar la comunicacion. Principalmente la cantidad de datos que voy a manejar
 * y si tengo que implementar algun protocolo. El problema es que el puto de diego no quiere decirme que verga quiere hacer.
 * Ahora queda definir si alguno de los datos recibidos necesita se adaptado, en caso contrario ya esta todo terminado.
 * Ademas tengo que agregar la recepcion de los datos del pitch.
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
using System.Globalization;

namespace Primera_aplicacion
{
    public partial class Form_Conexion : Form
    {
        Boolean conectado = false; //Indica si ya se abrio el puerto serie
        Boolean init = false; //indica si la app esta inicializada

        public double datosLat = 0, datosLng = 0; //Datos de coordenadas
        string initCom = "i"; //Caracteres enviados para hacer saber que la app esta funcionando 
        int comErr = 0; //Contador de errores en el formato de datos de la comunicacion
        int contSetup = 0; //Contador de intentos fallidos en comenzar la comunicacion
        //bool conOK = false; //Establece si se pudo establecer correctamente la comunicacion
        Form_Main Form_Main; //Creo un objeto referenciando al Formulario principal

        // Declara el delegado que presentara lo recibido en el formulario. Debido a que la funcion
        //en la que se emplea es del tipo string, el delegado es del mismo tipo
        delegate string NuevoDato();

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
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            Conectar();
        }

        private void Conectar()
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

                    if(!init)
                    {
                        Setup();
                    }
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
            try
            {
            
            /*
             * Recepcion de datos universal
             */
                string datos = recibirDatos();
                //Separa los datos recibidos
                string[] Dts = datos.Split(new Char[] { ';' });

                distribucionDatos(Dts);
                
            }
            catch{}
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

        //Separa los datos recibidos y los envia al Formulario principal
        private void distribucionDatos(string[] data)
        {
            if (data.Length == 5) //Verifica que haya 5 datos en el array
            {
                //Enviar datos de ubicacion
                Form_Main.coordenadasSerie(double.Parse(data[0]), double.Parse(data[1]));
                //Establecer nivel de bateria y rango
                Form_Main.nivelBateria(Convert.ToInt16(data[2]));
                //Inicializa el horizonte
                Form_Main.Dibujar(Convert.ToInt16(data[3]), Convert.ToInt16(data[4]), 0); //Esta suprimido el mov en Yaw
            }
            else //En caso contrario, el formato de datos es incorrecto
            {
                if(++comErr == 10) //Si se encuentran 10 errores (no mas porque se repetiria muchas veces el proceso)
                {
                    MessageBox.Show("Error en la comunicacion", "Error"); //Tira un mensaje de error
                    conectado = true;
                    Conectar(); //Desconecta el form
                }
            }
        }

        //inicializa la parte de comunicacion de la app
        private void Setup()
        {
            string datoSerie;

            //envia los datos de inicio
            datoSerie = iniciarCom();
            if (datoSerie == "") //Si no llegan datos a la entrada
            {
                if (++contSetup >= 100)
                {
                    MessageBox.Show("Error en la comunicaion con tierra", "Error"); //Muestra el error
                    conectado = true;
                    Conectar();         //Desconecta la app
                    init = false;
                    contSetup = 0;
                }
                else
                    Setup(); //En caso contrario vuelve a intentarlo
            }
            else
            {
                string[] Dts = datoSerie.Split(new Char[] { ';' }, 5); //separa la latitud, longitud, bateria, y aptitud
                //setea las coordenadas iniciales
                Form_Main.coordenadasIniciales(double.Parse(Dts[0]), double.Parse(Dts[1]));
                //establecer nivel de bateria y rango
                Form_Main.nivelBateria(Convert.ToInt16(Dts[2]));
                //Inicializa el horizonte
                Form_Main.Dibujar(Convert.ToInt16(Dts[3]), Convert.ToInt16(Dts[4]), 0);
                //El setup se realizo correctamente
                init = true;
                //conOK = true;
            }
            
        }

        //Envia el string de inicio, espera a recibir datos y los devuelve
        private string iniciarCom()
        {
            string data = "";
            try
            {
                serialPort1.Write(initCom); //Se enviar un dato indicando que se abrio la conexion
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            conectado = true;
            init = false;
            Conectar();
        }

        private void boxCom_DropDown(object sender, EventArgs e)
        {
            bool añadido = false;

            boxCom.Items.Clear();

            string[] puertos = new string[50];
            puertos = SerialPort.GetPortNames();
            
            foreach(string puerto in puertos)
            {
                if (puerto == null)
                    break;
                boxCom.Items.Add(puerto);
                añadido = true;
            }

            if (!añadido)
                boxCom.Items.Add("No hay puertos disponibles");
        }

    }
}
