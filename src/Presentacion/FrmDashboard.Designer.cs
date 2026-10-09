namespace Presentacion
{
    partial class FrmDashboard
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
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.picLogoFondo = new System.Windows.Forms.PictureBox();
            this.lblBienvenidos = new System.Windows.Forms.Label();
            this.PanelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoFondo)).BeginInit();
            this.SuspendLayout();
            //
            // PanelPrincipal
            //
            this.PanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.PanelPrincipal.Controls.Add(this.picLogoFondo);
            this.PanelPrincipal.Controls.Add(this.lblBienvenidos);
            this.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(1279, 872);
            this.PanelPrincipal.TabIndex = 0;
            //
            // picLogoFondo
            //
            this.picLogoFondo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogoFondo.Image = global::Presentacion.Properties.Resources.LogoTranslucido;
            this.picLogoFondo.Location = new System.Drawing.Point(240, 200);
            this.picLogoFondo.Name = "picLogoFondo";
            this.picLogoFondo.Size = new System.Drawing.Size(800, 341);
            this.picLogoFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoFondo.TabIndex = 0;
            this.picLogoFondo.TabStop = false;
            //
            // lblBienvenidos
            //
            this.lblBienvenidos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBienvenidos.Font = new System.Drawing.Font("Segoe UI Semibold", 40F);
            this.lblBienvenidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(47)))), ((int)(((byte)(103)))));
            this.lblBienvenidos.Location = new System.Drawing.Point(290, 571);
            this.lblBienvenidos.Name = "lblBienvenidos";
            this.lblBienvenidos.Size = new System.Drawing.Size(700, 100);
            this.lblBienvenidos.TabIndex = 1;
            this.lblBienvenidos.Text = "Bienvenidos";
            this.lblBienvenidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // FrmDashboard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1279, 872);
            this.Controls.Add(this.PanelPrincipal);
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.PanelPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoFondo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.PictureBox picLogoFondo;
        private System.Windows.Forms.Label lblBienvenidos;
    }
}
