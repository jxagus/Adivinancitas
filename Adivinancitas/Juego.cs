using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Adivinancitas
{
    public partial class Juego : Form
    {
        int tamañoColumnasFilas = 4; // 4x4 = 16 cartas
        int Movimientos = 0;
        int cantidadDeCartasVolteadas = 0;
        string jugador1, jugador2;
        int puntajeJugador1 = 0, puntajeJugador2 = 0;
        int turnoJugador = 1; // 1 para el jugador 1, 2 para el jugador 2
        List<string> listaCartas;
        List<PictureBox> CartasSeleccionadas = new List<PictureBox>();
        PictureBox CartaTemporal1, CartaTemporal2;
        Timer timerVolteo = new Timer();

        public Juego(string tbPlayerUno, string tbPlayer2)
        {
            InitializeComponent();
            timerVolteo.Interval = 1000;
            timerVolteo.Tick += TimerVolteo_Tick;

            jugador1 = tbPlayerUno;
            jugador2 = tbPlayer2;
            lblJugadorUno.Text = jugador1 + ": 0 pts";
            lblJugadorDos.Text = jugador2 + ": 0 pts";
        }

        private void VerificarPareja()
        {
            if (CartaTemporal1.Tag.ToString() == CartaTemporal2.Tag.ToString())
            {
                // Asignar puntos al jugador actual
                if (turnoJugador == 1)
                {
                    puntajeJugador1 += 10;
                    lblJugadorUno.Text = jugador1 + ": " + puntajeJugador1 + " pts";

                }
                else
                {
                    puntajeJugador2 += 10;
                    lblJugadorDos.Text = jugador2 + ": " + puntajeJugador2 + " pts";


                }

                // Deshabilitar las cartas emparejadas
                CartaTemporal1.Enabled = false;
                CartaTemporal2.Enabled = false;

                cantidadDeCartasVolteadas++;

                // Verificar si el juego ha terminado
                if (cantidadDeCartasVolteadas == 8 && puntajeJugador2 == puntajeJugador1)
                {
                    MessageBox.Show("EMPATE!!!" + Math.Max(puntajeJugador1, puntajeJugador2));
                }
                if (cantidadDeCartasVolteadas == 8)
                {
                    if (puntajeJugador1 > puntajeJugador2 || puntajeJugador1 < puntajeJugador2)
                    {
                        string ganador = puntajeJugador1 > puntajeJugador2 ? jugador1 : jugador2;
                        MessageBox.Show("¡Ganó " + ganador + "! Puntos: " + Math.Max(puntajeJugador1, puntajeJugador2));

                    }
                }


                // Limpiar selección
                CartasSeleccionadas.Clear();
                CartaTemporal1 = null;
                CartaTemporal2 = null; 

            }
            else
            {
                // Si no son iguales, iniciar temporizador para voltearlas
                timerVolteo.Start();
                CambiarTurno();
            }
        }

        private void CambiarTurno()
        {
            turnoJugador = (turnoJugador == 1) ? 2 : 1; //Si cumple el if es 2 y si no es 1. Con esto pasamos el turno de uno a otro
            //lblRecord.ResetText();
        }

        private void btnCarta_Click(object sender, EventArgs e)
        {
            if (CartasSeleccionadas.Count >= 2) return;

            Movimientos++;
            lblRecord.Text = Movimientos.ToString();
            var CartaSeleccionada = (PictureBox)sender;

            if (!CartaSeleccionada.Enabled) return;

            string nombreRecurso = CartaSeleccionada.Tag.ToString();
            Bitmap imagenCarta = RecuperarImagen(nombreRecurso);

            if (imagenCarta != null)
            {
                CartaSeleccionada.Image = imagenCarta;
                CartasSeleccionadas.Add(CartaSeleccionada);
            }

            if (CartasSeleccionadas.Count == 2)
            {
                CartaTemporal1 = CartasSeleccionadas[0];
                CartaTemporal2 = CartasSeleccionadas[1];

                VerificarPareja();
            }
        }

        private void TimerVolteo_Tick(object sender, EventArgs e)
        {
            if (CartaTemporal1 != null && CartaTemporal2 != null)
            {
                if (CartaTemporal1.Enabled) CartaTemporal1.Image = Properties.Resources.Verso;
                if (CartaTemporal2.Enabled) CartaTemporal2.Image = Properties.Resources.Verso;
            }

            CartasSeleccionadas.Clear();
            CartaTemporal1 = null;
            CartaTemporal2 = null;
            timerVolteo.Stop();
        }

        public Bitmap RecuperarImagen(string nombreRecurso)
        {
            object obj = Properties.Resources.ResourceManager.GetObject(nombreRecurso);
            return obj as Bitmap ?? Properties.Resources.Verso;
        }


        private void btnReinicio_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Antes de reiniciar, ¿Quéres cambiar los Nombres?", 
                "Pregunta",                               
                MessageBoxButtons.YesNo,                  // Los botones que se muestran (Yes y No)
                MessageBoxIcon.Question                   // El icono de pregunta
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Has seleccionado 'Sí'.");
                // Mostrar la ventana del juego
                Usuarios ventanUsuarios = new Usuarios();
                ventanUsuarios.Show();
                this.Hide();
            }
            else if (result == DialogResult.No)
            {
                iniciarJuego();
            }

        }

        private void Juego_Load(object sender, EventArgs e)
        {
            iniciarJuego();
        }

        public void iniciarJuego()
        {
            lblRecord.Text = "0";
            cantidadDeCartasVolteadas = 0;
            Movimientos = 0;
            turnoJugador = 1;

            PanelJuego.Controls.Clear();
            CartasSeleccionadas.Clear();

            var nombresCartas = new List<string>
            {
                "Diego", "Gatos", "Hamburguesa", "Hippo",
                "Limon", "Perro", "Rosa", "Roshi"
            };

            listaCartas = new List<string>();
            foreach (var nombre in nombresCartas)
            {
                listaCartas.Add(nombre);
                listaCartas.Add(nombre);
            }

            Random NumeroAleatorio = new Random();
            var cartasRevueltas = listaCartas.OrderBy(item => NumeroAleatorio.Next()).ToList();

            var tablePanel = new TableLayoutPanel
            {
                RowCount = tamañoColumnasFilas,
                ColumnCount = tamañoColumnasFilas,
                Dock = DockStyle.Fill
            };

            for (int i = 0; i < tamañoColumnasFilas; i++)
            {
                tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
                tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            }

            for (int i = 0; i < 16; i++)
            {
                var CartasJuego = new PictureBox
                {
                    Name = "Carta_" + i,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Properties.Resources.Verso,
                    Cursor = Cursors.Hand,
                    Tag = cartasRevueltas[i],
                    Enabled = true
                };

                CartasJuego.Click += btnCarta_Click;
                int row = i / 4;
                int col = i % 4;
                tablePanel.Controls.Add(CartasJuego, col, row);
            }

            PanelJuego.Controls.Add(tablePanel);
        }
        private void lblRecord_Click(object sender, EventArgs e)
        {

        }

    }
}
