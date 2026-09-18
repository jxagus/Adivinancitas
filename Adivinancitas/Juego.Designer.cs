using System.Windows.Forms;

namespace Adivinancitas
{
    partial class Juego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PanelJuego = new System.Windows.Forms.Panel();
            this.btnReinicio = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblRecord = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblJugadorUno = new System.Windows.Forms.Label();
            this.lblJugadorDos = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblMensajeDinamico = new System.Windows.Forms.Label();
            this.flpJugador1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpJugador2 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // PanelJuego
            // 
            this.PanelJuego.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelJuego.Location = new System.Drawing.Point(0, 0);
            this.PanelJuego.Name = "PanelJuego";
            this.PanelJuego.Size = new System.Drawing.Size(1086, 811);
            this.PanelJuego.TabIndex = 0;
            // 
            // btnReinicio
            // 
            this.btnReinicio.Location = new System.Drawing.Point(1151, 720);
            this.btnReinicio.Name = "btnReinicio";
            this.btnReinicio.Size = new System.Drawing.Size(144, 37);
            this.btnReinicio.TabIndex = 1;
            this.btnReinicio.Text = "Reinicio del Juego";
            this.btnReinicio.UseVisualStyleBackColor = true;
            this.btnReinicio.Click += new System.EventHandler(this.btnReinicio_Click);
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(1136, 674);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(42, 13);
            this.lblRecord.TabIndex = 2;
            this.lblRecord.Text = "Record";
            this.lblRecord.Click += new System.EventHandler(this.lblRecord_Click);
            // 
            // lblJugadorUno
            // 
            this.lblJugadorUno.AutoSize = true;
            this.lblJugadorUno.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJugadorUno.Location = new System.Drawing.Point(1136, 92);
            this.lblJugadorUno.Name = "lblJugadorUno";
            this.lblJugadorUno.Size = new System.Drawing.Size(86, 23);
            this.lblJugadorUno.TabIndex = 3;
            this.lblJugadorUno.Text = "Jugador 1";
            // 
            // lblJugadorDos
            // 
            this.lblJugadorDos.AutoSize = true;
            this.lblJugadorDos.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJugadorDos.Location = new System.Drawing.Point(1136, 311);
            this.lblJugadorDos.Name = "lblJugadorDos";
            this.lblJugadorDos.Size = new System.Drawing.Size(88, 23);
            this.lblJugadorDos.TabIndex = 4;
            this.lblJugadorDos.Text = "Jugador 2";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.Location = new System.Drawing.Point(1109, 21);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(174, 25);
            this.lblTurno.TabIndex = 5;
            this.lblTurno.Text = "Turno de Spect";
            // 
            // lblMensajeDinamico
            // 
            this.lblMensajeDinamico.AutoSize = true;
            this.lblMensajeDinamico.Location = new System.Drawing.Point(1148, 437);
            this.lblMensajeDinamico.Name = "lblMensajeDinamico";
            this.lblMensajeDinamico.Size = new System.Drawing.Size(10, 13);
            this.lblMensajeDinamico.TabIndex = 6;
            this.lblMensajeDinamico.Text = " ";
            // 
            // flpJugador1
            // 
            this.flpJugador1.Location = new System.Drawing.Point(1139, 124);
            this.flpJugador1.Name = "flpJugador1";
            this.flpJugador1.Size = new System.Drawing.Size(200, 150);
            this.flpJugador1.TabIndex = 7;
            // 
            // flpJugador2
            // 
            this.flpJugador2.Location = new System.Drawing.Point(1139, 340);
            this.flpJugador2.Name = "flpJugador2";
            this.flpJugador2.Size = new System.Drawing.Size(200, 150);
            this.flpJugador2.TabIndex = 8;
            // 
            // Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 811);
            this.Controls.Add(this.flpJugador2);
            this.Controls.Add(this.flpJugador1);
            this.Controls.Add(this.lblMensajeDinamico);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.lblJugadorDos);
            this.Controls.Add(this.lblJugadorUno);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.btnReinicio);
            this.Controls.Add(this.PanelJuego);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Juego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Juego";
            this.Load += new System.EventHandler(this.Juego_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelJuego;
        private System.Windows.Forms.Button btnReinicio;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblRecord;
        private Timer timer2;
        private Label lblJugadorUno;
        private Label lblJugadorDos;
        private Label lblTurno;
        private Label lblMensajeDinamico;
        private FlowLayoutPanel flpJugador1;
        private FlowLayoutPanel flpJugador2;
    }
}