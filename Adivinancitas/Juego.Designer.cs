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
            this.SuspendLayout();
            // 
            // PanelJuego
            // 
            this.PanelJuego.Location = new System.Drawing.Point(57, 65);
            this.PanelJuego.Name = "PanelJuego";
            this.PanelJuego.Size = new System.Drawing.Size(484, 311);
            this.PanelJuego.TabIndex = 0;
             // 
            // btnReinicio
            // 
            this.btnReinicio.Location = new System.Drawing.Point(610, 353);
            this.btnReinicio.Name = "btnReinicio";
            this.btnReinicio.Size = new System.Drawing.Size(139, 23);
            this.btnReinicio.TabIndex = 1;
            this.btnReinicio.Text = "Reinicio del Juego";
            this.btnReinicio.UseVisualStyleBackColor = true;
            this.btnReinicio.Click += new System.EventHandler(this.btnReinicio_Click);
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(653, 234);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(42, 13);
            this.lblRecord.TabIndex = 2;
            this.lblRecord.Text = "Record";
            // 
            // Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.btnReinicio);
            this.Controls.Add(this.PanelJuego);
            this.Name = "Juego";
            this.Text = "Juego";
            this.Load += new System.EventHandler(this.  Juego_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelJuego;
        private System.Windows.Forms.Button btnReinicio;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblRecord;
        private Timer timer2;
    }
}