namespace FormsProjecte
{
    partial class ModificarSector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarSector));
            this.label4 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.Label();
            this.DY = new System.Windows.Forms.TextBox();
            this.DX = new System.Windows.Forms.TextBox();
            this.OY = new System.Windows.Forms.TextBox();
            this.OX = new System.Windows.Forms.TextBox();
            this.destino = new System.Windows.Forms.Label();
            this.origen = new System.Windows.Forms.Label();
            this.nom = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(95, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 74;
            this.label4.Text = "Nueva Información";
            // 
            // nombre
            // 
            this.nombre.AutoSize = true;
            this.nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre.ForeColor = System.Drawing.Color.Black;
            this.nombre.Location = new System.Drawing.Point(25, 101);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(57, 16);
            this.nombre.TabIndex = 76;
            this.nombre.Text = "Nombre";
            // 
            // DY
            // 
            this.DY.Location = new System.Drawing.Point(197, 184);
            this.DY.Name = "DY";
            this.DY.Size = new System.Drawing.Size(85, 20);
            this.DY.TabIndex = 82;
            // 
            // DX
            // 
            this.DX.Location = new System.Drawing.Point(97, 184);
            this.DX.Name = "DX";
            this.DX.Size = new System.Drawing.Size(76, 20);
            this.DX.TabIndex = 81;
            // 
            // OY
            // 
            this.OY.Location = new System.Drawing.Point(197, 140);
            this.OY.Name = "OY";
            this.OY.Size = new System.Drawing.Size(85, 20);
            this.OY.TabIndex = 80;
            // 
            // OX
            // 
            this.OX.Location = new System.Drawing.Point(97, 140);
            this.OX.Name = "OX";
            this.OX.Size = new System.Drawing.Size(76, 20);
            this.OX.TabIndex = 79;
            // 
            // destino
            // 
            this.destino.AutoSize = true;
            this.destino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destino.ForeColor = System.Drawing.Color.Black;
            this.destino.Location = new System.Drawing.Point(25, 188);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(54, 16);
            this.destino.TabIndex = 78;
            this.destino.Text = "Destino";
            // 
            // origen
            // 
            this.origen.AutoSize = true;
            this.origen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origen.ForeColor = System.Drawing.Color.Black;
            this.origen.Location = new System.Drawing.Point(25, 140);
            this.origen.Name = "origen";
            this.origen.Size = new System.Drawing.Size(48, 16);
            this.origen.TabIndex = 77;
            this.origen.Text = "Origen";
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(97, 97);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(81, 20);
            this.nom.TabIndex = 83;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 30);
            this.button1.TabIndex = 84;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(162, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 30);
            this.button2.TabIndex = 85;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 26);
            this.label1.TabIndex = 86;
            this.label1.Text = "(Introduzca solo la información\r\nque quiera modificar)";
            // 
            // ModificarSector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 290);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nom);
            this.Controls.Add(this.DY);
            this.Controls.Add(this.DX);
            this.Controls.Add(this.OY);
            this.Controls.Add(this.OX);
            this.Controls.Add(this.destino);
            this.Controls.Add(this.origen);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificarSector";
            this.Text = "Modificar Sector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label nombre;
        private System.Windows.Forms.TextBox DY;
        private System.Windows.Forms.TextBox DX;
        private System.Windows.Forms.TextBox OY;
        private System.Windows.Forms.TextBox OX;
        private System.Windows.Forms.Label destino;
        private System.Windows.Forms.Label origen;
        private System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}