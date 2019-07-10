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
            this.btnListarArticulos = new System.Windows.Forms.Button();
            this.btnListarClientes = new System.Windows.Forms.Button();
            this.btnMarca = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCargarFactura = new System.Windows.Forms.Button();
            this.btnFactura = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnListarArticulos
            // 
            this.btnListarArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarArticulos.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnListarArticulos.Image = ((System.Drawing.Image)(resources.GetObject("btnListarArticulos.Image")));
            this.btnListarArticulos.Location = new System.Drawing.Point(2, 276);
            this.btnListarArticulos.Name = "btnListarArticulos";
            this.btnListarArticulos.Size = new System.Drawing.Size(145, 82);
            this.btnListarArticulos.TabIndex = 3;
            this.btnListarArticulos.UseVisualStyleBackColor = true;
            this.btnListarArticulos.Click += new System.EventHandler(this.btnListarProvincias_Click);
            // 
            // btnListarClientes
            // 
            this.btnListarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarClientes.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnListarClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnListarClientes.Image")));
            this.btnListarClientes.Location = new System.Drawing.Point(2, 100);
            this.btnListarClientes.Name = "btnListarClientes";
            this.btnListarClientes.Size = new System.Drawing.Size(145, 82);
            this.btnListarClientes.TabIndex = 4;
            this.btnListarClientes.UseVisualStyleBackColor = true;
            this.btnListarClientes.Click += new System.EventHandler(this.btnListarClientes_Click);
            // 
            // btnMarca
            // 
            this.btnMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarca.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMarca.Image = ((System.Drawing.Image)(resources.GetObject("btnMarca.Image")));
            this.btnMarca.Location = new System.Drawing.Point(569, 276);
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Size = new System.Drawing.Size(145, 82);
            this.btnMarca.TabIndex = 5;
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.btnMarca_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(569, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 82);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(569, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 82);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCargarFactura
            // 
            this.btnCargarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarFactura.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCargarFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnCargarFactura.Image")));
            this.btnCargarFactura.Location = new System.Drawing.Point(2, 188);
            this.btnCargarFactura.Name = "btnCargarFactura";
            this.btnCargarFactura.Size = new System.Drawing.Size(145, 82);
            this.btnCargarFactura.TabIndex = 9;
            this.btnCargarFactura.UseVisualStyleBackColor = true;
            this.btnCargarFactura.Click += new System.EventHandler(this.btnCargarFactura_Click);
            // 
            // btnFactura
            // 
            this.btnFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFactura.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnFactura.Image")));
            this.btnFactura.Location = new System.Drawing.Point(2, 12);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(145, 82);
            this.btnFactura.TabIndex = 11;
            this.btnFactura.UseVisualStyleBackColor = true;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(289, 335);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(93, 23);
            this.btnCerrar.TabIndex = 15;
            this.btnCerrar.Text = "Cerrar Sesion";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReimprimir.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReimprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnReimprimir.Image")));
            this.btnReimprimir.Location = new System.Drawing.Point(569, 12);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(145, 82);
            this.btnReimprimir.TabIndex = 16;
            this.btnReimprimir.UseVisualStyleBackColor = true;
            this.btnReimprimir.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(723, 368);
            this.ControlBox = false;
            this.Controls.Add(this.btnReimprimir);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnFactura);
            this.Controls.Add(this.btnCargarFactura);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnMarca);
            this.Controls.Add(this.btnListarClientes);
            this.Controls.Add(this.btnListarArticulos);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnListarArticulos;
        private System.Windows.Forms.Button btnListarClientes;
        private System.Windows.Forms.Button btnMarca;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCargarFactura;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnReimprimir;
    }
}

