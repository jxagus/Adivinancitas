using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Adivinancitas
{
    public partial class Juego : Form
    {
        int tamañoColumnasFilas = 4;
        int Movimientos = 0;
        int cantidadDeCartasVolteadas = 0;
        string jugador1, jugador2;
        int puntajeJugador1 = 0, puntajeJugador2 = 0;
        int turnoJugador = 1;
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

                CartaTemporal1.Enabled = false;
                CartaTemporal2.Enabled = false;
                cantidadDeCartasVolteadas++;

                if (cantidadDeCartasVolteadas == 8)
                {
                    if (puntajeJugador1 == puntajeJugador2)
                    {
                        MessageBox.Show("EMPATE!!! " + puntajeJugador1 + " pts");
                    }
                    else
                    {
                        string ganador = puntajeJugador1 > puntajeJugador2 ? jugador1 : jugador2;
                        MessageBox.Show("¡Ganó " + ganador + "! Puntos: " + Math.Max(puntajeJugador1, puntajeJugador2));
                    }
                }

                CartasSeleccionadas.Clear();
                CartaTemporal1 = null;
                CartaTemporal2 = null;
            }
            else
            {
                timerVolteo.Start();
                CambiarTurno();
            }
        }

        private void CambiarTurno()
        {
            turnoJugador = (turnoJugador == 1) ? 2 : 1;
            ActualizarTurno();
        }

        private void ActualizarTurno()
        {
            if (turnoJugador == 1)
            {
                lblTurno.Text = "Es turno de: " + jugador1;
            }
            else
            {
                lblTurno.Text = "Es turno de: " + jugador2;
            }
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
                "Antes de reiniciar, ¿Querés cambiar los nombres?",
                "Pregunta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                Usuarios ventanUsuarios = new Usuarios();
                ventanUsuarios.Show();
                this.Hide();
            }
            else
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
            ActualizarTurno();

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
