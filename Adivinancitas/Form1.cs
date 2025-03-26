using System;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;

namespace Adivinancitas
{
    public partial class Form1 : Form
    {
        private string respuestaCorrecta;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            CargarPregunta(); // Llama a la función que genera la pregunta
            btnOpc1.Click += btnRespuesta_Click;
            btnOpc2.Click += btnRespuesta_Click;
            btnOpc3.Click += btnRespuesta_Click;
            btnCambiar.Click += btnCambiar_Click; // Evento para cambiar a otra pregunta
        }

        private async Task CargarPregunta()
        {
            string cohereApiKey = "VKGcYeRyS88L3ebKmCJ2ISJBH0yf2WXA690IEjHN";
            var client = new RestClient("https://api.cohere.ai/v1/chat");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", "Bearer " + cohereApiKey);
            request.AddHeader("Content-Type", "application/json");
            var body = new
            {
                query = "Genera una pregunta difícil sobre la cultura argentina con tres opciones (A, B, C), e indica cuál es la correcta en un formato claro. Ejemplo:\n" +
                        "Pregunta: ¿Cuál es la bebida nacional de Argentina?\n" +
                        "A) Mate\n" +
                        "B) Café\n" +
                        "C) Té\n" +
                        "Respuesta correcta: A",
                chat_history = new object[] { },
                model = "command-xlarge-nightly",
                temperature = 0.7
            };

            request.AddJsonBody(body);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                dynamic responseData = JsonConvert.DeserializeObject(response.Content);
                string resultado = responseData.text.ToString().Trim();
                string[] lineas = resultado.Split('\n');

                // Buscar la línea que contiene la pregunta
                string pregunta = lineas.FirstOrDefault(l => l.StartsWith("Pregunta:"))?.Replace("Pregunta:", "").Trim();
                string opcionA = lineas.FirstOrDefault(l => l.StartsWith("A)"))?.Replace("A) ", "").Trim();
                string opcionB = lineas.FirstOrDefault(l => l.StartsWith("B)"))?.Replace("B) ", "").Trim();
                string opcionC = lineas.FirstOrDefault(l => l.StartsWith("C)"))?.Replace("C) ", "").Trim();
                string respuesta = lineas.FirstOrDefault(l => l.StartsWith("Respuesta correcta:"))?.Replace("Respuesta correcta:", "").Trim();

                // Validar que se encontraron los elementos esperados
                if (!string.IsNullOrEmpty(pregunta) && !string.IsNullOrEmpty(opcionA) && !string.IsNullOrEmpty(opcionB) &&
                    !string.IsNullOrEmpty(opcionC) && !string.IsNullOrEmpty(respuesta))
                {
                    lblPregunta.Text = pregunta;
                    btnOpc1.Text = opcionA;
                    btnOpc2.Text = opcionB;
                    btnOpc3.Text = opcionC;

                    // Convertir respuesta en el texto real (ejemplo: "A" → "Mate")
                    if (respuesta == "A")
                        respuestaCorrecta = opcionA ?? "";
                    else if (respuesta == "B")
                        respuestaCorrecta = opcionB ?? "";
                    else if (respuesta == "C")
                        respuestaCorrecta = opcionC ?? "";
                    else
                        respuestaCorrecta = "";
                }

                lblEspere.Visible = false; // Oculta el mensaje de "Espere un momento"
            }
            else
            {
                MessageBox.Show($"Error al obtener la pregunta: {response.ErrorMessage}\n" +
                                $"Código de estado: {response.StatusCode}\n" +
                                $"Contenido de la respuesta: {response.Content}");
                lblEspere.Visible = false; // Oculta el mensaje de "Espere un momento" en caso de error
            }
        }


        private void btnRespuesta_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn.Text.Trim() == respuestaCorrecta.Trim())
                {
                    MessageBox.Show("✅ ¡Respuesta correcta! 🎉", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"❌ ¡Respuesta incorrecta!\nLa correcta era: {respuestaCorrecta}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnCambiar_Click(object sender, EventArgs e)
        {
            CargarPregunta(); // Vuelve a cargar una nueva pregunta
            lblEspere.Text = "Espere un momento";

        }
    }
}