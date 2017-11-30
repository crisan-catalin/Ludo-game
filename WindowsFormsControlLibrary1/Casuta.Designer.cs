namespace Casuta.UserControl
{
    partial class Casuta
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imaginePion = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imaginePion)).BeginInit();
            this.SuspendLayout();
            // 
            // imaginePion
            // 
            this.imaginePion.BackColor = System.Drawing.Color.Transparent;
            this.imaginePion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imaginePion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imaginePion.Location = new System.Drawing.Point(0, 0);
            this.imaginePion.Name = "imaginePion";
            this.imaginePion.Size = new System.Drawing.Size(150, 150);
            this.imaginePion.TabIndex = 0;
            this.imaginePion.TabStop = false;
            // 
            // Casuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.imaginePion);
            this.Name = "Casuta";
            ((System.ComponentModel.ISupportInitialize)(this.imaginePion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imaginePion;
    }
}
