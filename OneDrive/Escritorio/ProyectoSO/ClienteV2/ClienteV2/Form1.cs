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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClienteV3
{
    public partial class Preguntados : Form
    {
        Socket server;
        Thread atender;

        string usuario;
        int conectado;

        delegate void DelegadoParaEscribir(string[] conectados);

        public Preguntados()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void AtenderServidor()
        {
            while (true)
            {
                try
                {
                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                    int codigo = Convert.ToInt32(trozos[0]);
                    string mensaje = trozos[1].Split('\0')[0];

                    switch (codigo)
                    {
                        case 1: // Inicio de sesión
                            if (mensaje == "0") 
                            {

                                consultasBox.Visible = true;
                                consBot.Visible = true;
                                listaconectados.Visible = true;
                                conectadosLbl.Visible = true;
                                InicioSesionBox.Visible = false;
                                RegisBox.Visible = false;

                                MessageBox.Show("Has iniciado sesión correctamente");


                            }
                            //Excepciones
                            else if (mensaje == "1")
                            {
                                MessageBox.Show("El usuario introducido no existe");
                            }
                            else if (mensaje == "2")
                            {
                                MessageBox.Show("Contraseña incorrecta, vuelve a intentarlo");
                            }
                            else
                            {
                                MessageBox.Show("Error en la consulta. Pruebe otra vez.");
                            }
                            break;

                        case 2: //Respuestas al registro de nuevos jugadores

                            if (mensaje == "0")
                                MessageBox.Show("Se ha registrado correctamente.");

                            //Excepciones
                            else if (mensaje == "1")
                                MessageBox.Show("Este nombre de usuario ya existe.");

                            else
                                MessageBox.Show("Error de consulta, pruebe otra vez.");

                            usuBox.Clear();
                            passBox.Clear();
                            mailBox.Clear();
                            break;

                        case 3: //Devuelve tu contraseña
                            if (mensaje == "-1")
                                MessageBox.Show("Error de consulta. Prueba otra vez.");
                            else
                                MessageBox.Show("Tu contraseña es: " + mensaje);
                            break;

                        case 4: //Devuelve partida más larga

                            //Excepciones
                            if (mensaje == "-1")
                            {
                                MessageBox.Show("Error de consulta. Prueba otra vez.");
                            }
                            else if (mensaje == "-2")
                            {
                                MessageBox.Show("No se ha encontrado ninguna partida en la base de datos");
                            }

                            //Devuelve partida
                            else
                                MessageBox.Show("La partida más larga ha sido la número " + mensaje);
                            break;

                        case 5: //Jugador mejor valuado

                            if (mensaje == "-1")
                            {
                                MessageBox.Show("Error de consulta. Prueba otra vez");
                            }
                            else if (mensaje == "-2")
                            {
                                MessageBox.Show("No hay ningún jugador en la base de datos.");
                            }
                            else
                            {
                                MessageBox.Show("El jugador con más puntos es: " + mensaje + ".");
                            }
                            break;

                        case 6: //Notificación de actualización de la lista de conectados
                            if (mensaje == "-1")
                                MessageBox.Show("No hay usuarios conectados.");

                            else
                            {
                                //MessageBox.Show("Se ha actualizado la lista de conectados.");
                                string[] conectados = mensaje.Split('*');

                                //Delegado modifica el DataGridView para poner o quitar un usuario
                                DelegadoParaEscribir delegado = new DelegadoParaEscribir(ListaConectados);
                                listaconectados.Invoke(delegado, new object[] { conectados });

                            }
                            break;
                    }
                }
                catch (SocketException)
                {
                    MessageBox.Show("Server desconectado");
                }
            }

        }
        private void conectarBot_Click(object sender, EventArgs e)
        {
            //Este botón hace posible la desconexión o conexión al servidor

            if (conectado == 0)
            {
                IPAddress direc = IPAddress.Parse("192.168.56.101");
                IPEndPoint ipep = new IPEndPoint(direc, 50055);

                this.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);
                    conn.BackColor = Color.DarkSlateBlue;
                    conectarBot.Text = "Desconectar";
                    conectado = 1;

                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();
                }
                catch (SocketException)
                {
                    MessageBox.Show("No se ha conectado al servidor");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }

            else
            {
                try
                {
                    string mensaje = "0/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    atender.Abort();

                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                    conectarBot.Text = "Conectar";
                    conectado = 0;

                    conn.BackColor = Color.White;

                    consultasBox.Visible = false;
                    consBot.Visible = false;
                    InicioSesionBox.Visible = true;
                    RegisBox.Visible = true;
                    listaconectados.Visible = false;
                    conectadosLbl.Visible = false;

                    usuBox2.Clear();
                    passBox2.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hasta pronto");
                }
            }
        }

        private void registroBot_Click(object sender, EventArgs e)
        {
            try
            {
                string m = "2/" + usuBox.Text + "/" + passBox.Text + "/" + mailBox.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(m);
                server.Send(msg);
            }
            catch (Exception)
            {
                MessageBox.Show("Compruebe su conexión con el servidor y vuelva a intentarlo");
            }
        }

        private void inicioBot_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = usuBox2.Text;
                string m = "1/" + usuBox2.Text + "/" + passBox2.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(m);
                server.Send(msg);
            }
            catch (Exception)
            {
                MessageBox.Show("Compruebe su conexión con el servidor y vuelva a intentarlo");
            }
        }

        public void ListaConectados (string[] conectados)
        {
            conectadosLbl.Visible = true;
            listaconectados.Visible = true;
            listaconectados.ColumnCount = 1;
            listaconectados.RowCount = conectados.Length;
            listaconectados.ColumnHeadersVisible = false;
            listaconectados.RowHeadersVisible = false;
            listaconectados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            listaconectados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            listaconectados.SelectAll();

            for (int i = 0; i < conectados.Length; i++)
            {
                listaconectados.Rows[i].Cells[0].Value = conectados[i];
            }

            listaconectados.Show();

        }

        private void consBot_Click(object sender, EventArgs e)
        {
            try
            {
                //Consulta para averiguar nuestra contraseña
                if (passRadioBot.Checked)
                {
                    string mensaje = "3/" + usuBox2.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                }

                //Consulta para obtener la partida más duradera
                else if (partidaRadioBot.Checked)
                {
                    string mensaje = "4/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                }

                //Consulta para el jugador mejor valuado
                else
                {
                    string mensaje = "5/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Compruebe su conexión con el servidor y vuelva a intentarlo");
            }
        }

        private void Preguntados_Load(object sender, EventArgs e)
        {
            consultasBox.Visible = false;
            consBot.Visible = false;
            listaconectados.Visible = false;
            conectadosLbl.Visible = false;
        }

        private void Preguntados_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (conectado == 1)
                {
                    string mensaje = "0/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    atender.Abort();

                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                }
            }
            catch (Exception) { }

        }

        private void mostrarBot_Click(object sender, EventArgs e)
        {
            if (passBox2.UseSystemPasswordChar == true)
            {
                passBox2.UseSystemPasswordChar = false;
                mostrarBot.Text = "*";
            }
            else
            {
                passBox2.UseSystemPasswordChar = true;
                mostrarBot.Text = "M";
            }
        }

        private void passBox2_TextChanged(object sender, EventArgs e)
        {
            passBox2.UseSystemPasswordChar = true;
            mostrarBot.Text = "*";
        }
    }
}
