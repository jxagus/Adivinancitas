namespace Adivinancitas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.btnOpc1 = new System.Windows.Forms.Button();
            this.btnOpc2 = new System.Windows.Forms.Button();
            this.btnOpc3 = new System.Windows.Forms.Button();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.lblEspere = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Veremos quien comienza";
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Location = new System.Drawing.Point(132, 77);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(35, 13);
            this.lblPregunta.TabIndex = 4;
            this.lblPregunta.Text = "label2";
            // 
            // btnOpc1
            // 
            this.btnOpc1.Location = new System.Drawing.Point(107, 181);
            this.btnOpc1.Name = "btnOpc1";
            this.btnOpc1.Size = new System.Drawing.Size(136, 77);
            this.btnOpc1.TabIndex = 5;
            this.btnOpc1.Text = "button1";
            this.btnOpc1.UseVisualStyleBackColor = true;
            // 
            // btnOpc2
            // 
            this.btnOpc2.Location = new System.Drawing.Point(275, 181);
            this.btnOpc2.Name = "btnOpc2";
            this.btnOpc2.Size = new System.Drawing.Size(145, 77);
            this.btnOpc2.TabIndex = 6;
            this.btnOpc2.Text = "button2";
            this.btnOpc2.UseVisualStyleBackColor = true;
            // 
            // btnOpc3
            // 
            this.btnOpc3.Location = new System.Drawing.Point(447, 181);
            this.btnOpc3.Name = "btnOpc3";
            this.btnOpc3.Size = new System.Drawing.Size(144, 77);
            this.btnOpc3.TabIndex = 7;
            this.btnOpc3.Text = "button3";
            this.btnOpc3.UseVisualStyleBackColor = true;
            // 
            // btnCambiar
            // 
            this.btnCambiar.Location = new System.Drawing.Point(281, 305);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(116, 23);
            this.btnCambiar.TabIndex = 8;
            this.btnCambiar.Text = "Cambiar pregunta";
            this.btnCambiar.UseVisualStyleBackColor = true;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // lblEspere
            // 
            this.lblEspere.AutoSize = true;
            this.lblEspere.Location = new System.Drawing.Point(278, 289);
            this.lblEspere.Name = "lblEspere";
            this.lblEspere.Size = new System.Drawing.Size(10, 13);
            this.lblEspere.TabIndex = 9;
            this.lblEspere.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 340);
            this.Controls.Add(this.lblEspere);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.btnOpc3);
            this.Controls.Add(this.btnOpc2);
            this.Controls.Add(this.btnOpc1);
            this.Controls.Add(this.lblPregunta);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.Button btnOpc1;
        private System.Windows.Forms.Button btnOpc2;
        private System.Windows.Forms.Button btnOpc3;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.Label lblEspere;
    }
}

