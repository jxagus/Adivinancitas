using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //Para el File.Exists


namespace Adivinancitas
{
    public partial class Usuarios: Form
    {
        public string NombreJugador1 { get; private set; }
        public string NombreJugador2 { get; private set; }
        public bool Usa40Cartas { get; private set; }

        public Usuarios()
        {
            InitializeComponent();
        }

        private void pbUsuarios (object sender, EventArgs e)
        {

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            lblRed.Visible = false;
            lblRed2.Visible = false;
            pbUsuario.Image = Image.FromFile("C:/Users/agust/source/repos/Adivinancitas/Adivinancitas/Img20/Verso.png");
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try 
            {
                if (string.IsNullOrWhiteSpace(tbPlayerUno.Text))
                {
                    lblRed.Visible = true;
                    MessageBox.Show("El campo de texto no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(tbPlayer2.Text))
                {
                    lblRed2.Visible = true;
                    MessageBox.Show("El campo de texto no puede estar vacío.");
                }
                if (!radioButton40.Checked && !radioButton20.Checked)
                {
                    MessageBox.Show("Elija una opcion, 20 o 40 cartas?.");
                }

                if (!string.IsNullOrWhiteSpace(tbPlayerUno.Text) && !string.IsNullOrWhiteSpace(tbPlayer2.Text))
                {
                    if (radioButton20.Checked || radioButton40.Checked)
                    {
                        NombreJugador1 = tbPlayerUno.Text;
                        NombreJugador2 = tbPlayer2.Text;
                        Usa40Cartas = radioButton40.Checked;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void cb40_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Usuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Application.Exit();
        }
    }
}
