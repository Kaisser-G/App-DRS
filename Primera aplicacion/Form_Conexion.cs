/*
 * Tengo que crear una funcion que solamente recba los datos del puerto serie y los devuelva
 * 
 * 
 * -Iniciar app
 * -Enviar aviso de que inicio la app
 * -Recbir datos de Coordenadas iniciales (y bateria)
 * -Setear las Coordenadas Iniciales en el Main
 * -Colocar los marcadores en el main
 * -Enviar el marcador seleccionado por puerto serie (desde el main)
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

        // Declara el delegado que presentara lo recibido en el formulario
        delegate void NuevoDato();

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
            this.Hide();
            //Creo el objeto del Form Principal para poder acceder a sus parametros
            //Form_Main Form_Main = new Form_Main();
            /*OBSERVACION:
             * Si creo el objeto del Form_Main al principio de la clase se genera un error por stack overflow, un loop infinito
             */
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            if (!conectado)  //Si no esta conectado el puerto, realizar la conexión
            {
                try
                {
                    //Definir los parámetros de la comunicación serial 
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort1.Parity = Parity.None;
                    serialPort1.DataBits = 8;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();  //Abrir la conexión
                    lbl_Conectar.Text = "Status: Conectado";
                    conectado = true;
                }
                catch (Exception ex)   // Código de error
                {
                    MessageBox.Show("Error en la conexión " + ex.Message);
                    serialPort1.Close(); //Cerrar la conexión
                }
            }
            else   //Cerrar conexión.
            {
                lbl_Conectar.Text = "Status: Desconectado";
                conectado = false;
                if (serialPort1 != null)
                    serialPort1.Close();
            }
        }

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            //Si esta conectado, envia los datos de las textbox
            if (conectado) serialPort1.WriteLine(Convert.ToString(txt_Enviar_Lat.Text) + ";" + Convert.ToString(txt_Enviar_Long.Text));
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Recibir();
        }

        private void Recibir()
        {
            /*Obtiene un valor que indica si el llamador debe llamar a un método de invocación cuando realiza llamadas 
             * a métodos del control porque el llamador se encuentra 
             * en un subproceso distinto al del control donde se creó.
             * true si Handle del control se creó en un subproceso distinto al subproceso que realiza la llamada 
             * (lo que indica que debe realizar llamadas al control mediante un método de invocación); 
             * en caso contrario, false. 
            */
            if (this.InvokeRequired)
            {
                NuevoDato ND = new NuevoDato(Recibir);
                //Ejecuta un delegado en el subproceso que posee el identificador de ventana subyacente del control.
                this.Invoke(ND);
            }
            else
            {
                string datos = Convert.ToString(serialPort1.ReadExisting());
                //Recibe los datos desde el puerto serie y los separa en latitud y longitud
                string[] Dts = datos.Split(new Char[] { ';' }, 2);
                datosLat = Convert.ToDouble(Dts[0]);
                datosLng = Convert.ToDouble(Dts[1]);
                txt_Recibir_Lat.Text = Dts[0];
                txt_Recibir_Long.Text = Dts[1];

                //envia las coordenadas al Form_Main para que las muestre en el mapa
                Form_Main.coordenadasSerie(datosLat, datosLng);
            }
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
            string data = "0";
            serialPort1.WriteLine(initCom);
            while (serialPort1.BytesToRead == 0) { }
            //data = serialPort1.Read    //Funcion para recibir los datos del puerto serie
            return data;
        }

    }
}
