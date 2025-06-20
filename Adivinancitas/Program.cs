using System;
using System.Windows.Forms;

namespace Adivinancitas
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var formUsuarios = new Usuarios())
            {
                if (formUsuarios.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Juego(formUsuarios.NombreJugador1, formUsuarios.NombreJugador2));
                }
            }
        }
    }
}
