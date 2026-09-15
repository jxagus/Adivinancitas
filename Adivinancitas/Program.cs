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

            // Mostrar formulario de ingreso de jugadores
            Usuarios formUsuarios = new Usuarios();
            if (formUsuarios.ShowDialog() == DialogResult.OK)
            {
                // Obtener los datos del formulario
                string nombreJugador1 = formUsuarios.NombreJugador1;
                string nombreJugador2 = formUsuarios.NombreJugador2;
                bool modo40Cartas = formUsuarios.Usa40Cartas;

                // Lanzar el juego con esos datos
                Application.Run(new Juego(nombreJugador1, nombreJugador2, modo40Cartas));
            }
        }
    }
}
