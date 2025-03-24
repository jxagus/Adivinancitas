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
            pbUsuario.Image = Image.FromFile("C:/Users/agust/source/repos/Adivinancitas/Adivinancitas/Img/Verso.png");
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
            try //Comprobamos que onda
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
                if (!cb30.Checked && !cb20.Checked)
                {
                    MessageBox.Show("Elija una opcion, 20 o 30 cartas?.");
                }
                else
                {

                    if (!cb20.Checked && cb30.Checked)
                    {
                        throw new InvalidOperationException("Aun no esta disponible, eliga otra opcion");

                    }
                }

                if (string.IsNullOrWhiteSpace(tbPlayerUno.Text) && string.IsNullOrWhiteSpace(tbPlayer2.Text)) {
                    MessageBox.Show("Primera parte bien");
                    if (cb20.Checked) {
                        MessageBox.Show("Segunda parte bien");
                    }
                    //Juego juego = new Juego();
                    //this.Hide();
                    //juego.Show();  // Mostrar Form2
                }
                MessageBox.Show("bienvenido al juego");
                Juego juego = new Juego();
                juego.Show();

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
    }
}
