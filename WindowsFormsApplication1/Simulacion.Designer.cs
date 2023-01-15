namespace FormsProjecte
{
    partial class Simulacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulacion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarBoton = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarAvion = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarSectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarSectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaAerolineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.introduceTiempoDeCicloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarListaDeVuelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porSectoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirVueloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirSectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirCiudadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionesAdicionalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mover = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TextBoxV = new System.Windows.Forms.TextBox();
            this.AceptarBoton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Deshacer = new System.Windows.Forms.Button();
            this.buttonrehacer = new System.Windows.Forms.Button();
            this.buttonsimulacion = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Time = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(313, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 610);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.listaAerolineasToolStripMenuItem,
            this.funcionesToolStripMenuItem,
            this.informaciónToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1043, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarBoton,
            this.guardarAvion,
            this.cargarSectorToolStripMenuItem,
            this.guardarSectorToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // cargarBoton
            // 
            this.cargarBoton.Name = "cargarBoton";
            this.cargarBoton.Size = new System.Drawing.Size(163, 22);
            this.cargarBoton.Text = "Cargar Aviones";
            this.cargarBoton.Click += new System.EventHandler(this.cargarBoton_Click);
            // 
            // guardarAvion
            // 
            this.guardarAvion.Name = "guardarAvion";
            this.guardarAvion.Size = new System.Drawing.Size(163, 22);
            this.guardarAvion.Text = "Guardar Aviones";
            this.guardarAvion.Click += new System.EventHandler(this.guardarAvion_Click_1);
            // 
            // cargarSectorToolStripMenuItem
            // 
            this.cargarSectorToolStripMenuItem.Name = "cargarSectorToolStripMenuItem";
            this.cargarSectorToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.cargarSectorToolStripMenuItem.Text = "Cargar Sectores";
            this.cargarSectorToolStripMenuItem.Click += new System.EventHandler(this.cargarSectorToolStripMenuItem_Click);
            // 
            // guardarSectorToolStripMenuItem
            // 
            this.guardarSectorToolStripMenuItem.Name = "guardarSectorToolStripMenuItem";
            this.guardarSectorToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.guardarSectorToolStripMenuItem.Text = "Guardar Sectores";
            this.guardarSectorToolStripMenuItem.Click += new System.EventHandler(this.guardarSectorToolStripMenuItem_Click);
            // 
            // listaAerolineasToolStripMenuItem
            // 
            this.listaAerolineasToolStripMenuItem.Name = "listaAerolineasToolStripMenuItem";
            this.listaAerolineasToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.listaAerolineasToolStripMenuItem.Text = "Lista Aerolineas";
            this.listaAerolineasToolStripMenuItem.Click += new System.EventHandler(this.listaAerolineasToolStripMenuItem_Click);
            // 
            // funcionesToolStripMenuItem
            // 
            this.funcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.introduceTiempoDeCicloToolStripMenuItem,
            this.mostrarListaDeVuelosToolStripMenuItem,
            this.añadirVueloToolStripMenuItem,
            this.añadirSectorToolStripMenuItem,
            this.añadirCiudadToolStripMenuItem});
            this.funcionesToolStripMenuItem.Name = "funcionesToolStripMenuItem";
            this.funcionesToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.funcionesToolStripMenuItem.Text = "Funciones";
            // 
            // introduceTiempoDeCicloToolStripMenuItem
            // 
            this.introduceTiempoDeCicloToolStripMenuItem.Name = "introduceTiempoDeCicloToolStripMenuItem";
            this.introduceTiempoDeCicloToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.introduceTiempoDeCicloToolStripMenuItem.Text = "Introduce Tiempo de Ciclo";
            this.introduceTiempoDeCicloToolStripMenuItem.Click += new System.EventHandler(this.introduceTiempoDeCicloToolStripMenuItem_Click);
            // 
            // mostrarListaDeVuelosToolStripMenuItem
            // 
            this.mostrarListaDeVuelosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todosToolStripMenuItem,
            this.porSectoresToolStripMenuItem});
            this.mostrarListaDeVuelosToolStripMenuItem.Name = "mostrarListaDeVuelosToolStripMenuItem";
            this.mostrarListaDeVuelosToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.mostrarListaDeVuelosToolStripMenuItem.Text = "Mostrar Lista de Vuelos";
            // 
            // todosToolStripMenuItem
            // 
            this.todosToolStripMenuItem.Name = "todosToolStripMenuItem";
            this.todosToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.todosToolStripMenuItem.Text = "Todos";
            this.todosToolStripMenuItem.Click += new System.EventHandler(this.todosToolStripMenuItem_Click);
            // 
            // porSectoresToolStripMenuItem
            // 
            this.porSectoresToolStripMenuItem.Name = "porSectoresToolStripMenuItem";
            this.porSectoresToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.porSectoresToolStripMenuItem.Text = "Por Sectores";
            this.porSectoresToolStripMenuItem.Click += new System.EventHandler(this.porSectoresToolStripMenuItem_Click);
            // 
            // añadirVueloToolStripMenuItem
            // 
            this.añadirVueloToolStripMenuItem.Name = "añadirVueloToolStripMenuItem";
            this.añadirVueloToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.añadirVueloToolStripMenuItem.Text = "Añadir Vuelo";
            this.añadirVueloToolStripMenuItem.Click += new System.EventHandler(this.añadirVueloToolStripMenuItem_Click);
            // 
            // añadirSectorToolStripMenuItem
            // 
            this.añadirSectorToolStripMenuItem.Name = "añadirSectorToolStripMenuItem";
            this.añadirSectorToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.añadirSectorToolStripMenuItem.Text = "Añadir Sector";
            this.añadirSectorToolStripMenuItem.Click += new System.EventHandler(this.añadirSectorToolStripMenuItem_Click);
            // 
            // añadirCiudadToolStripMenuItem
            // 
            this.añadirCiudadToolStripMenuItem.Name = "añadirCiudadToolStripMenuItem";
            this.añadirCiudadToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.añadirCiudadToolStripMenuItem.Text = "Añadir Ciudad";
            this.añadirCiudadToolStripMenuItem.Click += new System.EventHandler(this.añadirCiudadToolStripMenuItem_Click);
            // 
            // informaciónToolStripMenuItem
            // 
            this.informaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoresToolStripMenuItem,
            this.funcionesAdicionalesToolStripMenuItem});
            this.informaciónToolStripMenuItem.Name = "informaciónToolStripMenuItem";
            this.informaciónToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.informaciónToolStripMenuItem.Text = "Información";
            // 
            // autoresToolStripMenuItem
            // 
            this.autoresToolStripMenuItem.Name = "autoresToolStripMenuItem";
            this.autoresToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.autoresToolStripMenuItem.Text = "Autores";
            this.autoresToolStripMenuItem.Click += new System.EventHandler(this.autoresToolStripMenuItem_Click);
            // 
            // funcionesAdicionalesToolStripMenuItem
            // 
            this.funcionesAdicionalesToolStripMenuItem.Name = "funcionesAdicionalesToolStripMenuItem";
            this.funcionesAdicionalesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.funcionesAdicionalesToolStripMenuItem.Text = "Funciones Adicionales";
            this.funcionesAdicionalesToolStripMenuItem.Click += new System.EventHandler(this.funcionesAdicionalesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "(0,0)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(959, 652);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "(700, 600)";
            // 
            // mover
            // 
            this.mover.Location = new System.Drawing.Point(94, 48);
            this.mover.Name = "mover";
            this.mover.Size = new System.Drawing.Size(110, 23);
            this.mover.TabIndex = 4;
            this.mover.Text = "Mover Vuelos";
            this.mover.UseVisualStyleBackColor = true;
            this.mover.Click += new System.EventHandler(this.mover_Click_1);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TextBoxV
            // 
            this.TextBoxV.Location = new System.Drawing.Point(17, 277);
            this.TextBoxV.Name = "TextBoxV";
            this.TextBoxV.Size = new System.Drawing.Size(149, 20);
            this.TextBoxV.TabIndex = 30;
            // 
            // AceptarBoton
            // 
            this.AceptarBoton.Location = new System.Drawing.Point(190, 274);
            this.AceptarBoton.Name = "AceptarBoton";
            this.AceptarBoton.Size = new System.Drawing.Size(117, 23);
            this.AceptarBoton.TabIndex = 31;
            this.AceptarBoton.Text = "Comprobar Velocidad";
            this.AceptarBoton.UseVisualStyleBackColor = true;
            this.AceptarBoton.Click += new System.EventHandler(this.AceptarBoton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Introduce una Velocidad";
            // 
            // Deshacer
            // 
            this.Deshacer.Location = new System.Drawing.Point(38, 98);
            this.Deshacer.Name = "Deshacer";
            this.Deshacer.Size = new System.Drawing.Size(110, 23);
            this.Deshacer.TabIndex = 33;
            this.Deshacer.Text = "Deshacer Avión";
            this.Deshacer.UseVisualStyleBackColor = true;
            this.Deshacer.Click += new System.EventHandler(this.Deshacer_Click_1);
            // 
            // buttonrehacer
            // 
            this.buttonrehacer.Location = new System.Drawing.Point(168, 98);
            this.buttonrehacer.Name = "buttonrehacer";
            this.buttonrehacer.Size = new System.Drawing.Size(110, 23);
            this.buttonrehacer.TabIndex = 34;
            this.buttonrehacer.Text = "Rehacer Avión";
            this.buttonrehacer.UseVisualStyleBackColor = true;
            this.buttonrehacer.Click += new System.EventHandler(this.buttonrehacer_Click);
            // 
            // buttonsimulacion
            // 
            this.buttonsimulacion.Location = new System.Drawing.Point(38, 349);
            this.buttonsimulacion.Name = "buttonsimulacion";
            this.buttonsimulacion.Size = new System.Drawing.Size(147, 23);
            this.buttonsimulacion.TabIndex = 36;
            this.buttonsimulacion.Text = "Simulación Automática";
            this.buttonsimulacion.UseVisualStyleBackColor = true;
            this.buttonsimulacion.Click += new System.EventHandler(this.buttonsimulacion_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(223, 352);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 20);
            this.textBox1.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(77, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Reiniciar Simulación";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(74, 388);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(34, 13);
            this.Time.TabIndex = 40;
            this.Time.Text = "00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Tiempo Total";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(38, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 23);
            this.button3.TabIndex = 42;
            this.button3.Text = "Deshacer Sector";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(168, 189);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 23);
            this.button4.TabIndex = 43;
            this.button4.Text = "Rehacer Sector";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(38, 444);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 27);
            this.button2.TabIndex = 44;
            this.button2.Text = "Empezar Tutorial";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(175, 444);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(117, 27);
            this.button5.TabIndex = 45;
            this.button5.Text = "Seleccionar Aviones";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Simulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 673);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonsimulacion);
            this.Controls.Add(this.buttonrehacer);
            this.Controls.Add(this.Deshacer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AceptarBoton);
            this.Controls.Add(this.TextBoxV);
            this.Controls.Add(this.mover);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Simulacion";
            this.Text = "Simulador de Vuelo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Simulacion_FormClosing);
            this.Load += new System.EventHandler(this.Simulacion_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarBoton;
        private System.Windows.Forms.ToolStripMenuItem guardarAvion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button mover;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem listaAerolineasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem introduceTiempoDeCicloToolStripMenuItem;
        private System.Windows.Forms.TextBox TextBoxV;
        private System.Windows.Forms.Button AceptarBoton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem cargarSectorToolStripMenuItem;
        private System.Windows.Forms.Button Deshacer;
        private System.Windows.Forms.Button buttonrehacer;
        private System.Windows.Forms.ToolStripMenuItem mostrarListaDeVuelosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirVueloToolStripMenuItem;
        private System.Windows.Forms.Button buttonsimulacion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem guardarSectorToolStripMenuItem;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem añadirSectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionesAdicionalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porSectoresToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirCiudadToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
    }
}

