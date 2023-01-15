namespace FormsProjecte
{
    partial class AñadirVuelos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AñadirVuelos));
            this.buttonAñadir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.velocidad = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.Label();
            this.origen = new System.Windows.Forms.Label();
            this.compañia = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.textBoxVelocidad = new System.Windows.Forms.TextBox();
            this.textBoxCompañia = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonAñadir
            // 
            this.buttonAñadir.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAñadir.ForeColor = System.Drawing.Color.Black;
            this.buttonAñadir.Location = new System.Drawing.Point(151, 265);
            this.buttonAñadir.Name = "buttonAñadir";
            this.buttonAñadir.Size = new System.Drawing.Size(75, 23);
            this.buttonAñadir.TabIndex = 73;
            this.buttonAñadir.Text = "Añadir";
            this.buttonAñadir.UseVisualStyleBackColor = false;
            this.buttonAñadir.Click += new System.EventHandler(this.buttonAñadir_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(88, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 16);
            this.label4.TabIndex = 72;
            this.label4.Text = "Información para el nuevo vuelo";
            // 
            // velocidad
            // 
            this.velocidad.AutoSize = true;
            this.velocidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.velocidad.ForeColor = System.Drawing.Color.Black;
            this.velocidad.Location = new System.Drawing.Point(50, 217);
            this.velocidad.Name = "velocidad";
            this.velocidad.Size = new System.Drawing.Size(70, 16);
            this.velocidad.TabIndex = 71;
            this.velocidad.Text = "Velocidad";
            // 
            // destino
            // 
            this.destino.AutoSize = true;
            this.destino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destino.ForeColor = System.Drawing.Color.Black;
            this.destino.Location = new System.Drawing.Point(50, 173);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(54, 16);
            this.destino.TabIndex = 70;
            this.destino.Text = "Destino";
            // 
            // origen
            // 
            this.origen.AutoSize = true;
            this.origen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origen.ForeColor = System.Drawing.Color.Black;
            this.origen.Location = new System.Drawing.Point(50, 127);
            this.origen.Name = "origen";
            this.origen.Size = new System.Drawing.Size(48, 16);
            this.origen.TabIndex = 69;
            this.origen.Text = "Origen";
            // 
            // compañia
            // 
            this.compañia.AutoSize = true;
            this.compañia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compañia.ForeColor = System.Drawing.Color.Black;
            this.compañia.Location = new System.Drawing.Point(50, 93);
            this.compañia.Name = "compañia";
            this.compañia.Size = new System.Drawing.Size(70, 16);
            this.compañia.TabIndex = 68;
            this.compañia.Text = "Compañía";
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.ForeColor = System.Drawing.Color.Black;
            this.id.Location = new System.Drawing.Point(50, 63);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(21, 16);
            this.id.TabIndex = 67;
            this.id.Text = "ID";
            // 
            // textBoxVelocidad
            // 
            this.textBoxVelocidad.Location = new System.Drawing.Point(150, 213);
            this.textBoxVelocidad.Name = "textBoxVelocidad";
            this.textBoxVelocidad.Size = new System.Drawing.Size(100, 20);
            this.textBoxVelocidad.TabIndex = 66;
            // 
            // textBoxCompañia
            // 
            this.textBoxCompañia.Location = new System.Drawing.Point(150, 93);
            this.textBoxCompañia.Name = "textBoxCompañia";
            this.textBoxCompañia.Size = new System.Drawing.Size(101, 20);
            this.textBoxCompañia.TabIndex = 61;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(150, 59);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(101, 20);
            this.textBoxID.TabIndex = 60;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(150, 127);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 74;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(150, 168);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(101, 21);
            this.comboBox2.TabIndex = 75;
            // 
            // AñadirVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 305);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonAñadir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.velocidad);
            this.Controls.Add(this.destino);
            this.Controls.Add(this.origen);
            this.Controls.Add(this.compañia);
            this.Controls.Add(this.id);
            this.Controls.Add(this.textBoxVelocidad);
            this.Controls.Add(this.textBoxCompañia);
            this.Controls.Add(this.textBoxID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AñadirVuelos";
            this.Text = "Nuevo Vuelo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAñadir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label velocidad;
        private System.Windows.Forms.Label destino;
        private System.Windows.Forms.Label origen;
        private System.Windows.Forms.Label compañia;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.TextBox textBoxVelocidad;
        private System.Windows.Forms.TextBox textBoxCompañia;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}