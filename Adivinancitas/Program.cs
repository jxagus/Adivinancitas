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

            bool reiniciarApp = true;

            while (reiniciarApp)
            {
                reiniciarApp = false; 

                using (Usuarios formUsuarios = new Usuarios())
                {
                    if (formUsuarios.ShowDialog() == DialogResult.OK)
                    {
                        string nombreJugador1 = formUsuarios.NombreJugador1;
                        string nombreJugador2 = formUsuarios.NombreJugador2;
                        bool modo40Cartas = formUsuarios.Usa40Cartas;

                        Juego formJuego = new Juego(nombreJugador1, nombreJugador2, modo40Cartas);

                        Application.Run(formJuego);

                       
                    }
                }
            }
        }
    }
}
