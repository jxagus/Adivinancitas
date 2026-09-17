using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Adivinancitas
{
    public partial class Juego : Form
    {
        int Movimientos = 0;
        string jugador1, jugador2;
        int puntajeJugador1 = 0, puntajeJugador2 = 0;
        int turnoJugador = 1;
        List<string> listaCartas;
        List<PictureBox> CartasSeleccionadas = new List<PictureBox>();
        PictureBox CartaTemporal1, CartaTemporal2;
        Timer timerVolteo = new Timer();

        private bool modo40Cartas;

        public Juego(string tbPlayerUno, string tbPlayer2, bool usar40Cartas)
        {
            InitializeComponent();

            timerVolteo.Interval = 1000;
            timerVolteo.Tick += TimerVolteo_Tick;

            jugador1 = tbPlayerUno;
            jugador2 = tbPlayer2;
            modo40Cartas = usar40Cartas;

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

                CartasSeleccionadas.Clear();
                CartaTemporal1 = null;
                CartaTemporal2 = null;

                VerificarFinDelJuego();
            }
            else
            {
                timerVolteo.Start();
                CambiarTurno();
            }
        }

        private void VerificarFinDelJuego()
        {
            var tablePanel = PanelJuego.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
            if (tablePanel != null)
            {
                bool juegoTerminado = true;
                foreach (Control c in tablePanel.Controls)
                {
                    if (c is PictureBox pb && pb.Enabled)
                    {
                        juegoTerminado = false;
                        break;
                    }
                }

                if (juegoTerminado)
                {
                    if (puntajeJugador1 == puntajeJugador2)
                    {
                        MessageBox.Show("¡EMPATE! Ambos terminaron con " + puntajeJugador1 + " pts");
                    }
                    else
                    {
                        string ganador = puntajeJugador1 > puntajeJugador2 ? jugador1 : jugador2;
                        int maxPuntaje = Math.Max(puntajeJugador1, puntajeJugador2);
                        MessageBox.Show("¡Ganó " + ganador + "! Puntos: " + maxPuntaje);
                    }
                }
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

            var CartaSeleccionada = (PictureBox)sender;

            if (!CartaSeleccionada.Enabled || CartasSeleccionadas.Contains(CartaSeleccionada)) return;

            Movimientos++;
            lblRecord.Text = Movimientos.ToString();

            ActualizarEfectoVisualCartasDescubiertas();

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

        private Image ObtenerVerso()
        {
            return Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "Verso.png"));
        }

        private void TimerVolteo_Tick(object sender, EventArgs e)
        {
            if (CartaTemporal1 != null && CartaTemporal2 != null)
            {
                if (CartaTemporal1.Enabled) CartaTemporal1.Image = ObtenerVerso();
                if (CartaTemporal2.Enabled) CartaTemporal2.Image = ObtenerVerso();
            }

            CartasSeleccionadas.Clear();
            CartaTemporal1 = null;
            CartaTemporal2 = null;
            timerVolteo.Stop();
        }

        public Bitmap RecuperarImagen(string nombreRecurso)
        {
            if (modo40Cartas)
            {
                string rutaImg40 = Path.Combine(Application.StartupPath, "Img40");
                string rutaPng = Path.Combine(rutaImg40, nombreRecurso + ".png");
                string rutaJpg = Path.Combine(rutaImg40, nombreRecurso + ".jpg");
                string rutaJpeg = Path.Combine(rutaImg40, nombreRecurso + ".jpeg");

                if (File.Exists(rutaPng)) return new Bitmap(rutaPng);
                if (File.Exists(rutaJpg)) return new Bitmap(rutaJpg);
                if (File.Exists(rutaJpeg)) return new Bitmap(rutaJpeg);

                return new Bitmap(ObtenerVerso());
            }
            else
            {
                object obj = Properties.Resources.ResourceManager.GetObject(nombreRecurso);

                if (obj == null)
                {
                    var recursoEncontrado = Properties.Resources.ResourceManager
                        .GetResourceSet(System.Globalization.CultureInfo.CurrentUICulture, true, true)
                        .Cast<System.Collections.DictionaryEntry>()
                        .FirstOrDefault(x => string.Equals(x.Key.ToString(), nombreRecurso, StringComparison.OrdinalIgnoreCase));

                    if (recursoEncontrado.Value != null)
                    {
                        obj = recursoEncontrado.Value;
                    }
                }

                return obj as Bitmap ?? new Bitmap(ObtenerVerso());
            }
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
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Usuarios)
                    {
                        form.Show();
                        this.Close();
                        return;
                    }
                }

                Usuarios ventanUsuarios = new Usuarios();
                ventanUsuarios.Show();
                this.Close();
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
            Movimientos = 0;
            puntajeJugador1 = 0;
            puntajeJugador2 = 0;
            lblJugadorUno.Text = jugador1 + ": 0 pts";
            lblJugadorDos.Text = jugador2 + ": 0 pts";

            turnoJugador = 1;
            ActualizarTurno();

            PanelJuego.Controls.Clear();
            CartasSeleccionadas.Clear();

            listaCartas = new List<string>();
            List<string> nombresCartas;

            int columnas;

            if (modo40Cartas)
            {
                string rutaImg40 = Path.Combine(Application.StartupPath, "img40");
                var extensiones = new[] { "*.png", "*.jpg", "*.jpeg" };
                var archivos = extensiones.SelectMany(ext => Directory.GetFiles(rutaImg40, ext)).ToArray();

                nombresCartas = archivos.Select(Path.GetFileNameWithoutExtension).ToList();
                columnas = 10; 
            }
            else
            {
                nombresCartas = new List<string>
        { "Diego", "Gatos", "Hamburguesa", "Hippo", "Limon", "Perro", "Rosa", "Roshi", "Stitch", "Pelotabasquet" };
                columnas = 5; 
            }

            foreach (var nombre in nombresCartas)
            {
                listaCartas.Add(nombre);
                listaCartas.Add(nombre);
            }

            var cartasRevueltas = listaCartas.OrderBy(x => Guid.NewGuid()).ToList();

            int totalCartas = listaCartas.Count;
            int filas = (int)Math.Ceiling((double)totalCartas / columnas);

            var tablePanel = new TableLayoutPanel
            {
                RowCount = filas,
                ColumnCount = columnas,
                Dock = DockStyle.Fill
            };

            for (int i = 0; i < columnas; i++)
                tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columnas));

            for (int i = 0; i < filas; i++)
                tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / filas));

            for (int i = 0; i < totalCartas; i++)
            {
                var Carta = new PictureBox
                {
                    Name = "Carta_" + i,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "Verso.png")),
                    Cursor = Cursors.Hand,
                    Tag = cartasRevueltas[i],
                    Enabled = true
                };

                Carta.Click += btnCarta_Click;

                int row = i / columnas;
                int col = i % columnas;
                tablePanel.Controls.Add(Carta, col, row);
            }

            PanelJuego.Controls.Add(tablePanel);
        }
        private Image AplicarEfectoVisual(Image imagenOriginal, float factorOscuridad, float opacidad)
        {
            Bitmap bitmapEfecto = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);
            using (Graphics g = Graphics.FromImage(bitmapEfecto))
            {
                // Dibujamos la imagen con la opacidad deseada (matriz de color)
                System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix();
                colorMatrix.Matrix33 = opacidad; // Controla la transparencia (0.0f = invisible, 1.0f = visible)

                System.Drawing.Imaging.ImageAttributes imgAttributes = new System.Drawing.Imaging.ImageAttributes();
                imgAttributes.SetColorMatrix(colorMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap);

                g.DrawImage(imagenOriginal, new Rectangle(0, 0, bitmapEfecto.Width, bitmapEfecto.Height),
                    0, 0, imagenOriginal.Width, imagenOriginal.Height, GraphicsUnit.Pixel, imgAttributes);

                // Si hay que oscurecerla además de transparentarla
                if (factorOscuridad > 0f)
                {
                    using (Brush brush = new SolidBrush(Color.FromArgb((int)(factorOscuridad * 255), Color.Black)))
                    {
                        g.FillRectangle(brush, 0, 0, bitmapEfecto.Width, bitmapEfecto.Height);
                    }
                }
            }
            return bitmapEfecto;
        }

        private void ActualizarEfectoVisualCartasDescubiertas()
        {
            TableLayoutPanel tablePanel = PanelJuego.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
            if (tablePanel == null) return;

            foreach (Control control in tablePanel.Controls)
            {
                if (control is PictureBox carta && !carta.Enabled) // Solo cartas ya descubiertas/bloqueadas
                {
                    
                    if (carta.Tag is string nombreRecurso)
                    {
                        // Obtenemos la imagen limpia original de esa carta
                        Image imgOriginal = RecuperarImagen(nombreRecurso);

                        if (Movimientos >= 200)
                        {
                            // 200+: Totalmente invisibles (ocultas o transparentes al 100%)
                            carta.Visible = false; // O puedes usar opacidad 0 si prefieres que dejen el espacio en blanco: carta.Image = AplicarEfectoVisual(imgOriginal, 0f, 0f);
                        }
                        else if (Movimientos >= 120)
                        {
                            carta.Visible = true;
                            // 120 a 199: Oscuras y con degradado/desvanecimiento (ej. 50% de opacidad y tono oscuro)
                            carta.Image = AplicarEfectoVisual(imgOriginal, 0.4f, 0.5f);
                        }
                        else if (Movimientos >= 60)
                        {
                            carta.Visible = true;
                            // 60 a 119: Oscuras levemente
                            carta.Image = AplicarEfectoVisual(imgOriginal, 0.25f, 0.9f);
                        }
                        else
                        {
                            carta.Visible = true;
                            // Menos de 60: Normales
                            carta.Image = imgOriginal;
                        }
                    }
                }
            }
        }
        private void lblRecord_Click(object sender, EventArgs e)
        {
        }
    }
}