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
        List<string> listaCartas; // contendrá los nombres duplicados
        List<PictureBox> CartasSeleccionadas = new List<PictureBox>();
        PictureBox CartaTemporal1, CartaTemporal2;
        Timer timerVolteo = new Timer();

        public Juego()
        {
            InitializeComponent();
            // iniciarJuego() también se llama en Juego_Load
            timerVolteo.Interval = 1000; // 1 segundo
            timerVolteo.Tick += TimerVolteo_Tick;
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

            PanelJuego.Controls.Clear();
            CartasSeleccionadas.Clear();

            // 1. Lista de 8 nombres
            var nombresCartas = new List<string>
            {
                "Diego", "Gatos", "Hamburguesa", "Hippo",
                "Limon", "Perro", "Rosa", "Roshi"
            };

            // 2. Duplicar para formar pares
            listaCartas = new List<string>();
            foreach (var nombre in nombresCartas)
            {
                listaCartas.Add(nombre);
                listaCartas.Add(nombre);
            }

            // 3. Mezclar la lista
            Random NumeroAleatorio = new Random();
            var cartasRevueltas = listaCartas.OrderBy(item => NumeroAleatorio.Next()).ToList();

            // 4. Crear tableLayoutPanel
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

            // 5. Crear los PictureBox con la imagen "Verso" y el Tag con el nombre
            for (int i = 0; i < 16; i++)
            {
                var CartasJuego = new PictureBox
                {
                    Name = "Carta_" + i,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Properties.Resources.Verso, // Imagen inicial (dada vuelta)
                    Cursor = Cursors.Hand,
                    Tag = cartasRevueltas[i], // "Diego", "Gatos", etc.
                    Enabled = true
                };

                CartasJuego.Click += btnCarta_Click;
                // Calcular fila y columna en el tableLayoutPanel
                int row = i / 4;
                int col = i % 4;
                tablePanel.Controls.Add(CartasJuego, col, row);
            }

            PanelJuego.Controls.Add(tablePanel);
        }

        private void btnCarta_Click(object sender, EventArgs e)
        {
            if (CartasSeleccionadas.Count >= 2) return; // Evita más de 2 clics

            Movimientos++;
            lblRecord.Text = Movimientos.ToString();
            var CartaSeleccionada = (PictureBox)sender;

            // Si la carta ya está deshabilitada, no hacer nada
            if (!CartaSeleccionada.Enabled)
                return;

            // Mostrar la imagen real de la carta
            string nombreRecurso = CartaSeleccionada.Tag.ToString(); // p.e. "Diego"
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

                string Carta1 = CartaTemporal1.Tag.ToString();
                string Carta2 = CartaTemporal2.Tag.ToString();

                if (Carta1 == Carta2)
                {
                    cantidadDeCartasVolteadas++;
                    // Deshabilitar las cartas si son un par correcto
                    CartaTemporal1.Enabled = false;
                    CartaTemporal2.Enabled = false;

                    if (cantidadDeCartasVolteadas == 8) // 8 pares
                    {
                        MessageBox.Show("¡Ganaste! Juego completado.");
                    }
                    CartasSeleccionadas.Clear();
                }
                else
                {
                    timerVolteo.Start(); // Espera 1 segundo y voltea las cartas
                }
            }
        }

        private void TimerVolteo_Tick(object sender, EventArgs e)
        {
            if (CartaTemporal1 != null && CartaTemporal2 != null)
            {
                CartaTemporal1.Image = Properties.Resources.Verso;
                CartaTemporal2.Image = Properties.Resources.Verso;
            }
            CartasSeleccionadas.Clear();
            timerVolteo.Stop();
        }

        // Ajustamos la función para recibir un nombre (string), no un número
        public Bitmap RecuperarImagen(string nombreRecurso)
        {
            // Busca un recurso con el nombre (ej. "Diego") en Properties.Resources
            object obj = Properties.Resources.ResourceManager.GetObject(nombreRecurso);
            return obj as Bitmap ?? Properties.Resources.Verso;
        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            iniciarJuego();
        }
    }
}
