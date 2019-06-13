namespace ComercioWIN
{
    partial class Compras
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
            this.btnListarComp = new System.Windows.Forms.Button();
            this.btnCargarFact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnListarComp
            // 
            this.btnListarComp.Location = new System.Drawing.Point(12, 41);
            this.btnListarComp.Name = "btnListarComp";
            this.btnListarComp.Size = new System.Drawing.Size(146, 23);
            this.btnListarComp.TabIndex = 0;
            this.btnListarComp.Text = "Listar Compras";
            this.btnListarComp.UseVisualStyleBackColor = true;
            // 
            // btnCargarFact
            // 
            this.btnCargarFact.Location = new System.Drawing.Point(12, 12);
            this.btnCargarFact.Name = "btnCargarFact";
            this.btnCargarFact.Size = new System.Drawing.Size(146, 23);
            this.btnCargarFact.TabIndex = 1;
            this.btnCargarFact.Text = "Cargar Factura";
            this.btnCargarFact.UseVisualStyleBackColor = true;
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(175, 88);
            this.Controls.Add(this.btnCargarFact);
            this.Controls.Add(this.btnListarComp);
            this.Name = "Compras";
            this.Text = "Compras";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListarComp;
        private System.Windows.Forms.Button btnCargarFact;
    }
}