namespace grafic_RA
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.welcome_portada = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.compile = new System.Windows.Forms.Button();
            this.graph = new System.Windows.Forms.Button();
            this.entrada_codigo = new System.Windows.Forms.TextBox();
            this.entrada_portada = new System.Windows.Forms.Label();
            this.foto_portada = new System.Windows.Forms.PictureBox();
            this.Errores_portada = new System.Windows.Forms.Label();
            this.Lista_de_errores = new System.Windows.Forms.ListBox();
            this.Paint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.foto_portada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paint)).BeginInit();
            this.SuspendLayout();
            // 
            // welcome_portada
            // 
            this.welcome_portada.AutoSize = true;
            this.welcome_portada.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_portada.ForeColor = System.Drawing.Color.MediumBlue;
            this.welcome_portada.Location = new System.Drawing.Point(3, 9);
            this.welcome_portada.Name = "welcome_portada";
            this.welcome_portada.Size = new System.Drawing.Size(451, 49);
            this.welcome_portada.TabIndex = 0;
            this.welcome_portada.Text = "Welcome to Geo Wall-E RA";
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.White;
            this.exit.Font = new System.Drawing.Font("Monotype Corsiva", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(1003, 677);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(80, 33);
            this.exit.TabIndex = 1;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // compile
            // 
            this.compile.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compile.Location = new System.Drawing.Point(870, 23);
            this.compile.Name = "compile";
            this.compile.Size = new System.Drawing.Size(91, 35);
            this.compile.TabIndex = 2;
            this.compile.Text = "Compile";
            this.compile.UseVisualStyleBackColor = true;
            this.compile.Click += new System.EventHandler(this.Compile_Click);
            // 
            // graph
            // 
            this.graph.BackColor = System.Drawing.Color.White;
            this.graph.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graph.Location = new System.Drawing.Point(981, 23);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(79, 35);
            this.graph.TabIndex = 3;
            this.graph.Text = "Graph";
            this.graph.UseVisualStyleBackColor = false;
            this.graph.Click += new System.EventHandler(this.Graph_Click);
            // 
            // entrada_codigo
            // 
            this.entrada_codigo.Location = new System.Drawing.Point(16, 381);
            this.entrada_codigo.Multiline = true;
            this.entrada_codigo.Name = "entrada_codigo";
            this.entrada_codigo.Size = new System.Drawing.Size(250, 319);
            this.entrada_codigo.TabIndex = 4;
            // 
            // entrada_portada
            // 
            this.entrada_portada.AutoSize = true;
            this.entrada_portada.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entrada_portada.Location = new System.Drawing.Point(12, 354);
            this.entrada_portada.Name = "entrada_portada";
            this.entrada_portada.Size = new System.Drawing.Size(75, 24);
            this.entrada_portada.TabIndex = 5;
            this.entrada_portada.Text = "Entrada";
            // 
            // foto_portada
            // 
            this.foto_portada.Image = ((System.Drawing.Image)(resources.GetObject("foto_portada.Image")));
            this.foto_portada.Location = new System.Drawing.Point(42, 81);
            this.foto_portada.Name = "foto_portada";
            this.foto_portada.Size = new System.Drawing.Size(201, 190);
            this.foto_portada.TabIndex = 6;
            this.foto_portada.TabStop = false;
            // 
            // Errores_portada
            // 
            this.Errores_portada.AutoSize = true;
            this.Errores_portada.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Errores_portada.Location = new System.Drawing.Point(309, 589);
            this.Errores_portada.Name = "Errores_portada";
            this.Errores_portada.Size = new System.Drawing.Size(68, 24);
            this.Errores_portada.TabIndex = 8;
            this.Errores_portada.Text = "Errores";
            // 
            // Lista_de_errores
            // 
            this.Lista_de_errores.FormattingEnabled = true;
            this.Lista_de_errores.ItemHeight = 16;
            this.Lista_de_errores.Location = new System.Drawing.Point(313, 616);
            this.Lista_de_errores.Name = "Lista_de_errores";
            this.Lista_de_errores.Size = new System.Drawing.Size(676, 84);
            this.Lista_de_errores.TabIndex = 9;
            // 
            // Paint
            // 
            this.Paint.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Paint.Location = new System.Drawing.Point(313, 61);
            this.Paint.Name = "Paint";
            this.Paint.Size = new System.Drawing.Size(747, 525);
            this.Paint.TabIndex = 10;
            this.Paint.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 722);
            this.Controls.Add(this.Paint);
            this.Controls.Add(this.Lista_de_errores);
            this.Controls.Add(this.Errores_portada);
            this.Controls.Add(this.foto_portada);
            this.Controls.Add(this.entrada_portada);
            this.Controls.Add(this.entrada_codigo);
            this.Controls.Add(this.graph);
            this.Controls.Add(this.compile);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.welcome_portada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.Text = "Geo Wall-E RA";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.foto_portada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome_portada;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button compile;
        private System.Windows.Forms.Button graph;
        public System.Windows.Forms.TextBox entrada_codigo;
        private System.Windows.Forms.Label entrada_portada;
        private System.Windows.Forms.PictureBox foto_portada;
        private System.Windows.Forms.Label Errores_portada;
        public System.Windows.Forms.ListBox Lista_de_errores;
        public System.Windows.Forms.PictureBox Paint;
    }
}

