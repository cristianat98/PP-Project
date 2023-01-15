namespace FormsProjecte
{
    partial class Infoautores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Infoautores));
            this.button1 = new System.Windows.Forms.Button();
            this.nombres = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(607, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nombres
            // 
            this.nombres.AutoSize = true;
            this.nombres.Location = new System.Drawing.Point(435, 27);
            this.nombres.Name = "nombres";
            this.nombres.Size = new System.Drawing.Size(91, 91);
            this.nombres.TabIndex = 2;
            this.nombres.Text = "Cristian Armesto\r\n\r\nMiquel Puspa\r\n\r\nMaria Gayà\r\n\r\nMontse Nogueras\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(544, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 91);
            this.label1.TabIndex = 3;
            this.label1.Text = "cristian.armesto@estudiant.upc.edu\r\n\r\nmiquel.puspa.torres@estudiant.upc.edu\r\n\r\nma" +
    "ria.gayà@estudiant.upc.edu\r\n\r\nmaria.montserrat.nogueras@estudiant.upc.edu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FormsProjecte.Properties.Resources._20171214_125231_opt;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(397, 223);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Infoautores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 289);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nombres);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Infoautores";
            this.Text = "Infoautores";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label nombres;
        private System.Windows.Forms.Label label1;
    }
}