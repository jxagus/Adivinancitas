using System;

namespace Adivinancitas
{
    partial class Usuarios
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblPlayerUno = new System.Windows.Forms.Label();
            this.cb20 = new System.Windows.Forms.CheckBox();
            this.tbPlayerUno = new System.Windows.Forms.TextBox();
            this.tbPlayer2 = new System.Windows.Forms.TextBox();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.pbUsuario = new System.Windows.Forms.PictureBox();
            this.cb30 = new System.Windows.Forms.CheckBox();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblRed2 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(67, 212);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblPlayerUno
            // 
            this.lblPlayerUno.AutoSize = true;
            this.lblPlayerUno.Location = new System.Drawing.Point(13, 34);
            this.lblPlayerUno.Name = "lblPlayerUno";
            this.lblPlayerUno.Size = new System.Drawing.Size(48, 13);
            this.lblPlayerUno.TabIndex = 2;
            this.lblPlayerUno.Text = "Player 1:";
            // 
            // cb20
            // 
            this.cb20.AutoSize = true;
            this.cb20.Location = new System.Drawing.Point(16, 106);
            this.cb20.Name = "cb20";
            this.cb20.Size = new System.Drawing.Size(120, 17);
            this.cb20.TabIndex = 3;
            this.cb20.Text = "Jugar con 20 cartas";
            this.cb20.UseVisualStyleBackColor = true;
            // 
            // tbPlayerUno
            // 
            this.tbPlayerUno.Location = new System.Drawing.Point(67, 31);
            this.tbPlayerUno.Name = "tbPlayerUno";
            this.tbPlayerUno.Size = new System.Drawing.Size(131, 20);
            this.tbPlayerUno.TabIndex = 4;
            // 
            // tbPlayer2
            // 
            this.tbPlayer2.Location = new System.Drawing.Point(67, 64);
            this.tbPlayer2.Name = "tbPlayer2";
            this.tbPlayer2.Size = new System.Drawing.Size(131, 20);
            this.tbPlayer2.TabIndex = 6;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Location = new System.Drawing.Point(13, 67);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(48, 13);
            this.lblPlayer2.TabIndex = 5;
            this.lblPlayer2.Text = "Player 2:";
            // 
            // pbUsuario
            // 
            this.pbUsuario.Location = new System.Drawing.Point(221, 13);
            this.pbUsuario.Name = "pbUsuario";
            this.pbUsuario.Size = new System.Drawing.Size(118, 131);
            this.pbUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUsuario.TabIndex = 7;
            this.pbUsuario.TabStop = false;
            this.pbUsuario.Click += new System.EventHandler(this.pbUsuario_Click);
            // 
            // cb30
            // 
            this.cb30.AutoSize = true;
            this.cb30.Location = new System.Drawing.Point(16, 129);
            this.cb30.Name = "cb30";
            this.cb30.Size = new System.Drawing.Size(120, 17);
            this.cb30.TabIndex = 8;
            this.cb30.Text = "Jugar con 30 cartas";
            this.cb30.UseVisualStyleBackColor = true;
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.ForeColor = System.Drawing.Color.Red;
            this.lblRed.Location = new System.Drawing.Point(204, 38);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(11, 13);
            this.lblRed.TabIndex = 9;
            this.lblRed.Text = "*";
            // 
            // lblRed2
            // 
            this.lblRed2.AutoSize = true;
            this.lblRed2.ForeColor = System.Drawing.Color.Red;
            this.lblRed2.Location = new System.Drawing.Point(204, 71);
            this.lblRed2.Name = "lblRed2";
            this.lblRed2.Size = new System.Drawing.Size(11, 13);
            this.lblRed2.TabIndex = 10;
            this.lblRed2.Text = "*";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(207, 212);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(348, 250);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblRed2);
            this.Controls.Add(this.lblRed);
            this.Controls.Add(this.cb30);
            this.Controls.Add(this.pbUsuario);
            this.Controls.Add(this.tbPlayer2);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.tbPlayerUno);
            this.Controls.Add(this.cb20);
            this.Controls.Add(this.lblPlayerUno);
            this.Controls.Add(this.btnAceptar);
            this.Name = "Usuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void pbUsuario_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblPlayerUno;
        private System.Windows.Forms.CheckBox cb20;
        private System.Windows.Forms.TextBox tbPlayerUno;
        private System.Windows.Forms.TextBox tbPlayer2;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.PictureBox pbUsuario;
        private System.Windows.Forms.CheckBox cb30;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblRed2;
        private System.Windows.Forms.Button btnCerrar;
    }
}