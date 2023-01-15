namespace FormsProjecte
{
    partial class AñadirSector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AñadirSector));
            this.origen = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.Label();
            this.textBoxOX = new System.Windows.Forms.TextBox();
            this.textBoxOY = new System.Windows.Forms.TextBox();
            this.textBoxDX = new System.Windows.Forms.TextBox();
            this.textBoxDY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAñadir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // origen
            // 
            this.origen.AutoSize = true;
            this.origen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origen.ForeColor = System.Drawing.Color.Black;
            this.origen.Location = new System.Drawing.Point(30, 95);
            this.origen.Name = "origen";
            this.origen.Size = new System.Drawing.Size(48, 16);
            this.origen.TabIndex = 70;
            this.origen.Text = "Origen";
            // 
            // destino
            // 
            this.destino.AutoSize = true;
            this.destino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destino.ForeColor = System.Drawing.Color.Black;
            this.destino.Location = new System.Drawing.Point(30, 143);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(54, 16);
            this.destino.TabIndex = 71;
            this.destino.Text = "Destino";
            // 
            // textBoxOX
            // 
            this.textBoxOX.Location = new System.Drawing.Point(102, 91);
            this.textBoxOX.Name = "textBoxOX";
            this.textBoxOX.Size = new System.Drawing.Size(76, 20);
            this.textBoxOX.TabIndex = 73;
            // 
            // textBoxOY
            // 
            this.textBoxOY.Location = new System.Drawing.Point(202, 91);
            this.textBoxOY.Name = "textBoxOY";
            this.textBoxOY.Size = new System.Drawing.Size(85, 20);
            this.textBoxOY.TabIndex = 74;
            // 
            // textBoxDX
            // 
            this.textBoxDX.Location = new System.Drawing.Point(102, 139);
            this.textBoxDX.Name = "textBoxDX";
            this.textBoxDX.Size = new System.Drawing.Size(76, 20);
            this.textBoxDX.TabIndex = 75;
            // 
            // textBoxDY
            // 
            this.textBoxDY.Location = new System.Drawing.Point(202, 139);
            this.textBoxDY.Name = "textBoxDY";
            this.textBoxDY.Size = new System.Drawing.Size(85, 20);
            this.textBoxDY.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(85, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 16);
            this.label4.TabIndex = 79;
            this.label4.Text = "Información para el nuevo sector";
            // 
            // buttonAñadir
            // 
            this.buttonAñadir.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAñadir.ForeColor = System.Drawing.Color.Black;
            this.buttonAñadir.Location = new System.Drawing.Point(130, 178);
            this.buttonAñadir.Name = "buttonAñadir";
            this.buttonAñadir.Size = new System.Drawing.Size(75, 23);
            this.buttonAñadir.TabIndex = 80;
            this.buttonAñadir.Text = "Añadir";
            this.buttonAñadir.UseVisualStyleBackColor = false;
            this.buttonAñadir.Click += new System.EventHandler(this.buttonAñadir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 81;
            this.label1.Text = "Nombre";
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(102, 53);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(81, 20);
            this.Nombre.TabIndex = 82;
            // 
            // AñadirSector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 229);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAñadir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDY);
            this.Controls.Add(this.textBoxDX);
            this.Controls.Add(this.textBoxOY);
            this.Controls.Add(this.textBoxOX);
            this.Controls.Add(this.destino);
            this.Controls.Add(this.origen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AñadirSector";
            this.Text = "Nuevo Sector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label origen;
        private System.Windows.Forms.Label destino;
        private System.Windows.Forms.TextBox textBoxOX;
        private System.Windows.Forms.TextBox textBoxOY;
        private System.Windows.Forms.TextBox textBoxDX;
        private System.Windows.Forms.TextBox textBoxDY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAñadir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Nombre;


    }
}