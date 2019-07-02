namespace ComercioWIN
{
    partial class CargarFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargarFactura));
            this.lblProveedor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComprobante = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCondicion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarProo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dgvDetalleArticulo = new System.Windows.Forms.DataGridView();
            this.txtNombreproov = new System.Windows.Forms.TextBox();
            this.txtPuesto = new System.Windows.Forms.TextBox();
            this.btnAgregarArt = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAñadirLista = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCostoActual = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnModificarCosto = new System.Windows.Forms.Button();
            this.lblCostoActual = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblSelecArt = new System.Windows.Forms.Label();
            this.lblIngrCant = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(69, 16);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(56, 13);
            this.lblProveedor.TabIndex = 6;
            this.lblProveedor.Text = "Proveedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha";
            // 
            // txtComprobante
            // 
            this.txtComprobante.Location = new System.Drawing.Point(263, 35);
            this.txtComprobante.MaxLength = 8;
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(100, 20);
            this.txtComprobante.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Num Comprobante";
            // 
            // cboCondicion
            // 
            this.cboCondicion.FormattingEnabled = true;
            this.cboCondicion.Items.AddRange(new object[] {
            "Efectivo",
            "Cuenta Corriente"});
            this.cboCondicion.Location = new System.Drawing.Point(122, 70);
            this.cboCondicion.Name = "cboCondicion";
            this.cboCondicion.Size = new System.Drawing.Size(133, 21);
            this.cboCondicion.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Condicion de Pago";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(347, 73);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 5;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(291, 76);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(46, 13);
            this.lblMonto.TabIndex = 25;
            this.lblMonto.Text = "Monto $";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(386, 36);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // btnBuscarProo
            // 
            this.btnBuscarProo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBuscarProo.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarProo.Image")));
            this.btnBuscarProo.Location = new System.Drawing.Point(12, 16);
            this.btnBuscarProo.Name = "btnBuscarProo";
            this.btnBuscarProo.Size = new System.Drawing.Size(39, 39);
            this.btnBuscarProo.TabIndex = 0;
            this.btnBuscarProo.UseVisualStyleBackColor = true;
            this.btnBuscarProo.Click += new System.EventHandler(this.btnBuscarProo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(655, 344);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(655, 312);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 30;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dgvDetalleArticulo
            // 
            this.dgvDetalleArticulo.AllowUserToAddRows = false;
            this.dgvDetalleArticulo.AllowUserToDeleteRows = false;
            this.dgvDetalleArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleArticulo.Location = new System.Drawing.Point(19, 116);
            this.dgvDetalleArticulo.Name = "dgvDetalleArticulo";
            this.dgvDetalleArticulo.ReadOnly = true;
            this.dgvDetalleArticulo.Size = new System.Drawing.Size(399, 150);
            this.dgvDetalleArticulo.TabIndex = 31;
            // 
            // txtNombreproov
            // 
            this.txtNombreproov.Location = new System.Drawing.Point(72, 33);
            this.txtNombreproov.Name = "txtNombreproov";
            this.txtNombreproov.ReadOnly = true;
            this.txtNombreproov.Size = new System.Drawing.Size(100, 20);
            this.txtNombreproov.TabIndex = 1;
            // 
            // txtPuesto
            // 
            this.txtPuesto.Location = new System.Drawing.Point(211, 36);
            this.txtPuesto.MaxLength = 4;
            this.txtPuesto.Name = "txtPuesto";
            this.txtPuesto.Size = new System.Drawing.Size(46, 20);
            this.txtPuesto.TabIndex = 32;
            // 
            // btnAgregarArt
            // 
            this.btnAgregarArt.Location = new System.Drawing.Point(19, 286);
            this.btnAgregarArt.Name = "btnAgregarArt";
            this.btnAgregarArt.Size = new System.Drawing.Size(118, 23);
            this.btnAgregarArt.TabIndex = 33;
            this.btnAgregarArt.Text = "Buscar Articulo";
            this.btnAgregarArt.UseVisualStyleBackColor = true;
            this.btnAgregarArt.Click += new System.EventHandler(this.btnAgregarArt_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(304, 328);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(73, 20);
            this.txtCantidad.TabIndex = 34;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(600, 116);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(130, 23);
            this.btnQuitar.TabIndex = 35;
            this.btnQuitar.Text = "Quitar de la lista";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAñadirLista
            // 
            this.btnAñadirLista.Location = new System.Drawing.Point(386, 325);
            this.btnAñadirLista.Name = "btnAñadirLista";
            this.btnAñadirLista.Size = new System.Drawing.Size(117, 23);
            this.btnAñadirLista.TabIndex = 36;
            this.btnAñadirLista.Text = "Añadir a la Lista";
            this.btnAñadirLista.UseVisualStyleBackColor = true;
            this.btnAñadirLista.Click += new System.EventHandler(this.btnAñadirLista_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(19, 328);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(58, 20);
            this.txtID.TabIndex = 37;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // txtCostoActual
            // 
            this.txtCostoActual.Location = new System.Drawing.Point(235, 328);
            this.txtCostoActual.Name = "txtCostoActual";
            this.txtCostoActual.ReadOnly = true;
            this.txtCostoActual.Size = new System.Drawing.Size(61, 20);
            this.txtCostoActual.TabIndex = 39;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(83, 328);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(140, 20);
            this.txtDescripcion.TabIndex = 40;
            // 
            // btnModificarCosto
            // 
            this.btnModificarCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarCosto.Location = new System.Drawing.Point(220, 354);
            this.btnModificarCosto.Name = "btnModificarCosto";
            this.btnModificarCosto.Size = new System.Drawing.Size(86, 22);
            this.btnModificarCosto.TabIndex = 41;
            this.btnModificarCosto.Text = "Modificar Costo";
            this.btnModificarCosto.UseVisualStyleBackColor = true;
            this.btnModificarCosto.Click += new System.EventHandler(this.btnModificarCosto_Click);
            // 
            // lblCostoActual
            // 
            this.lblCostoActual.AutoSize = true;
            this.lblCostoActual.Location = new System.Drawing.Point(234, 312);
            this.lblCostoActual.Name = "lblCostoActual";
            this.lblCostoActual.Size = new System.Drawing.Size(67, 13);
            this.lblCostoActual.TabIndex = 42;
            this.lblCostoActual.Text = "Costo Actual";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(31, 312);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 43;
            this.lblCodigo.Text = "Codigo";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(314, 312);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 44;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(119, 312);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 46;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblSelecArt
            // 
            this.lblSelecArt.AutoSize = true;
            this.lblSelecArt.ForeColor = System.Drawing.Color.Red;
            this.lblSelecArt.Location = new System.Drawing.Point(144, 290);
            this.lblSelecArt.Name = "lblSelecArt";
            this.lblSelecArt.Size = new System.Drawing.Size(115, 13);
            this.lblSelecArt.TabIndex = 47;
            this.lblSelecArt.Text = "Seleccione Un Articulo";
            this.lblSelecArt.Visible = false;
            // 
            // lblIngrCant
            // 
            this.lblIngrCant.AutoSize = true;
            this.lblIngrCant.ForeColor = System.Drawing.Color.Red;
            this.lblIngrCant.Location = new System.Drawing.Point(301, 299);
            this.lblIngrCant.Name = "lblIngrCant";
            this.lblIngrCant.Size = new System.Drawing.Size(87, 13);
            this.lblIngrCant.TabIndex = 48;
            this.lblIngrCant.Text = "Ingrese Cantidad";
            this.lblIngrCant.Visible = false;
            // 
            // CargarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(758, 379);
            this.Controls.Add(this.lblIngrCant);
            this.Controls.Add(this.lblSelecArt);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblCostoActual);
            this.Controls.Add(this.btnModificarCosto);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCostoActual);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnAñadirLista);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.btnAgregarArt);
            this.Controls.Add(this.txtPuesto);
            this.Controls.Add(this.txtNombreproov);
            this.Controls.Add(this.dgvDetalleArticulo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscarProo);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCondicion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtComprobante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblProveedor);
            this.Name = "CargarFactura";
            this.Text = "6";
            this.Load += new System.EventHandler(this.CargarFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComprobante;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCondicion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnBuscarProo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dgvDetalleArticulo;
        private System.Windows.Forms.TextBox txtNombreproov;
        private System.Windows.Forms.TextBox txtPuesto;
        private System.Windows.Forms.Button btnAgregarArt;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAñadirLista;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtCostoActual;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnModificarCosto;
        private System.Windows.Forms.Label lblCostoActual;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblSelecArt;
        private System.Windows.Forms.Label lblIngrCant;
    }
}