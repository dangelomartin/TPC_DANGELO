namespace ComercioWIN
{
    partial class Factura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Factura));
            this.txtcliente = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregaArt = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvDetalleArticulo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.txtNumFactura = new System.Windows.Forms.TextBox();
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.lblSelec = new System.Windows.Forms.Label();
            this.btnBorrarArt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcliente
            // 
            this.txtcliente.Location = new System.Drawing.Point(22, 15);
            this.txtcliente.Name = "txtcliente";
            this.txtcliente.ReadOnly = true;
            this.txtcliente.Size = new System.Drawing.Size(221, 20);
            this.txtcliente.TabIndex = 0;
            this.txtcliente.TextChanged += new System.EventHandler(this.txtcliente_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(261, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(173, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar Cliente";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregaArt
            // 
            this.btnAgregaArt.Enabled = false;
            this.btnAgregaArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregaArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregaArt.Location = new System.Drawing.Point(91, 78);
            this.btnAgregaArt.Name = "btnAgregaArt";
            this.btnAgregaArt.Size = new System.Drawing.Size(174, 23);
            this.btnAgregaArt.TabIndex = 3;
            this.btnAgregaArt.Text = "Agregar Articulo";
            this.btnAgregaArt.UseVisualStyleBackColor = true;
            this.btnAgregaArt.Click += new System.EventHandler(this.btnAgregaArt_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Location = new System.Drawing.Point(19, 80);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(49, 20);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(648, 332);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(100, 20);
            this.txtFinal.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(574, 332);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 6;
            // 
            // dgvDetalleArticulo
            // 
            this.dgvDetalleArticulo.AllowUserToAddRows = false;
            this.dgvDetalleArticulo.AllowUserToDeleteRows = false;
            this.dgvDetalleArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleArticulo.Location = new System.Drawing.Point(22, 120);
            this.dgvDetalleArticulo.MultiSelect = false;
            this.dgvDetalleArticulo.Name = "dgvDetalleArticulo";
            this.dgvDetalleArticulo.ReadOnly = true;
            this.dgvDetalleArticulo.RowHeadersVisible = false;
            this.dgvDetalleArticulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleArticulo.Size = new System.Drawing.Size(726, 185);
            this.dgvDetalleArticulo.TabIndex = 7;
            this.dgvDetalleArticulo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleArticulo_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cantidad";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(598, 371);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(150, 23);
            this.btnFinalizar.TabIndex = 11;
            this.btnFinalizar.Text = "Finalizar Factura";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // txtNumFactura
            // 
            this.txtNumFactura.Location = new System.Drawing.Point(648, 12);
            this.txtNumFactura.Name = "txtNumFactura";
            this.txtNumFactura.Size = new System.Drawing.Size(100, 20);
            this.txtNumFactura.TabIndex = 12;
            this.txtNumFactura.TextChanged += new System.EventHandler(this.txtNumFactura_TextChanged);
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.AutoSize = true;
            this.lblImporteTotal.Location = new System.Drawing.Point(663, 316);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(69, 13);
            this.lblImporteTotal.TabIndex = 13;
            this.lblImporteTotal.Text = "Importe Total";
            // 
            // lblSelec
            // 
            this.lblSelec.AutoSize = true;
            this.lblSelec.ForeColor = System.Drawing.Color.Red;
            this.lblSelec.Location = new System.Drawing.Point(88, 38);
            this.lblSelec.Name = "lblSelec";
            this.lblSelec.Size = new System.Drawing.Size(110, 13);
            this.lblSelec.TabIndex = 14;
            this.lblSelec.Text = "Seleccione un Cliente";
            // 
            // btnBorrarArt
            // 
            this.btnBorrarArt.Location = new System.Drawing.Point(22, 332);
            this.btnBorrarArt.Name = "btnBorrarArt";
            this.btnBorrarArt.Size = new System.Drawing.Size(85, 23);
            this.btnBorrarArt.TabIndex = 15;
            this.btnBorrarArt.Text = "Borrar Articulo";
            this.btnBorrarArt.UseVisualStyleBackColor = true;
            this.btnBorrarArt.Click += new System.EventHandler(this.btnBorrarArt_Click);
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBorrarArt);
            this.Controls.Add(this.lblSelec);
            this.Controls.Add(this.lblImporteTotal);
            this.Controls.Add(this.txtNumFactura);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDetalleArticulo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtFinal);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.btnAgregaArt);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtcliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Factura";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.Factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtcliente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregaArt;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvDetalleArticulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.TextBox txtNumFactura;
        private System.Windows.Forms.Label lblImporteTotal;
        private System.Windows.Forms.Label lblSelec;
        private System.Windows.Forms.Button btnBorrarArt;
    }
}