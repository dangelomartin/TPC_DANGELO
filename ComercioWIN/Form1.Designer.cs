namespace ComercioWIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnListarProvincias = new System.Windows.Forms.Button();
            this.btnListarClientes = new System.Windows.Forms.Button();
            this.btnMarca = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCargarFactura = new System.Windows.Forms.Button();
            this.btnFactura = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnListarProvincias
            // 
            this.btnListarProvincias.Location = new System.Drawing.Point(196, 25);
            this.btnListarProvincias.Name = "btnListarProvincias";
            this.btnListarProvincias.Size = new System.Drawing.Size(77, 58);
            this.btnListarProvincias.TabIndex = 3;
            this.btnListarProvincias.Text = "Articulos";
            this.btnListarProvincias.UseVisualStyleBackColor = true;
            this.btnListarProvincias.Click += new System.EventHandler(this.btnListarProvincias_Click);
            // 
            // btnListarClientes
            // 
            this.btnListarClientes.Location = new System.Drawing.Point(22, 25);
            this.btnListarClientes.Name = "btnListarClientes";
            this.btnListarClientes.Size = new System.Drawing.Size(75, 58);
            this.btnListarClientes.TabIndex = 4;
            this.btnListarClientes.Text = "Clientes";
            this.btnListarClientes.UseVisualStyleBackColor = true;
            this.btnListarClientes.Click += new System.EventHandler(this.btnListarClientes_Click);
            // 
            // btnMarca
            // 
            this.btnMarca.Location = new System.Drawing.Point(279, 57);
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Size = new System.Drawing.Size(75, 23);
            this.btnMarca.TabIndex = 5;
            this.btnMarca.Text = "Marcas";
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.btnMarca_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(279, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Rubros";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(115, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 55);
            this.button3.TabIndex = 7;
            this.button3.Text = "Proveedores";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCargarFactura
            // 
            this.btnCargarFactura.Location = new System.Drawing.Point(196, 96);
            this.btnCargarFactura.Name = "btnCargarFactura";
            this.btnCargarFactura.Size = new System.Drawing.Size(158, 23);
            this.btnCargarFactura.TabIndex = 9;
            this.btnCargarFactura.Text = "Cargar Factura";
            this.btnCargarFactura.UseVisualStyleBackColor = true;
            this.btnCargarFactura.Click += new System.EventHandler(this.btnCargarFactura_Click);
            // 
            // btnFactura
            // 
            this.btnFactura.Location = new System.Drawing.Point(115, 96);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(75, 53);
            this.btnFactura.TabIndex = 11;
            this.btnFactura.Text = "Facturar";
            this.btnFactura.UseVisualStyleBackColor = true;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(713, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 75);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 263);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFactura);
            this.Controls.Add(this.btnCargarFactura);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnMarca);
            this.Controls.Add(this.btnListarClientes);
            this.Controls.Add(this.btnListarProvincias);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnListarProvincias;
        private System.Windows.Forms.Button btnListarClientes;
        private System.Windows.Forms.Button btnMarca;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCargarFactura;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.Button button1;
    }
}

