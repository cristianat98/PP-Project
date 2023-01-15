namespace FormsProjecte
{
    partial class DatosAvion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatosAvion));
            this.label1 = new System.Windows.Forms.Label();
            this.Compañia = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.PA = new System.Windows.Forms.Label();
            this.PO = new System.Windows.Forms.Label();
            this.PD = new System.Windows.Forms.Label();
            this.Velocidad = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Email = new System.Windows.Forms.Label();
            this.Telefono = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // Compañia
            // 
            this.Compañia.AutoSize = true;
            this.Compañia.Location = new System.Drawing.Point(12, 44);
            this.Compañia.Name = "Compañia";
            this.Compañia.Size = new System.Drawing.Size(56, 13);
            this.Compañia.TabIndex = 1;
            this.Compañia.Text = "Compañía";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(12, 18);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(18, 13);
            this.ID.TabIndex = 2;
            this.ID.Text = "ID";
            // 
            // PA
            // 
            this.PA.AutoSize = true;
            this.PA.Location = new System.Drawing.Point(11, 130);
            this.PA.Name = "PA";
            this.PA.Size = new System.Drawing.Size(80, 13);
            this.PA.TabIndex = 3;
            this.PA.Text = "Posicion Actual";
            // 
            // PO
            // 
            this.PO.AutoSize = true;
            this.PO.Location = new System.Drawing.Point(11, 161);
            this.PO.Name = "PO";
            this.PO.Size = new System.Drawing.Size(81, 13);
            this.PO.TabIndex = 4;
            this.PO.Text = "Posición Origen";
            // 
            // PD
            // 
            this.PD.AutoSize = true;
            this.PD.Location = new System.Drawing.Point(12, 190);
            this.PD.Name = "PD";
            this.PD.Size = new System.Drawing.Size(86, 13);
            this.PD.TabIndex = 5;
            this.PD.Text = "Posición Destino";
            // 
            // Velocidad
            // 
            this.Velocidad.AutoSize = true;
            this.Velocidad.Location = new System.Drawing.Point(12, 219);
            this.Velocidad.Name = "Velocidad";
            this.Velocidad.Size = new System.Drawing.Size(54, 13);
            this.Velocidad.TabIndex = 6;
            this.Velocidad.Text = "Velocidad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Location = new System.Drawing.Point(12, 71);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(32, 13);
            this.Email.TabIndex = 9;
            this.Email.Text = "Email";
            // 
            // Telefono
            // 
            this.Telefono.AutoSize = true;
            this.Telefono.Location = new System.Drawing.Point(11, 100);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(49, 13);
            this.Telefono.TabIndex = 10;
            this.Telefono.Text = "Teléfono";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(246, 256);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 28);
            this.button3.TabIndex = 11;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // DatosAvion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 297);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Telefono);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Velocidad);
            this.Controls.Add(this.PD);
            this.Controls.Add(this.PO);
            this.Controls.Add(this.PA);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.Compañia);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatosAvion";
            this.Text = "Datos Avión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Compañia;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label PA;
        private System.Windows.Forms.Label PO;
        private System.Windows.Forms.Label PD;
        private System.Windows.Forms.Label Velocidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Telefono;
        private System.Windows.Forms.Button button3;




    }
}